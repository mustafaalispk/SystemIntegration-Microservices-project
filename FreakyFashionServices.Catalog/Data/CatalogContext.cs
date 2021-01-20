using FreakyFashionServices.Catalog.Entites;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Catalog.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<Items> Item { get; set; }
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }      
       
    }
}
