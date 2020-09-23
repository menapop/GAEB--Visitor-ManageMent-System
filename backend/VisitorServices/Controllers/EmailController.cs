using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _EmailRepository;
        public EmailController(IEmailRepository EmailRepository)
        {
            _EmailRepository = EmailRepository;
        }
        [HttpPost]
        [Route("SendEmail")]
        public async  Task<ActionResult<bool>> SendEmail(SendEmailViewModel email)
        {
            try
            {
                var res = await _EmailRepository.SendEmail(email);
                return Ok(res);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
