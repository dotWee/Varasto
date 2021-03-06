﻿using System;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Model;

namespace Varasto.Core.Database
{
    public class DatabaseContext : DbContext
    {   
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageEntry> StorageEntries { get; set; }

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
            
            modelBuilder.Entity<Storage>()
                .HasMany(s => s.StorageEntries)
                .WithOne(e => e.Storage)
                .HasForeignKey(e => e.StorageId);
            
            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}