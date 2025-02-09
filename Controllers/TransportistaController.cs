using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Services;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportistaController : ControllerBase
    {
        private readonly TransportistaService _transportistaService;

        public TransportistaController(TransportistaService transportistaService)
        {
            _transportistaService = transportistaService;
        }

        [HttpGet]
        public IActionResult GetTransportistas()
        {
            var transportistas = _transportistaService.GetTransportistas();
            return Ok(transportistas);
        }
    }
}
