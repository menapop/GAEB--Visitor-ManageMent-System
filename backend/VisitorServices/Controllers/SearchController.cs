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
    [Route("search")]
    public class SearchController : Controller
    {
        private readonly IdNumberSearchRepository _repo;

        public SearchController(IdNumberSearchRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<VisitorInformation>> SearchByIdNumber(string idNumber)
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
