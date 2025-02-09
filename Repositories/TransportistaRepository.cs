using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Controllers;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Repositories
{
    public class TransportistaRepository
    {
        private readonly string _connectionString;

        public TransportistaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TransportistaDto> GetTransportistas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<TransportistaDto>(
                    "SELECT shipperid AS 'Shipperid', companyname AS 'Companyname' FROM Sales.Shippers;"
                ).ToList();
            }
        }
    }
}
