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
    public class CenteralDepartmentRepository : ICenteralDepartmentRepository 
    {
        private readonly IConfiguration _configuration;

        string _LookUpsconnectionString;
        public CenteralDepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _LookUpsconnectionString = _configuration.GetConnectionString("LookUpsDB");
        }

        public async Task<IEnumerable<CenteralDepartmentViewModel>> GetCenteralDepartments()
        {
            using (var connection = new SqlConnection(_LookUpsconnectionString))
            {
                connection.Open();
                string qr = @" select * from CentralDepartments 
                       ";
                var res = await connection.QueryAsync<CenteralDepartmentViewModel>(qr);
                return res.ToList();
            }
        }
    }
}
