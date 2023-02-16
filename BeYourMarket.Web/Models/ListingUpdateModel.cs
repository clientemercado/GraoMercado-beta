using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeYourMarket.Web.Models
{
    public class ListingUpdateModel
    {
        public ListingUpdateModel()
        {
            Categories = new List<Category>();
            Users = new List<ApplicationUser>();
            Pictures = new List<PictureModel>();
            CustomFields = new CustomFieldListingModel();
            Unidades = new List<Unidades>();
            ModalidadesCompra = new List<ModalidadesCompra>();
            IntencoesCompra = new List<IntencoesCompra>();
            TiposFrete = new List<TiposFrete>();
            FormasPagamento = new List<FormasPagamento>();
            TiposAnimaisProducao = new List<TipoAnimalProducao>();
            RacasAnimais = new List<TiposRacasAnimaisPecuaria>();
            EmpresasSeguradoras = new List<Insurers>();
            CompanhiasTransporte = new List<ShippingCompany>();
        }

        public int CategoryID { get; set; }
        public int ListingTypeID { get; set; }
        public int SeguradoraID { get; set; }
        public string UserID { get; set; }
        public Listing ListingItem { get; set; }
        public IntencoesCompra ICItem { get; set; }
        public List<Category> Categories { get; set; }
        public List<ListingType> ListingTypes { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<PictureModel> Pictures { get; set; }
        public CustomFieldListingModel CustomFields { get; set; }

        public List<Unidades> Unidades { get; set; }
        public List<ModalidadesCompra> ModalidadesCompra { get; set;}
        public List<TiposFrete> TiposFrete { get; set; }
        public List<IntencoesCompra> IntencoesCompra { get; set; }
        public List<FormasPagamento> FormasPagamento { get; set; }
        public List<ShippingCompany> CompanhiasTransporte { get; set; }

        public string UnidadeProduto { get; set; }
        public string TipoModalidade { get; set; }
        public string EmpresaTransportadora { get; set; }

        // [28/12/21] Updated by, Edwilson Curti
        // Acréscimo de campos necessários para a Compra de Produtos no MktPlace
        public string ProdutoCompra { get; set; }
        public string ModalidadeCompra { get; set; }
        public string QuantidadeTotalCompra { get; set; }
        public string QuantidadeMinimaCompra { get; set; }
        public string MnhaOfertaDePreco { get; set; }
        public string OfertaValidaAte { get; set; }
        public string FormaPagamento { get; set; }
        public string Linkcam { get; set; }

        public List<TipoAnimalProducao> TiposAnimaisProducao { get; set; }
        public List<TiposRacasAnimaisPecuaria> RacasAnimais { get; set; }
        public List<Insurers> EmpresasSeguradoras { get; set; }
        public int? RacaAnimais { get; set; }
        public string PesoKgPorItemSale { get; set; }
        public string PesoArrobaPorItemSale { get; set; }
        public string PesoTotalLoteKgSale { get; set; }
        public string PesoTotalLoteArrobaSale { get; set; }
        public string ValorTotalDoLoteSale { get; set; }
        public string ValorTotalPorAnimalSale { get; set; }
        public string ValorTotalPorKgSale { get; set; }
        public string ValorTotalPorArrobaSale { get; set; }
        public string inIdadeAnimais { get; set; }
        public string inQuantidadeItenSale { get; set; }
        public string inPesoUnitarioKg { get; set; }
        public string inPesoUnitarioArrobas { get; set; }
        public string inPesoTotalLoteKg { get; set; }
        public string inPesoTotalLoteArrobas { get; set; }
        public string inValorPorAnimal { get; set; }
        public string inValorTotalDoLoteSale { get; set; }
        public string inValorTotalPorKgSale { get; set; }
        public string inValorTotalPorArrobaSale { get; set; }
        public string inValorTotalPorAnimalSale { get; set; }
        public string inValorPorKg { get; set; }
        public string inValorPorArroba { get; set; }
        public string inLocalRetirada { get; set; }
        public string inCidadeEstadoRetirada { get; set; }
        public string inReferenciaLocalRetirada { get; set; }
        public string descricaoTipoAnimal { get; set; }
        public string descricaoracaAnimal { get; set; }
        public string dataPublicacao { get; set; }
        public int? id_TipoFrete { get; set; }
        public string inNumApolice { get; set; }
        public string freteOferta { get; set; }
        public string inPercentTaxaPlat { get; set; }
        public string inValorTaxaPlataforma { get; set; }
        public string inValorTotalMaisTaxa { get; set; }
        public string vlrComissPlataforma { get; set; }
        public string totalOfertaMaisComissao { get; set; }
        public bool temDialogo { get; set; }
        public string inQuantCompra { get; set; }
        public ApplicationUser UsuarioComprador { get; set; }
        public string Cidade_UF_Comprador { get; set; }
        public int quantCompraCalc { get; set; }
        public string quantDesejaComprar { get; set; }
        public string valorTotalDaCompra { get; set; }
    }
}
