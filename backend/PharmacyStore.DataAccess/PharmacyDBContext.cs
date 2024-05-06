using Microsoft.EntityFrameworkCore;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess
{
    public class PharmacyDBContext(DbContextOptions<PharmacyDBContext> options) : DbContext(options)
    {
        public DbSet<Medicine_Entity> medicines { get; set; }

        public DbSet<Worker_Entity> pharmacists { get; set; }

        public DbSet<Customer_Entity> customers { get; set; }
    }
}
