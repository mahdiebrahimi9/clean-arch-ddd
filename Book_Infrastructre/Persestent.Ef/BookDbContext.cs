using Book_Domain.Orders;
using Book_Domain.OrdersAgg;
using Book_Domain.Products;
using Book_Domain.ProductsAgg;
using Book_Domain.Users;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<OrderItem>().OwnsOne(p => p.Price, option =>
            {
                option.Property(p => p.Value).HasColumnName("RialPrice");
            });
            modelBuilder.Entity<Product>().OwnsOne(p => p.Money);
            modelBuilder.Entity<User>().OwnsOne(p => p.PhoneNumber);

            base.OnModelCreating(modelBuilder);
        }
    }
}
