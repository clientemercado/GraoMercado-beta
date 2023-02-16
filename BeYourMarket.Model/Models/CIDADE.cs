using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class CIDADE : Repository.Pattern.Ef6.Entity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CODIGO_IBGE { get; set; }
        public int FK_ESTADO { get; set; }
        public DateTime Data_Cadastro { get; set; }
    }
}
