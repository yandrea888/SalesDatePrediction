using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Services;
using SalesDatePrediction.Api.Dtos;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _productoService.GetProductos();
            return Ok(productos);
        }
    }
}

