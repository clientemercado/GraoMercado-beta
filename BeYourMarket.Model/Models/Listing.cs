using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BeYourMarket.Model.Models
{
    public partial class Listing : Repository.Pattern.Ef6.Entity
    {
        public Listing()
        {
            this.ListingMetas = new List<ListingMeta>();
            this.ListingPictures = new List<ListingPicture>();
            this.ListingReviews = new List<ListingReview>();
            this.ListingStats = new List<ListingStat>();
            this.Orders = new List<Order>();
            this.MessageThreads = new List<MessageThread>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int ListingTypeID { get; set; }
        public string UserID { get; set; }
        //public Nullable<double> Price { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool ShowPhone { get; set; }
        public bool Active { get; set; }
        public bool Enabled { get; set; }
        public bool ShowEmail { get; set; }
        public bool Premium { get; set; }
        public System.DateTime Expiration { get; set; }
        public string IP { get; set; }
        public string Location { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ListingMeta> ListingMetas { get; set; }
        public virtual ICollection<ListingPicture> ListingPictures { get; set; }
        public virtual ICollection<ListingReview> ListingReviews { get; set; }
        public virtual ListingType ListingType { get; set; }
        public virtual ICollection<ListingStat> ListingStats { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<MessageThread> MessageThreads { get; set; }

        // [09/11/21] Updated by, Edwilson Curti
        // Acréscimo de campos necessários para a venda de Produtos no MktPlace
        public string UnidadeProduto { get; set; }
        public decimal? QuantidadeItensVenda { get; set; }
        public decimal? ValorEmDRC { get; set; }

        public string IdadeAnimais { get; set; }
        public decimal QuantidadeItemSale { get; set; }
        public decimal PesoKgPorItemSale { get; set; }
        public decimal PesoArrobaPorItemSale { get; set; }
        public decimal PesoTotalLoteKgSale { get; set; }
        public decimal PesoTotalLoteArrobaSale { get; set; }
        public decimal ValorTotalDoLoteSale { get; set; }
        public decimal ValorTotalPorAnimalSale { get; set; }
        public decimal ValorTotalPorKgSale { get; set; }
        public decimal ValorTotalPorArrobaSale { get; set; }
        public int? id_AnimalProducao { get; set; }
        public int? id_TipoRacasAnimais { get; set; }
        public string LocalRetirada { get; set; }
        public string ReferenciaLocalRetirada { get; set; }

        [AllowHtml]
        public string LinkCam { get; set; }

        public int? id_Insurer { get; set; }
        public double? NumApolice { get; set; }
        public decimal? ValorCoberturaApolice { get; set; }
        public int? id_TipoFrete { get; set; }
        public int? id_OperationType { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal ValorTotalDoLoteSaleAddComissao { get; set; }
        public string ReferLote { get; set; }
    }
}
