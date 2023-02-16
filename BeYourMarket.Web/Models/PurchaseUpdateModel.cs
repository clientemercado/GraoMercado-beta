using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class PurchaseUpdateModel
    {
        public PurchaseUpdateModel()
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
        }

        public int CategoryID { get; set; }
        public int ListingTypeID { get; set; }
        public string UserID { get; set; }
        public Listing ListingItem { get; set; }
        public IntencoesCompra ICItem { get; set; }
        public List<Category> Categories { get; set; }
        public List<ListingType> ListingTypes { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<PictureModel> Pictures { get; set; }
        public CustomFieldListingModel CustomFields { get; set; }

        public List<Unidades> Unidades { get; set; }
        public List<ModalidadesCompra> ModalidadesCompra { get; set; }
        public List<TiposFrete> TiposFrete { get; set; }
        public List<IntencoesCompra> IntencoesCompra { get; set; }
        public List<FormasPagamento> FormasPagamento { get; set; }

        public string UnidadeProduto { get; set; }
        public string TipoFrete { get; set; }
        public string TipoModalidade { get; set; }

        // [28/12/21] Updated by, Edwilson Curti
        // Acréscimo de campos necessários para a Compra de Produtos no MktPlace
        public string ProdutoCompra { get; set; }
        public string ModalidadeCompra { get; set; }
        public string QuantidadeTotalCompra { get; set; }
        public string QuantidadeMinimaCompra { get; set; }
        public string MnhaOfertaDePreco { get; set; }
        public string OfertaValidaAte { get; set; }
        public string FormaPagamento { get; set; }
    }
}