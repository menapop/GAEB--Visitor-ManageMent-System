using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
   public interface ICenteralDepartmentRepository
    {
        Task<IEnumerable<CenteralDepartmentViewModel>> GetCenteralDepartments();
       
    }
}
