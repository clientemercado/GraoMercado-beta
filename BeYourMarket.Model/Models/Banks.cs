using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class Banks : Repository.Pattern.Ef6.Entity
    {
        public int id_Bank { get; set; }
        public int id_Country { get; set; }
        public string COMPE { get; set; }
        public string ISPB { get; set; }
        public string Document { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Network { get; set; }
        public string Type { get; set; }
        public string PixType { get; set; }
        public bool? Charge { get; set; }
        public bool? CreditDocument { get; set; }
        public string SalaryPortability { get; set; }
        public string Products { get; set; }
        public string Url { get; set; }
        public string DateOperationStarted { get; set; }
        public string DatePixStarted { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
