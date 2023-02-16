using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TiposContaBancaria : Repository.Pattern.Ef6.Entity
    {
        public int id_TipoConta { get; set; }
        public string Descricao_TipoConta { get; set; }
    }
}
