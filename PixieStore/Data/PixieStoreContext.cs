using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PixieStore.Models;

namespace PixieStore.Data
{
    public class PixieStoreContext : DbContext
    {
        public PixieStoreContext (DbContextOptions<PixieStoreContext> options)
            : base(options)
        {
        }

        public DbSet<PixieStore.Models.Contactus> Contactus { get; set; }
        public DbSet<PixieStore.Models.Subscriber> Subscriber { get; set; }
        public DbSet<PixieStore.Models.ProductTag> ProductTag { get; set; }
        public DbSet<PixieStore.Models.productCategory> productCategory { get; set; }
    }
}
