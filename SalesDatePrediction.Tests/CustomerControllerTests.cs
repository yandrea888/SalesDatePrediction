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
            var controller = new CustomerController();

            var result = controller.GetCustomers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var customers = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.NotEmpty(customers);
        }
    }
}
