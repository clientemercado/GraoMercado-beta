using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingCotacaoesModel
    {
        public List<ListingCotacoesEnviadasModel> ListaCotacoesEnviadas { get; set; }
        public List<ListingCotacoesRecebidasModel> ListaCotacoesRecebidas { get; set; }
    }
}