using SalesDatePrediction.Api.Dtos;

public class OrdenNuevaService
{
    private readonly OrdenNuevaRepository _ordenRepository;

    public OrdenNuevaService(OrdenNuevaRepository ordenRepository)
    {
        _ordenRepository = ordenRepository;
    }

    public int CrearOrden()
    {
        return _ordenRepository.CrearOrden();
    }
}
