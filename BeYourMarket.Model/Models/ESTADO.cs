using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class ESTADO : Repository.Pattern.Ef6.Entity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CODIGO { get; set; }
        public string SIGLA { get; set; }
        public int FK_PAIS { get; set; }
        public DateTime Data_Cadastro { get; set; }
    }
}
