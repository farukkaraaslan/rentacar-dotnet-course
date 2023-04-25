using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class RentACarDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSQL_Connection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("PostgreSQL_Connection");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car =>
            {
                car.HasOne<Brand>()
                    .WithMany()// birden fazla aracı temsil eder
                    .HasForeignKey(c => c.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)// markaya baglı aracları silmeden markayı sildirmez.silerkenki davranısı temsil eder
                    .IsRequired();// geçerli bir brandId controlü yapar
            });
            modelBuilder.Entity<Car>(car =>
            {
                car.HasOne<Color>()
                    .WithMany()
                    .HasForeignKey(c=>c.ColorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });
            modelBuilder.Entity<CarImage>(image =>
            {
                image.HasIndex(i => i.CarId).IsDescending().IsUnique(false);
                image.HasOne<Car>()
                    .WithMany()
                    .HasForeignKey(i => i.CarId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });
        }

        //db set yapılmazsa entity clasları veri tabanı nesnesi oludugunu anlamaz
        public DbSet<Car> Cars { get; set; }     
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
