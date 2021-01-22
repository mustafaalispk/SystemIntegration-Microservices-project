using FeakyFashion.Gateway.Models.DTO;
using FreakyFashion.Gateway.Models.DTO;
using FreakyFashionServices.Gateway.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeakyFashion.Gateway.Controllers
{
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        
        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;            
        }

        [HttpGet]
        [Route("/api/products")]
        public async Task<IActionResult> GetAllItems()
        {
            // TODO: Hämta Items-information från (text: /api/catalog)  

            var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.catalog/api/catalog/Items");

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var serializedItems = await response.Content.ReadAsStringAsync();

                var serializedOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var itemsDto = JsonSerializer.Deserialize<IList<ItemsDto>>(serializedItems, serializedOptions);

                string ariticleIdString = "";

                foreach (var catalogId in itemsDto)
                {
                    ariticleIdString += catalogId.Id.ToString() + ",";
                }

                // TODO: Hämta Basket-information från (text: /api/productprice)     

                request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashion.productprice/ProductPrice?products=" + ariticleIdString);

                request.Headers.Add("Accept", "application/json");

                response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var serializedBasketInformation = await response.Content.ReadAsStringAsync();                    

                    var basketDto = JsonSerializer.Deserialize<IList<ProductPriceDto>>(serializedBasketInformation, serializedOptions);

                    List<ItemsDto> itemsPrice = new List<ItemsDto>();

                    foreach(var catalogItems in itemsDto)
                    {
                        foreach(var aritcles in basketDto)
                        {
                            if (aritcles.ArticleNumber == catalogItems.Id.ToString())
                            {
                                ItemsDto newItems = new ItemsDto {
                                    Id = catalogItems.Id,
                                    Name = catalogItems.Name,
                                    Description = catalogItems.Description,
                                    Price = aritcles.Price,
                                    availableStock = catalogItems.availableStock
                                };
                                itemsPrice.Add(newItems);
                            }                            
                        }
                    }

                    return Ok(itemsPrice);
                   
                }

            }           
                        

            return NotFound();

        }

        

    }
}
