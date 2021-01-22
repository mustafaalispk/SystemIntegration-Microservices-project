using System.Collections.Generic;

namespace FreakyFashionServices.Gateway.Models.DTO
{
    public class CreateBasketDto
    {        
        public string CustomerIdentifier { get; set; } 
        public IList<BasketItemDto> Items { get; set; }
        
    }
}

