using FreakyFashionServices.Basket.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache cache;
        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        // GET /basket/{customerIdentifier}
        [HttpGet("{customerIdentifier}")]
        public async Task<ActionResult<CreateBasketDto>> GetAllBaskets(string customerIdentifier)
        {
            var serializedBasketData = await cache.GetStringAsync(customerIdentifier);

            if (serializedBasketData == null)
            {
                return NotFound(); // 404 Not Found
            }

            var basketDto = JsonSerializer.Deserialize<CreateBasketDto>(serializedBasketData);

            return Ok(basketDto);
        }

        //POST /basket
        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var options = new DistributedCacheEntryOptions();

            //options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(200);

            //options.SlidingExpiration = TimeSpan.FromSeconds(160);

            var jsonserializedData = JsonSerializer.Serialize(createBasketDto);

            await cache.SetStringAsync(
                createBasketDto.CustomerIdentifier,
                jsonserializedData,
                options);
            return Ok(); // 201 Created
        }
        //PUT /api/basket/{customerIdentifier}
        [HttpPut("{customerIdentifier}")]
        public async Task<IActionResult> UpdateBasket(string customerIdentifier, CreateBasketDto createBasketDto)
        {           

            var jsonserializedData = JsonSerializer.Serialize(createBasketDto);

            await cache.SetStringAsync(customerIdentifier, jsonserializedData);

            return NoContent(); // 204 No Content

        }

    }
}
