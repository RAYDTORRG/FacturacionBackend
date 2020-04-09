using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using slnFacturacionWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace slnFacturacionWeb.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Producto> Producto  { get;set;}
        public DbSet<Item> Item { get; set; }
        public DbSet<Factura> Factura { get; set; }
    }
}
