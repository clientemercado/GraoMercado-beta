using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TiposChavePix : Repository.Pattern.Ef6.Entity
    {
        public int id_TipoChavePix { get; set; }
        public string Descricao_TipoChavePix{ get; set; }
    }
}
