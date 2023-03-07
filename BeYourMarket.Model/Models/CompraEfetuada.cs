using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class CompraEfetuada : Repository.Pattern.Ef6.Entity
    {
        public int Id_CompEfet { get; set; }
        public int Id_Oferta { get; set; }
        public decimal Quant_CompEfet { get; set; }
        public decimal ValorCompra_CompEfet { get; set; }
        public int MeiosPag_CompEfet { get; set; }
        public int ModoPag_CompEfet { get; set; }
    }
}
