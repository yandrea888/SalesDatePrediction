using SalesDatePrediction.Api.Repositories;
using System.Collections.Generic;

namespace SalesDatePrediction.Api.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<dynamic> ObtenerClientesConPrediccion()        {
            
            return _clienteRepository.ObtenerClientesConUltimaYProximaOrden();
        }
    }
}

