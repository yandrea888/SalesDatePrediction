using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SalesDatePrediction.Api.Repositories
{
    public class EmpleadoRepository
    {
        private readonly string _connectionString;

        public EmpleadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EmpleadoDto> ObtenerEmpleados()
        {
            const string query = @"
                SELECT 
                    empid AS Empid, 
                    firstname + ' ' + lastname AS FullName
                FROM HR.Employees;
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<EmpleadoDto>(query).ToList();
            }
        }
    }
}
