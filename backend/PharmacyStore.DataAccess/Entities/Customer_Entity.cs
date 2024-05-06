using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyStore.DataAccess.Entities
{
    public class Customer_Entity
    {
        [Key]
        [Column("customer_code")]
        public Guid Customer_Id { get; set; }

        [Column("last_name")]
        public string Last_Name { get; set;} = string.Empty;

        [Column("first_name")]
        public string First_Name { get; set;} = string.Empty;

        [Column("middle_name")]
        public string Middle_Name { get; set; } = string.Empty;

        [Column("address")]
        public string Addres { get; set;} = string.Empty;

        [Column("city")]
        public string City { get; set;} = string.Empty;

        [Column("phone")]
        public string Phone { get; set;} = string.Empty;
    }
}
