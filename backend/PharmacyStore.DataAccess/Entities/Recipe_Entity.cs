using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PharmacyStore.DataAccess.Entities
{
    public class Recipe_Entity
    {
        [Key]
        [Column("recipe_id")]
        public Guid Recipe_Id { get; set; }
        [Column("customer_code")]
        public Guid Customer_Id { get; set; }
        [Column("issue_date")]
        public DateTime Issue_Date { get; set; } = DateTime.MinValue;
        [Column("doctor_full_name")]
        public string Doctor { get; set; } = string.Empty;
        [Column("patient_diagnosis")]
        public string Diagnosis { get; set; } = string.Empty;
    }
}
