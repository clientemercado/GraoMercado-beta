using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TiposFrete : Repository.Pattern.Ef6.Entity
    {
        public int id_TipoFrete { get; set; }
        public string Descricao_TipoFrete { get; set; }
    }
}
