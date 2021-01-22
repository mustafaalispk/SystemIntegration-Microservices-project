using System.Collections.Generic;

namespace FreakyFashionServices.Order.Models.DTO
{
    public class CreateBasketDto
    {        
        public string CustomerIdentifier { get; set; } 
        public IList<BasketItemDto> Items { get; set; }
        
    }
}

