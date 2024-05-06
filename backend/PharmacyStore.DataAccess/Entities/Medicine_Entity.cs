using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyStore.DataAccess.Entities
{
    public class Medicine_Entity
    {
        [Key]
        [Column("medicine_code")]
        public Guid Medicine_Code { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("type")]
        public string Type { get; set; } = string.Empty;
        [Column("category")]
        public string Category { get; set; } = string.Empty;
        [Column("price")]
        public decimal Price { get; set; }
    }
}
