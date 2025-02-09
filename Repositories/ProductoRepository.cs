using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SalesDatePrediction.Api.Repositories
{
    public class ProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductoDto> GetProductos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"
                    SELECT 
                        productid AS ProductId,
                        productname AS ProductName
                    FROM Production.Products;
                ";

                return connection.Query<ProductoDto>(query).ToList();
            }
        }
    }
}
