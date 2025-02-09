using System.Collections.Generic;
using SalesDatePrediction.Api.Controllers;
using SalesDatePrediction.Api.Dtos;
using SalesDatePrediction.Api.Repositories;

namespace SalesDatePrediction.Api.Services
{
    public class TransportistaService
    {
        private readonly TransportistaRepository _repository;

        public TransportistaService(TransportistaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TransportistaDto> GetTransportistas()
        {
            return _repository.GetTransportistas();
        }
    }
}
