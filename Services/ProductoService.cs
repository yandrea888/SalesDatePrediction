using SalesDatePrediction.Api.Dtos;
using SalesDatePrediction.Api.Repositories;
using System.Collections.Generic;

namespace SalesDatePrediction.Api.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<ProductoDto> GetProductos()
        {
            return _productoRepository.GetProductos();
        }
    }
}

