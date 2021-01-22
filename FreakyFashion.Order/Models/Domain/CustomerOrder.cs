using System.Collections.Generic;

namespace FreakyFashion.Order.Models.Domain
{
    public class CustomerOrder
    {    
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
