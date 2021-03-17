using Microsoft.EntityFrameworkCore;
using SiteMercadoBackend.Produto.Entities;

namespace SiteMercadoBackend.Produto.Infra.Contexts {

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Product>().ToTable("Products");
            _ = modelBuilder.Entity<Product>().Property(x => x.Id);
            _ = modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            _ = modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired().HasColumnType("decimal").HasDefaultValue(0.00);
            _ = modelBuilder.Entity<Product>().Property(x => x.ImagePath).IsRequired();
        }
    }
}