using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyStore.DataAccess.Entities
{
    public class Sale_Entity
    {
        [Key]
        [Column("sales_id")]
        public Guid Sale_Id { get; set; }
        [Column("sale_date")]
        public DateTime Sale_Date { get; set; } = DateTime.MinValue;
        [Column("medicine_code")]
        public Guid Medicine_Code { get; set; }
        [Column("quantity")]
        public int Count { get; set; }
        [Column("recipe_id")]
        public Guid Recipe_Id { get; set; }
        [Column("pharmacists_code")]
        public Guid Worker_Id { get; set; }
    }
}
