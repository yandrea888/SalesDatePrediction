using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly string? _connectionString;

        public EmpleadoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetEmpleados()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var empleados = connection.Query<EmpleadoDto>("SELECT \r\n    empid As 'Empid', \r\n    firstname + ' ' + lastname AS FullName\r\nFROM HR.Employees;").ToList();
                return Ok(empleados);
            }
        }
    }
}
