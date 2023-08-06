using Microsoft.EntityFrameworkCore;
using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoMarket.Data
{
    public class EshopContext:DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
