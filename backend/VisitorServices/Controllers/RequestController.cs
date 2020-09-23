using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Clauses.ResultOperators;
using VisitorServices.Repositories;
using VisitorServices.ViewModels;

namespace VisitorServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ICenteralDepartmentRepository _CenteralDepartmentRepository;
        private readonly IEmployeeRepository _EmployeeRepository;

        public RequestController(ICenteralDepartmentRepository CenteralDepartmentRepository, IEmployeeRepository EmployeeRepository)
        {
            _CenteralDepartmentRepository = CenteralDepartmentRepository;
            _EmployeeRepository = EmployeeRepository;
        }
        [HttpGet]
        [Route("GetCentralDepartments")]
        public async Task<ActionResult<IEnumerable<CenteralDepartmentViewModel>>> GetCentralDepartments()
        {
            try
            {
                var res = await  _CenteralDepartmentRepository.GetCenteralDepartments();
               return Ok(res);

                
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
                var res = await _EmployeeRepository.GetEmployeesByCenteralDepartment(code);

                return Ok(res);


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
                var res = await _EmployeeRepository.GetEmployeeEmailByEmployeeNumber(EmployeeNumber);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
