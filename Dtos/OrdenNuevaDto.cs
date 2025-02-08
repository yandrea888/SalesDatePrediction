namespace SalesDatePrediction.Api.Dtos
{
    public class OrdenNuevaDto
    {
        public int CustomerId { get; set; }   
        public int EmployeeId { get; set; }   
        public int ShipperId { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;  
        public DateTime RequiredDate { get; set; } = DateTime.Now.AddDays(7);  
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; } = string.Empty;

        // Para el detalle de la orden:
        public int ProductId { get; set; }    
        public int Quantity { get; set; }     
        public decimal UnitPrice { get; set; }  
        public decimal Discount { get; set; } = 0;  
    }
}
