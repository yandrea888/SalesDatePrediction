using Dapper;
using Microsoft.Data.SqlClient;
using SalesDatePrediction.Api.Dtos;
using System;

public class OrdenNuevaRepository
{
    private readonly string _connectionString;

    public OrdenNuevaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public int CrearOrden()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = @"
            DECLARE @NewOrderId INT;

            INSERT INTO Sales.Orders (
                custid, empid, shipperid, shipname, shipaddress, 
                shipcity, orderdate, requireddate, shippeddate, freight, shipcountry
            )
            VALUES (
                @CustomerId, @EmployeeId, @ShipperId, @ShipName, @ShipAddress,
                @ShipCity, GETDATE(), DATEADD(DAY, 7, GETDATE()), NULL, @Freight, @ShipCountry
            );

            SET @NewOrderId = SCOPE_IDENTITY();

            INSERT INTO Sales.OrderDetails (
                orderid, productid, unitprice, qty, discount
            )
            VALUES 
                (@NewOrderId, @ProductId1, @UnitPrice1, @Qty1, @Discount1),
                (@NewOrderId, @ProductId2, @UnitPrice2, @Qty2, @Discount2);

            SELECT @NewOrderId AS NewOrderId;
        ";

            using (var command = new SqlCommand(query, connection))
            {
                // Agregar parámetros para la orden
                command.Parameters.AddWithValue("@CustomerId", 77);
                command.Parameters.AddWithValue("@EmployeeId", 1);
                command.Parameters.AddWithValue("@ShipperId", 2);
                command.Parameters.AddWithValue("@ShipName", "Sample Shipname");
                command.Parameters.AddWithValue("@ShipAddress", "123 Main St");
                command.Parameters.AddWithValue("@ShipCity", "Sample City");
                command.Parameters.AddWithValue("@Freight", 50.00);
                command.Parameters.AddWithValue("@ShipCountry", "Sample Country");

                // Agregar parámetros para los detalles de la orden
                command.Parameters.AddWithValue("@ProductId1", 1);
                command.Parameters.AddWithValue("@UnitPrice1", 20.00);
                command.Parameters.AddWithValue("@Qty1", 2);
                command.Parameters.AddWithValue("@Discount1", 0.05);

                command.Parameters.AddWithValue("@ProductId2", 2);
                command.Parameters.AddWithValue("@UnitPrice2", 15.00);
                command.Parameters.AddWithValue("@Qty2", 1);
                command.Parameters.AddWithValue("@Discount2", 0.00);

                connection.Open();
                return (int)command.ExecuteScalar(); 
            }
        }
    }

}




