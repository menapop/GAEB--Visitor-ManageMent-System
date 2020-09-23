using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorServices.Entities;

namespace VisitorServices.Repositories
{
    public interface IIdNumberSearchRepository
    {
        VisitorInformation SearchByIdNumber(string idNumber);
        BindUser SearchInBindUser(string idNumber, int visitorId);
    }
}
