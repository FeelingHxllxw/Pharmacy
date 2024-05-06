
namespace PharmacyStore.Core.Models
{
    public class Customer
    {
        private Customer(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone)
        {
            Customer_Id = id;
            this.Last_Name = Last_Name;
            this.First_Name = First_Name;
            this.Middle_Name = Middle_Name;
            this.Addres = Addres;
            this.City = City;
            this.Phone = Phone;
        }

        public Guid Customer_Id { get;}
        public string Last_Name { get; } = string.Empty;
        public string First_Name { get; } = string.Empty;
        public string Middle_Name { get; } = string.Empty;
        public string Addres { get; } = string.Empty;
        public string City { get; } = string.Empty;
        public string Phone { get; } = string.Empty;

        public static(Customer customer, string Error) Create(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Last_Name))
            {
                error = "Last name can not be empty!";

            }

            var customer = new Customer(id, Last_Name, First_Name, Middle_Name, Addres, City, Phone);

            return (customer, error);
        }


    }
}
