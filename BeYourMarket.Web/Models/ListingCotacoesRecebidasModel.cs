using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingCotacoesRecebidasModel : ListingCotacoesEnviadasModel
    {
		public int id_CotacaoRecebida { get; set; }
        public int idEmpresaReccebeu { get; set; }
	    public bool jahRespondida { get; set; }
        public bool naoVaiResponder { get; set; }
        public bool venceuACotacao { get; set; }
    }
}