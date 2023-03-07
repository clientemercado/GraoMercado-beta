using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class ModosPagamento : Repository.Pattern.Ef6.Entity
    {
        public int Id_ModosPag { get; set; }
        public string Descricao_ModosPag { get; set; }
    }
}
