using BeYourMarket.Model.AdaptedModels;
using BeYourMarket.Model.Models;
using BeYourMarket.Web.Models.Grids;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class SearchListingModel : SortViewModel
    {
        public SearchListingModel()
        {
            EstadosUF = new List<ESTADO>();
            CidadesUF = new List<CIDADE>();
            Categories = new List<Category>();
        }

        public int CategoryID { get; set; }
        public List<int> ListingTypeID { get; set; }
        public string SearchText { get; set; }
        public string Location { get; set; }
        public bool PhotoOnly { get; set; }
        //public double? PriceFrom { get; set; }
        public decimal? PriceFrom { get; set; }
        //public double? PriceTo { get; set; }
        public decimal? PriceTo { get; set; }
        public string EstadoUF { get; set; }
        public string CidadeUF { get; set; }

        public List<MetaCategory> MetaCategories { get; set; }
        public List<ListingItemModel> Listings { get; set; }
        public IPagedList<ListingItemModel> ListingsPageList { get; set; }
        public List<Category> Categories { get; set; }
        public List<Category> BreadCrumb { get; set; }
        public List<ListingType> ListingTypes { get; set; }
        public ListingModelGrid Grid { get; set; }
        public List<ESTADO> EstadosUF { get; set; }
        public List<CIDADE> CidadesUF { get; set; }
        public List<ListOffersforSale> listaOfertasVenda { get; set; }
        public List<ListingItemICModel> listaOfertasCompra { get; set; }
    }
}