namespace SalesDatePrediction.Api.Dtos
{
    public class ClienteDto
    {
        public string CustomerName { get; set; } = string.Empty;  
        public DateTime? LastOrderDate { get; set; }             
        public DateTime? NextPredictedOrder { get; set; }
    }
}
