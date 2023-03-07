using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class MeiosDePagamento : Repository.Pattern.Ef6.Entity
    {
        public int Id_MeiosPag { get; set; }
        public string Descricao_MeiosPag { get; set; }
    }
}
