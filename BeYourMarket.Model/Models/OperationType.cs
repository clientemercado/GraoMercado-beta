using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class OperationType : Repository.Pattern.Ef6.Entity
    {
        public int id_OperationType { get; set; }
        public string Descricacao_Operacao { get; set; }
        public decimal Percentual_Comissao { get; set; }
        public decimal? ValorDoServico { get; set; }
    }
}
