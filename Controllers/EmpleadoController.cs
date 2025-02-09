using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using SalesDatePrediction.Api.Dtos;

using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Api.Services;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public IActionResult GetEmpleados()
        {
            var empleados = _empleadoService.ObtenerEmpleados();
            return Ok(empleados);
        }
    }
}

