
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PharmacyStore.DataAccess.Entities
{
    public class User_Entity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("login")]
        public string Login { get; set; } = string.Empty;
        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }
}
