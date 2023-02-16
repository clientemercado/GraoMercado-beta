using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class ModalidadesCompra : Repository.Pattern.Ef6.Entity
    {
        public int id_ModalCompra { get; set; }
        public string Descricao_ModalCompra { get; set; }
        public string Periodo_Ini_ModalCompra { get; set; }
        public string Periodo_End_ModalCompra { get; set; }
    }
}
