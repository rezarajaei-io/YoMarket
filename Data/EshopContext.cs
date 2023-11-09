using Microsoft.EntityFrameworkCore;
using YoMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Models;

namespace YoMarket.Data
{
    public class EshopContext:DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(k => new { k.ProductId, k.CategoryId });

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(p => p.Price).HasColumnType("Money");
                i.HasKey(p => p.Id);
            });
            #region SeedData Category
            modelBuilder.Entity<Category>().HasData(
                new Category() 
                {
                    Id = 1,
                    Name = "کراتین",
                    Descripton = "مکمل ورزشی کراتین مونوهیدرات", 
                },

                new Category()
                {
                    Id = 2,
                    Name = "پروتئین",
                    Descripton = "انواع پروتئین نظیر پروتئین وی ,کازئین , ام پی سی",
                },
                new Category()
                {
                    Id = 3,
                    Name = "گینر",
                    Descripton = "انواع گینر های مس و ویت با طعم های مختلف",
                }
                );

            modelBuilder.Entity<Item>().HasData(
                 new Item()
                 { Id = 1,
                   Price= 1400,
                   QuantityInStock = 6
                 },

                 new Item()
                 {
                     Id = 2,
                     Price = 2000,
                     QuantityInStock = 8,
                 },
                 new Item()
                 {
                     Id = 3,
                     Price =3500,
                     QuantityInStock = 4,
                 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "سوپر کراتین pnc",
                    Description = "سوپر کراتین pnc کراتین انسولین دار شناخته میشود و حاوی گلوتامین است",
                },

                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "مکمل وی applied",
                    Description = "وی صد درصد اپلاید نوتریشن دارای 90 درصد پروتئین",
                },

                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "گینر Super Huge",
                    Description = "حاوی کراتین! گینر مس 4 کیلویی ایوژن دارای نسبت پروتئین به کربو 3 به 1",
                }
                );

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 }

                );

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
