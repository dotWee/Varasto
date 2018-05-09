using System;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Model;

namespace Varasto.Core.Database
{
    public class DatabaseContext : DbContext
    {   
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: Globals.SchemaName);
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Products);

            base.OnModelCreating(modelBuilder);
        }
    }
}