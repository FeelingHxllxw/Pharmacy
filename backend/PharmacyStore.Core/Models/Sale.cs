using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Core.Models
{
    public class Sale
    {
        public Sale(Guid Id, DateTime Sale_Date, Guid Medicine_Id, int Count, Guid Recipe_Id, Guid Worker_Id) 
        { 
            Sale_Id = Id;
            this.Sale_Date = Sale_Date;
            this.Medicine_Id = Medicine_Id;
            this.Count = Count;
            this.Recipe_Id  = Recipe_Id;
            this.Worker_Id = Worker_Id;
        }

        public Guid Sale_Id { get; }
        public DateTime Sale_Date { get; } = DateTime.MinValue;
        public Guid Medicine_Id { get; }
        public string Medicine { get; set; } = string.Empty;
        public int Count { get; } = 0;
        public Guid Recipe_Id { get; }
        public string Diagnosis { get; set; } = string.Empty;
        public Guid Worker_Id { get; }
        public string Name { get; set; } = string.Empty;

    }
}
