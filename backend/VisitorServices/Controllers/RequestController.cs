using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace VisitorServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        string _connectionString;
        public RequestController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString= _configuration.GetConnectionString("MyConnectionString");
        }
        [HttpGet]
        [Route("GetCentralDepartments")]
        public async Task<ActionResult<IEnumerable<TenderSchoolDto>>> GetCentralDepartments(GetTenderSchoolDto model)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string qr = @" SELECT * FROM TenderSchoolView where TenderId=@TenderId and 
                    Cast(ReleaseDate as Date)>=  Cast(@From as Date )and 
                    Cast(ReleaseDate as Date)<=Cast(@To as Date )
                     ";

                    var dictionary = new Dictionary<string, object>
                {
                     {
                        "@TenderId",model.TenderId
                     },
                     {
                        "@From",model.From
                     },
                     {
                        "@To",model.To
                     },

                };
                    var parameters = new DynamicParameters(dictionary);

                    var res = await connection.QueryAsync<TenderSchoolDto>(qr, parameters);
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
