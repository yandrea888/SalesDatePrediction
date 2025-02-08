using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {        
        private readonly string? _connectionString;


        public ClienteController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetClientesConUltimaYProximaOrden()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var clientes = connection.Query("WITH OrderIntervals AS (\r\n    SELECT \r\n        o.custid,\r\n        DATEDIFF(DAY, \r\n                 LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate), \r\n                 o.orderdate\r\n        ) AS IntervalDays\r\n    FROM \r\n        Sales.Orders o\r\n),\r\nAverageIntervals AS (\r\n    SELECT \r\n        oi.custid,\r\n        AVG(oi.IntervalDays) AS AvgIntervalDays\r\n    FROM \r\n        OrderIntervals oi\r\n    WHERE \r\n        oi.IntervalDays IS NOT NULL\r\n    GROUP BY \r\n        oi.custid\r\n),\r\nLastOrders AS (\r\n    SELECT \r\n        o.custid,\r\n        MAX(o.orderdate) AS LastOrderDate\r\n    FROM \r\n        Sales.Orders o\r\n    GROUP BY \r\n        o.custid\r\n)\r\nSELECT \r\n    c.companyname AS CustomerName,\r\n    lo.LastOrderDate,\r\n    DATEADD(DAY, ISNULL(ai.AvgIntervalDays, 0), lo.LastOrderDate) AS NextPredictedOrder\r\nFROM \r\n    Sales.Customers c\r\nJOIN \r\n    LastOrders lo ON c.custid = lo.custid\r\nLEFT JOIN \r\n    AverageIntervals ai ON c.custid = ai.custid\r\nORDER BY \r\n    c.companyname;\r\n\r\n").ToList();
                return Ok(clientes);
            }
        }
    }
}

