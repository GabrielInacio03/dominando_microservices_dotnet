using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }


        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 2, Name = "Product 1", Price = 10.0m, Description = "Description for Product 1", CategoryName = "Category 1", ImageUrl = "https://example.com/product1.jpg" },
                new Product { Id = 3, Name = "Product 2", Price = 20.0m, Description = "Description for Product 2", CategoryName = "Category 2", ImageUrl = "https://example.com/product2.jpg" },
                new Product { Id = 4, Name = "Product 3", Price = 30.0m, Description = "Description for Product 3", CategoryName = "Category 3", ImageUrl = "https://example.com/product3.jpg" }
            );
        }
        
    }
}