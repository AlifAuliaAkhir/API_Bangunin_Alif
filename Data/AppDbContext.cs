using bangun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using bangun.Enums;

namespace bangun.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Toko> Toko { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Proyek> Proyeks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProyekProduct> ProyekProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.SatuanBarang)
                .HasConversion<string>();

            modelBuilder.Entity<ProyekProduct>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<ProyekProduct>()
                .HasOne(pp => pp.Proyek)
                .WithMany(p => p.ProyekProducts)
                .HasForeignKey(pp => pp.ProyekId);

            modelBuilder.Entity<ProyekProduct>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.ProyekProducts)
                .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>(); // enum → string

            base.OnModelCreating(modelBuilder);
        }



    }
}