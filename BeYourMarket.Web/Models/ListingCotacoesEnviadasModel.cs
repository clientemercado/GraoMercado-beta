using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingCotacoesEnviadasModel
    {
        public int idCM { get; set; }
        public string identificadorCM { get; set; }
        public string grupoAtividadade { get; set; }
        public string tipoCotacao { get; set; }
        public int tpCotacao { get; set; }
        public string regiaoCotacao { get; set; }
        public string cadastradoEm { get; set; }
        public string EncerraEm { get; set; }
        public string nomeUserCriou { get; set; }
        public string idUserCriou { get; set; }
        public string idUserLogado { get; set; }
        public bool participCotacaoGrupo { get; set; }
        public string ativadaDesativada { get; set; }
        public bool cotacaoCancelada { get; set; }
        public List<FornecedoresCotacao> listaFornecedoresQueReceberamACotacao { get; set; }
    }
}