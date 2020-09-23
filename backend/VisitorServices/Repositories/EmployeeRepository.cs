using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        string _EmployeeconnectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _EmployeeconnectionString = _configuration.GetConnectionString("EmployeeDB");
        }

        public async Task<string> GetEmployeeEmailByEmployeeNumber(int EmployeeNumber)
        {
            using (var connection = new SqlConnection(_EmployeeconnectionString))
            {
                connection.Open();
                string qr = @" select  Email from employeedata 
                           where EmployeeNumber=@EmployeeNumber ";
                var dictionary = new Dictionary<string, object>
                    {
                         {
                            "@EmployeeNumber", EmployeeNumber
                         },

                        };
                var parameters = new DynamicParameters(dictionary);
                var res = await connection.QuerySingleAsync<string>(qr, parameters);
                return res;

            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeesByCenteralDepartment(string code)
        {
            using (var connection = new SqlConnection(_EmployeeconnectionString))
            {
                connection.Open();
                string qr = @" select EmployeeNumber, EmployeeName from employeedata 
                       where CentralAdministration=@CentralAdministration ";
                var dictionary = new Dictionary<string, object>
                {
                     {
                        "@CentralAdministration", code
                     },

                     };
                var parameters = new DynamicParameters(dictionary);
                var res = await connection.QueryAsync<EmployeeViewModel>(qr, parameters);
                return res;
            }
        }
    }
}
