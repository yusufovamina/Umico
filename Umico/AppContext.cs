using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umico
{
    public class AppContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<PickUpPoint> PickUpPoints { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        public AppContext()
        {
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-0LP9EBH; Initial Catalog = Umico; TrustServerCertificate=true; Integrated Security = true;");
            //  "Data Source = STHQ012E-09; Database=LibraryProject; TrustServerCertificate=true; Integrated Security = false; User Id = admin; Password = admin;"
        }
    }
}
