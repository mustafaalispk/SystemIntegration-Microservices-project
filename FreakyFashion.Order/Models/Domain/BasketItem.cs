namespace FreakyFashion.Order.Models.Domain
{
    public class BasketItem
    {       
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }        
    }
}
