using Microsoft.EntityFrameworkCore;
using VehicleServiceAPI.Models;

namespace VehicleServiceAPI.Data
{
    public class VehicleTestDriveDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleTestDriveDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\SQLExpress;database=VehiclesDb;TrustServerCertificate=True;integrated Security=SSPI;");
        }
    }
}
