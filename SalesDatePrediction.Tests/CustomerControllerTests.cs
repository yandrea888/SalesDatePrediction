using Xunit;
using SalesDatePrediction.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SalesDatePrediction.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomers_ReturnsListOfCustomers()
        {
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.GetCustomers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);  // Verifica que el resultado sea un OkObjectResult
            var customers = Assert.IsType<List<Customer>>(okResult.Value);  // Verifica que el valor sea una lista de Customer
            Assert.NotEmpty(customers);  // Verifica que la lista no esté vacía
        }
    }
}

