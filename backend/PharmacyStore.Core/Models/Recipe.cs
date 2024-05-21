

namespace PharmacyStore.Core.Models
{
    public class Recipe
    {
        public Recipe(Guid Id, Guid Customer_id, DateTime Issue_date, string Doctor, string Diagnosis)
        {
            Recipe_Id = Id;
            this.Customer_id = Customer_id;
            this.Issue_date = Issue_date;
            this.Doctor = Doctor;
            this.Diagnosis = Diagnosis;
        }
        public Guid Recipe_Id { get; }
        public Guid Customer_id { get; }
        public string Name { get; set; } = string.Empty;
        public DateTime Issue_date { get; } = DateTime.MinValue;

        public string Doctor { get; } = string.Empty;
        public string Diagnosis { get; } = string.Empty;

  

    }
}
