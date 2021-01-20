using System.Collections.Generic;

namespace FreakyFashion.Order.Models.Domain
{
    public class CutomerOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
