
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyStore.DataAccess.Entities
{
    public class Worker_Entity
    {
        [Key]
        [Column("pharmacists_code")]
        public Guid Worker_Id { get; set; }

        [Column("last_name")]
        public string Last_Name { get; set;} = string.Empty;

        [Column("first_name")]
        public string First_Name { get; set;} = string.Empty;

        [Column("middle_name")]
        public string Middle_Name { get; set; } = string.Empty;

        [Column("employment_date")]
        public DateTime Employment_Date { get; set; } = DateTime.MinValue;

        [Column("birth_date")]
        public DateTime Birth_Date {  get; set; } = DateTime.MinValue;

        [Column("education")]
        public string Education { get; set; } = string.Empty;
    }
}
