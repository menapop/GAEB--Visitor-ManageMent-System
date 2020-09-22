using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RegisterVisitorController : Controller
    {
        private readonly IAddVisitorInformationRepository _repo;

        public RegisterVisitorController(IAddVisitorInformationRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<VisitorInformationViewModel> PostVisitorInformation([FromForm]VisitorInformationViewModel visitorInformationViewModel)
        {
            if (visitorInformationViewModel == null)
            {
                return BadRequest();
            }
            var visitorInformation = _repo.AddVisitorInformation(visitorInformationViewModel);
            return visitorInformation;
        }
    }
}
