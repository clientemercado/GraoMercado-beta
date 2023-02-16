using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TiposCadastro : Repository.Pattern.Ef6.Entity
    {
        public int id_TipoCadastro { get; set; }
        public string Descricao_TipoCadastro { get; set; }
        public DateTime DataCadastroTipoCad { get; set; }
    }
}
