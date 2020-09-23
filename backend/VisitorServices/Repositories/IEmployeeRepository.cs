using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployeesByCenteralDepartment(string code);
        Task<string> GetEmployeeEmailByEmployeeNumber(int EmpNum);
    }
}
