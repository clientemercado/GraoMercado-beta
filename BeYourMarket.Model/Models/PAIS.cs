using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class PAIS : Repository.Pattern.Ef6.Entity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public DateTime Data_Cadastro { get; set; }
    }
}
