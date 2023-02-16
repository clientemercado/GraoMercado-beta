using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class FormasPagamento : Repository.Pattern.Ef6.Entity
    {
        public int id_FormaPgto { get; set; }
        public string Descricao_FormaPgto { get; set; }
    }
}
