using FreakyFashion.Order.Data;
using FreakyFashion.Order.Models.Domain;
using FreakyFashion.Order.Models.DTO;
using FreakyFashionServices.Order.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashion.Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly OrderContext _context;
        public OrderController(IHttpClientFactory clientFactory, OrderContext context)
        {
            this.clientFactory = clientFactory;
            _context = context;
        }              

        [HttpPost]
        public async Task<IActionResult> CreateOrder(PostOrderDto postOrderDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.basket/Basket/" + postOrderDto.CustomerIdentifier);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var serializedBasketData = await response.Content.ReadAsStringAsync();

                var serializedOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var basketInformation = JsonSerializer.Deserialize<CreateBasketDto>(serializedBasketData, serializedOptions);

                CustomerOrder customerOrder = new CustomerOrder();

                customerOrder.FirstName = postOrderDto.FirstName;

                customerOrder.LastName = postOrderDto.LastName;

                customerOrder.OrderId = postOrderDto.CustomerIdentifier;

                foreach(var item in basketInformation.Items)
                {
                    BasketItem basketItem = new BasketItem();

                    basketItem.ProductId = item.ProductId;

                    basketItem.ProductName = item.ProductName;

                    basketItem.UnitPrice = item.UnitPrice;

                    basketItem.Quantity = item.Quantity;

                    customerOrder.Items.Add(basketItem);
                }

                _context.Add(customerOrder);

                _context.SaveChanges();

                return Ok(customerOrder.Id);
                
               }

            return NotFound();                       

        }
        
    }
}
