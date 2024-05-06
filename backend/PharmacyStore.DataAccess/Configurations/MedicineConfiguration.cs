
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine_Entity>
    {
        public void Configure(EntityTypeBuilder<Medicine_Entity> builder)
        {
            builder.HasKey(x => x.Medicine_Code); 
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Type).IsRequired();
            builder.Property(b => b.Category).IsRequired();
            builder.Property(b => b.Price).IsRequired();
        }
    }
}
