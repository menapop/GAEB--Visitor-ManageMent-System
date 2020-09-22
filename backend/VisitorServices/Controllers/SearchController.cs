using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VisitorServices.Entities;
using VisitorServices.Repositories;

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
        public ActionResult<VisitorInformation> SearchByIdNumber(string idNumber)
        {
            if (idNumber == null)
            {
                return BadRequest();
            }

            var visitor = _repo.SearchByIdNumber(idNumber);

            if (visitor == null)
            {
                return NotFound();
            }

            return visitor;
        }
    }
}
