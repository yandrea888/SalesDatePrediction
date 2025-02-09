using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Api.Dtos;
using System;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenNuevaController : ControllerBase
    {
        private readonly OrdenNuevaService _ordenService;

        public OrdenNuevaController(OrdenNuevaService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpPost]
        public IActionResult CrearOrden()
        {
            try
            {
                int newOrderId = _ordenService.CrearOrden();
                return Ok(new { message = "Orden creada exitosamente", newOrderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear la orden", error = ex.Message });
            }
        }
    }
}

