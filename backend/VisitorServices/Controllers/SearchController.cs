using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VisitorServices.Entities;
using VisitorServices.Helpers;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SearchController : Controller
    {
        private readonly IIdNumberSearchRepository _repo;
        private readonly IConfiguration _config;

        public SearchController(IIdNumberSearchRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet("{idNumber}")]
        public ActionResult<TokenAndMessageReturn> SearchByIdNumber(string idNumber)
        {
            TokenAndMessageReturn tokenAndMessageReturn = null;
            if (idNumber == null)
            {
                return BadRequest();
            }

            var visitor = _repo.SearchByIdNumber(idNumber);

            if (visitor == null)
            {
                tokenAndMessageReturn = new TokenAndMessageReturn
                {
                    Token = null,
                    Message = "User Not Found",
                    VisitorInformationForReturn = null,
                    StatusCode = 404
                };

                return NotFound(tokenAndMessageReturn);
            }
            var userBind = _repo.SearchInBindUser(idNumber, visitor.Id);

            if (userBind != null)
            {
                tokenAndMessageReturn = new TokenAndMessageReturn
                {
                    Token = null,
                    Message = "User Is Blocked because"+userBind.Reason,
                    VisitorInformationForReturn = null,
                    StatusCode = 422
                };

                return UnprocessableEntity(tokenAndMessageReturn);
            }
            else
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, idNumber),
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

                tokenAndMessageReturn = new TokenAndMessageReturn
                {
                    Token = tokenJson,
                    Message = "User Found",
                    VisitorInformationForReturn = new VisitorInformationForReturn
                    {
                        Name = visitor.Name,
                        Email = visitor.Email,
                        Governrate = visitor.Governrate,
                        Address = visitor.Address,
                        IdNumber = idNumber,
                        Image = GetDirectoryPath.GetImagePath(Request, visitor.Image),
                        Phone = visitor.Phone
                    },
                    StatusCode = 200
                };
                return Ok(tokenAndMessageReturn);

            }

        }
    }
}
