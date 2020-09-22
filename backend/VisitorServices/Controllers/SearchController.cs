using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitorServices.Entities;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SearchController : Controller
    {
        private readonly IIdNumberSearchRepository _repo;

        public SearchController(IIdNumberSearchRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{idNumber}")]
        public ActionResult<VisitorInformationForReturnStatus> SearchByIdNumber(string idNumber)
        {
            VisitorInformationForReturnStatus visitorInformationForReturnStatus = null;
            if (idNumber == null)
            {
                return BadRequest();
            }

            var visitor = _repo.SearchByIdNumber(idNumber);
            var userBind = _repo.SearchInBindUser(idNumber);

            if (visitor == null)
            {
                visitorInformationForReturnStatus = new VisitorInformationForReturnStatus
                {
                    VisitorInformation = null,
                    Status = "User Not Found"
                };
            }
            else if (userBind != null)
            {
                visitorInformationForReturnStatus = new VisitorInformationForReturnStatus
                {
                    VisitorInformation = visitor,
                    Status = "User is Blocked"
                };
            }
            else
            {
                visitorInformationForReturnStatus = new VisitorInformationForReturnStatus
                {
                    VisitorInformation = visitor,
                    Status = "User Found"
                };
            }

            return visitorInformationForReturnStatus;
        }
    }
}
