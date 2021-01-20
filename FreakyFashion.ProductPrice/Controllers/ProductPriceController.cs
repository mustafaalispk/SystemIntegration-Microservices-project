using FreakyFashion.ProductPrice.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashion.ProductPrice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPriceController : ControllerBase
    {       

        [HttpGet]
        public ActionResult <IEnumerable<ProductPriceDto>> GetProducts(string products)
        {
            var articleNumbers = products.Split(',');

            List<ProductPriceDto> productPrices = new List<ProductPriceDto>();

            foreach(var articlenumber in articleNumbers)
            {
                productPrices.Add(new ProductPriceDto(articlenumber));
            }
            return Ok(productPrices);
            
        }
    }
}
