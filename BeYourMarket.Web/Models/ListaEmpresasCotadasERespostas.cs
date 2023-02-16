using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListaEmpresasCotadasERespostas : EmpresaUsuario
    {
        public string localizacaoEmpresaFornecedor { get; set; }
        public string quantidadeQuePodeAtender { get; set; }
        public string valorRespondidoPorUnidade { get; set; }
        public string valorTotalCotado { get; set; }
        public bool menorValorCotado { get; set; }
    }
}