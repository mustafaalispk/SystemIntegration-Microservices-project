using FreakyFashionServices.Catalog.Data;
using FreakyFashionServices.Catalog.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _context;
        public CatalogController(CatalogContext context)
        {
            _context = context;
        }

        //GET /api/catalog/items
        [HttpGet("{items}")]
        public IEnumerable<Items> GetAll()
        {
            var items = _context.Item.ToList();

            return items;
        }

        //GET /api/catalog/items/{id}
        [HttpGet("{items}/{id}")]
        public ActionResult<Items> GetById(int id)
        {
            var item = _context.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound(); // 404 Not Found
            }
            return item;
        }

    }
}
