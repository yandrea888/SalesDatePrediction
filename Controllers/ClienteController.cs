using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Services;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientesConUltimaYProximaOrden()
        {
            var clientes = _clienteService.ObtenerClientesConPrediccion();
            return Ok(clientes);
        }
    }
}

