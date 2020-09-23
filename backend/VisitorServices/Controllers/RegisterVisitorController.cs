using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VisitorServices.Helpers;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RegisterVisitorController : Controller
    {
        private readonly IAddVisitorInformationRepository _repo;
        private readonly IConfiguration _config;

        public RegisterVisitorController(IAddVisitorInformationRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost]
        public ActionResult<TokenAndMessageReturn> PostVisitorInformation([FromForm]VisitorInformationForCreation visitorInformationViewModel)
        {
            if (visitorInformationViewModel == null)
            {

                return BadRequest(new TokenAndMessageReturn
                {
                    Token = null,
                    Message = "User Information Not Corrected Or Empty",
                    VisitorInformationForReturn = null,
                    StatusCode = 400
                });
            }
            var visitorInformation = _repo.AddVisitorInformation(visitorInformationViewModel);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, visitorInformationViewModel.IdNumber),
            };

            var secretBytes = Encoding.UTF8.GetBytes(_config["Jwt:secret"]);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new TokenAndMessageReturn
            {
                Token = tokenJson,
                Message = "User Has Been Created Successfully",
                VisitorInformationForReturn = new VisitorInformationForReturn
                {
                    Email = visitorInformation.Email,
                    Governrate = visitorInformation.Governrate,
                    Address = visitorInformation.Address,
                    Phone = visitorInformation.Phone,
                    Name = visitorInformation.Name,
                    Image = GetDirectoryPath.GetImagePath(Request, visitorInformation.Image),
                    IdNumber = visitorInformation.IdNumber
                },
                StatusCode = 201
            });
        }
    }
}
