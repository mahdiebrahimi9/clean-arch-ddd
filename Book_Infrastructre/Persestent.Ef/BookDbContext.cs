using Book_Domain.Orders;
using Book_Domain.OrdersAgg;
using Book_Domain.Products;
using Book_Domain.ProductsAgg;
using Book_Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Infrastructre.Persestent.Ef
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().OwnsOne(p => p.Price, option =>
            {
                option.Property(p => p.Value).HasColumnName("RialPrice");
            });
            modelBuilder.Entity<OrderItem>().OwnsOne(p => p.Price);
            modelBuilder.Entity<User>().OwnsOne(p => p.PhoneNumber);

            base.OnModelCreating(modelBuilder);
        }
    }
}
