using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeakyFashion.Gateway.Models.DTO
{
    public class ProductPriceDto
    {
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }
    }
}
