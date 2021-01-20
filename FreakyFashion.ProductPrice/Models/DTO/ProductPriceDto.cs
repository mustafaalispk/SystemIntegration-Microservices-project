using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashion.ProductPrice.Models.DTO
{
    public class ProductPriceDto
    {
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public ProductPriceDto(string articleNumber)
        {
            this.ArticleNumber = articleNumber;

            Random random = new Random();

            Price = random.Next(1, 200);

        }
    }
}
