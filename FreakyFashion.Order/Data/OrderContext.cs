using FreakyFashion.Order.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashion.Order.Data
{
    public class OrderContext : DbContext
    {
      public DbSet<CutomerOrder> Orders { get; set; }
      public DbSet<BasketItem> BasketItems { get; set; }
      public OrderContext(DbContextOptions<OrderContext> options)
                : base(options)
      {

      }
    }
}
