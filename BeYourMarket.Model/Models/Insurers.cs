using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class Insurers : Repository.Pattern.Ef6.Entity
    {
        public int id_Insurer { get; set; }
        public string Nome_Insurer { get; set; }
    }
}
