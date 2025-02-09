using SalesDatePrediction.Api.Dtos;
using SalesDatePrediction.Api.Repositories;
using System.Collections.Generic;

namespace SalesDatePrediction.Api.Services
{
    public class EmpleadoService
    {
        private readonly EmpleadoRepository _empleadoRepository;

        public EmpleadoService(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public IEnumerable<EmpleadoDto> ObtenerEmpleados()
        {
            return _empleadoRepository.ObtenerEmpleados();
        }
    }
}
