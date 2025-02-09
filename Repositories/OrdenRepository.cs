using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace SalesDatePrediction.Api.Repositories
{
    public class OrdenRepository
    {
        private readonly string _connectionString;

        public OrdenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<dynamic> ObtenerOrdenesPorCliente(int customerId)
        {
            const string query = @"
                SELECT 
                    orderid AS OrderId, 
                    requireddate AS RequiredDate, 
                    shippeddate AS ShippedDate, 
                    shipname AS ShipName, 
                    shipaddress AS ShipAddress, 
                    shipcity AS ShipCity 
                FROM Sales.Orders
                WHERE custid = @CustomerId";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query(query, new { CustomerId = customerId }).ToList();
            }
        }
    }
}
