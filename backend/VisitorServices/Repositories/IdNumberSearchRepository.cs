using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorServices.Data;
using VisitorServices.Entities;
using VisitorServices.ViewModels;

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

        public BindUser SearchInBindUser(string idNumber)
        {

            var visitor = SearchByIdNumber(idNumber);
            BindUser bindUser = null;
            if (visitor != null)
            {
                bindUser = _db.BindUsers.SingleOrDefault(v => v.VisitorInformationId == visitor.Id);
            }

            return bindUser;
        }
    }
}
