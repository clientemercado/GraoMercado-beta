using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class SearchUpdateModel
    {
        public SearchUpdateModel()
        {
            TiposAtividades = new List<GrupoAtividadesEmpresa>();
            EstadosUF = new List<ESTADO>();
            CidadesUF = new List<CIDADE>();
            cidades_coordenadas = new List<CIDADE_GEOLOCALIZACAO>();
            Unidades = new List<Unidades>();
            itensDaCotacao = new List<Itens_Cotacao>();
            TiposFrete = new List<TiposFrete>();
            FornecedoresCotados = new List<FornecedoresCotacao>();
            RespostaFornecedoresCotados = new List<Resposta_FornecedoresCotacao>();
            ListaDeOutrosCotantes = new List<ListingDadosCotantes>();
        }

        public int idCotacao { get; set; }
        public int id_ItemCotacao { get; set; }
        public int id_ItemCotacaoAdd { get; set; }
        public string EstadoUF { get; set; }
        public string CidadeUF { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public int inTipoCotacao { get; set; }
        public string ProdutoCotado { get; set; }
        public string CotacaoEnviada { get; set; }
        public string DataEncerramento { get; set; }
        public string DataCadastro { get; set; }
        public string CotacaoAtivaSN { get; set; }
        public string areaAtuacao { get; set; }
        public string QuantidadeTotalCompra { get; set; }
        public string QuantidadeMeuPedido { get; set; }
        public string UnidadeProduto { get; set; }
        public string ObservacoesRelevantes { get; set; }
        public string QuantidadeAtendida { get; set; }
        public int idRespostaCotacao { get; set; }
        public string ValorCotado { get; set; }
        public int id_TipoFrete { get; set; }
        public string TipoFrete { get; set; }
        public string Local { get; set; }

        public List<Unidades> Unidades { get; set; }
        public List<GrupoAtividadesEmpresa> TiposAtividades { get; set; }
        public List<ESTADO> EstadosUF { get; set; }
        public List<CIDADE> CidadesUF { get; set; }
        public List<CIDADE_GEOLOCALIZACAO> cidades_coordenadas { get; set; }
        public List<Itens_Cotacao> itensDaCotacao { get; set; }
        public List<TiposFrete> TiposFrete { get; set; }
        public List<FornecedoresCotacao> FornecedoresCotados { get; set; }
        public List<Resposta_FornecedoresCotacao> RespostaFornecedoresCotados { get; set; }
        public List<ListingDadosCotantes> ListaDeOutrosCotantes { get; set; }
    }
}