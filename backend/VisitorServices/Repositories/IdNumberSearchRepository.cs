using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorServices.Data;
using VisitorServices.Entities;

namespace VisitorServices.Repositories
{
    public class IdNumberSearchRepository : IIdNumberSearchRepository
    {
        private readonly ApplicationDbContext _db;

        public IdNumberSearchRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public VisitorInformation SearchByIdNumber(string idNumber)
        {
            var visitor = _db.VisitorInformations.SingleOrDefault(v => v.IdNumber == idNumber);
            return visitor;
        }
    }
}
