using GenericClassesForPatients.Entity;
using Microsoft.EntityFrameworkCore;

namespace GenericClassesForPatients.Data
{
    public class StorageAppDbContext : DbContext
    {
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Hospital> Hospitals => Set<Hospital>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
