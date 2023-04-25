using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //db set yapılmazsa entityclasları veri tabanı nesnesi oludugunu anlamaz
        public DbSet<Car> Cars { get; set; }     
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
     
    }
}
