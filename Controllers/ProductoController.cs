using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly string? _connectionString;

        public ProductoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var productos = connection.Query<ProductoDto>(
                    "SELECT \r\n    productid As 'Productid', \r\n    productname As 'Productname'\r\nFROM Production.Products;"
                ).ToList();
                return Ok(productos);
            }
        }
    }
}

