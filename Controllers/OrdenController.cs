using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Services;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetOrdenesPorCliente(int customerId)
        {
            var ordenes = _ordenService.ObtenerOrdenesPorCliente(customerId);

            if (ordenes == null || !ordenes.Any())
            {
                return NotFound($"No se encontraron órdenes para el cliente con ID {customerId}.");
            }

            return Ok(ordenes);
        }
    }
}

