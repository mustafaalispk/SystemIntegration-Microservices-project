using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models.DTO
{
    public class CreateBasketDto
    {

        // Detta är den unika nyckeln för kundn - (samma som  PUT http://basket/<customerIdentifier>
        public string CustomerIdentifier { get; set; } // anvnd denna sen som nyckel för din kunds basket i redis
        public IList<BasketItemDto> Items { get; set; }

        // TODO: Flyta till BasketItemDto - en basket kan ha flera items i sig (med quantity för varje)        
        //public string ProductId { get; set; }
        //public string ProductName { get; set; }
        //public decimal UnitPrice { get; set; }
        //public decimal Quantity { get; set; }
    }
}


/*
PUT http://basket/<customerIdentifier>

[
   {
        //public string ProductId { get; set; }
        //public string ProductName { get; set; }
        //public decimal UnitPrice { get; set; }
        //public decimal Quantity { get; set; }   
   },
   {
        //public string ProductId { get; set; }
        //public string ProductName { get; set; }
        //public decimal UnitPrice { get; set; }
        //public decimal Quantity { get; set; }}
}
]

 */
