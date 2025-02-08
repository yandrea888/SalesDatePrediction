using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;


namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly string? _connectionString;

        public OrdenController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("{customerId}")]
        public IActionResult GetOrdenesPorCliente(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
                    SELECT 
                        orderid AS OrderId, 
                        requireddate AS RequiredDate, 
                        shippeddate AS ShippedDate, 
                        shipname AS ShipName, 
                        shipaddress AS ShipAddress, 
                        shipcity AS ShipCity 
                    FROM Sales.Orders
                    WHERE custid = @CustomerId";

                var ordenes = connection.Query(query, new { CustomerId = customerId }).ToList();

                if (ordenes.Count == 0)
                {
                    return NotFound($"No se encontraron órdenes para el cliente con ID {customerId}.");
                }

                return Ok(ordenes);
            }
        }
    }
}
