namespace PharmacyStore.Core.Models
{
    public class Medicine
    {
        private Medicine(Guid code, string Medicine_Name, string Medicine_Type, string Medicine_Category, decimal Medicine_Price) 
        {
            Medicine_Code = code;
            this.Medicine_Name = Medicine_Name;
            this.Medicine_Type = Medicine_Type;
            this.Medicine_Category = Medicine_Category;
            this.Medicine_Price = Medicine_Price;
        }
        public Guid Medicine_Code { get; }
        public string Medicine_Name { get;} = string.Empty;

        public string Medicine_Type { get; } = string.Empty;
        public string Medicine_Category { get;} = string.Empty;

        public decimal Medicine_Price { get;}

        public static (Medicine medicine, string Error) Create(Guid id, string Medicine_Name, string Medicine_Type, string Medicine_Category, decimal Medicine_Price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(Medicine_Name))
            {
                error = "Title can not be empty!";

            }
            var medicine = new Medicine(id, Medicine_Name, Medicine_Type, Medicine_Category, Medicine_Price);

            return (medicine, error);

        }
    }
}
