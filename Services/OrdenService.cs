using SalesDatePrediction.Api.Repositories;
using System.Collections.Generic;

namespace SalesDatePrediction.Api.Services
{
    public class OrdenService
    {
        private readonly OrdenRepository _ordenRepository;

        public OrdenService(OrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        public IEnumerable<dynamic> ObtenerOrdenesPorCliente(int customerId)
        {
            return _ordenRepository.ObtenerOrdenesPorCliente(customerId);
        }
    }
}
