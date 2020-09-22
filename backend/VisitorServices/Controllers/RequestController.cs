using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        string _LookUpsconnectionString, _EmployeeconnectionString;
        public RequestController(IConfiguration configuration)
        {
            _configuration = configuration;
            _LookUpsconnectionString = _configuration.GetConnectionString("LookUpsDB");
            _EmployeeconnectionString= _configuration.GetConnectionString("EmployeeDB");
        }
        [HttpGet]
        [Route("GetCentralDepartments")]
        public async Task<ActionResult<IEnumerable<CenteralDepartmentViewModel>>> GetCentralDepartments()
        {
            try
            {
                using (var connection = new SqlConnection(_LookUpsconnectionString))
                {
                    connection.Open();
                    string qr = @" select * from CentralDepartments 
                       ";
                    var res = await connection.QueryAsync<CenteralDepartmentViewModel>(qr);
                    return Ok(res);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("GetEmployeesbyCentralDepartmentCode/{code}")]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetEmployeesbyCentralDepartmentCode(string code)
        {
            try
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
                    var res = await connection.QueryAsync<EmployeeViewModel>(qr,parameters);
                    return Ok(res);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet]
        [Route("GetEmployeeEmail/{EmployeeNumber}")]
        public async Task<ActionResult<string>> GetEmployeeEmail(int EmployeeNumber)
        {
            try
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
                    var res = await connection.QuerySingleAsync(qr, parameters);
                    return Ok(res);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
