using Microsoft.EntityFrameworkCore;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess
{
    public class PharmacyDBContext(DbContextOptions<PharmacyDBContext> options) : DbContext(options)
    {
        public DbSet<Medicine_Entity> medicines { get; set; }

        public DbSet<Worker_Entity> pharmacists { get; set; }

        public DbSet<Customer_Entity> customers { get; set; }

        public DbSet<Recipe_Entity> recipes { get; set; }

        public DbSet<Sale_Entity> sales { get; set; }

        public DbSet<User_Entity> users { get; set; }
    }
}
