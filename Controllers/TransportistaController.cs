using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController : ControllerBase
    {
        private readonly string? _connectionString;

        public TransportistaController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetTransportistas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var transportistas = connection.Query<TransportistaDto>(
                    "SELECT \r\n    shipperid As 'Shipperid', \r\n    companyname As 'Companyname'\r\nFROM Sales.Shippers;"
                ).ToList();
                return Ok(transportistas);
            }
        }
    }
}
