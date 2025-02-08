using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SalesDatePrediction.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" }
            };

            return Ok(customers);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
    }
}
