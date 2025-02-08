using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenNuevaController : ControllerBase
    {
        private readonly string? _connectionString;

        public OrdenNuevaController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public IActionResult CrearOrden([FromBody] OrdenNuevaDto nuevaOrden)
        {
            const string query = @"
                
                DECLARE @NewOrderId INT;


                INSERT INTO Sales.Orders (
                    custid,
                    empid, 
                    shipperid, 
                    shipname, 
                    shipaddress, 
                    shipcity, 
                    orderdate, 
                    requireddate, 
                    shippeddate, 
                    freight, 
                    shipcountry
                )
                VALUES (
                    77,
                    1,                
                    2,                
                    'Sample Shipname',
                    '123 Main St',    
                    'Sample City',    
                    GETDATE(),        
                    DATEADD(DAY, 7, GETDATE()), 
                    NULL,             
                    50.00,            
                    'Sample Country'  
                );

                SET @NewOrderId = SCOPE_IDENTITY();


                INSERT INTO Sales.OrderDetails (
                    orderid, 
                    productid, 
                    unitprice, 
                    qty, 
                    discount
                )
                VALUES 
                    (@NewOrderId, 1, 20.00, 2, 0.05),  
                    (@NewOrderId, 2, 15.00, 1, 0.00);  


                SELECT @NewOrderId AS NewOrderId;

            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var orderId = connection.ExecuteScalar<int>(
                            query,
                            new
                            {
                                nuevaOrden.CustomerId,
                                nuevaOrden.OrderDate,
                                nuevaOrden.ProductId,
                                nuevaOrden.Quantity
                            },
                            transaction: transaction
                        );

                        transaction.Commit();
                        return Ok(new { Message = "Orden creada con éxito", OrderId = orderId });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest(new { Message = "Error al crear la orden", Error = ex.Message });
                    }
                }
            }
        }
    }
}
