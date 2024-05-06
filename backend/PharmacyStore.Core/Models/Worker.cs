namespace PharmacyStore.Core.Models
{
    public class Worker
    {
        private Worker(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education)
        {
            Worker_Id = id;
            this.Last_Name = Last_Name;
            this.First_Name = First_Name;
            this.Middle_Name = Middle_Name;
            this.Employment_Date = Employment_Date;
            this.Birth_Date = Birth_Date;
            this.Education = Education;
        }

        public Guid Worker_Id { get; }
        public string Last_Name { get; } = string.Empty;
        public string First_Name { get; } = string.Empty;
        public string Middle_Name { get; } = string.Empty;
        public DateTime Employment_Date { get; } = DateTime.MinValue;
        public DateTime Birth_Date { get; } = DateTime.MinValue;

        public string Education { get; } = string.Empty;

        public static (Worker worker, string Error) Create(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(Last_Name))
            {
                error = "Last name can not be empty!";

            }

            var worker = new Worker(id, Last_Name, First_Name, Middle_Name, Employment_Date, Birth_Date, Education);

            return (worker, error);
        }

    }
}
