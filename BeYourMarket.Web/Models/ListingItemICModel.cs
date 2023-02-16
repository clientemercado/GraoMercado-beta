using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingItemICModel
    {
        public int id_IC { get; set; }
        public List<IntencoesCompra> ListingsICOther { get; set; }
        public IntencoesCompra ListingICCurrent { get; set; }

        public string DescricaoProduto { get; set; }
        public string CategoriaDescricao { get; set; }
        public string Location { get; set; }
        public string DataPublicacao { get; set; }
        public string DataLimiteOferta { get; set; }

        public string UrlPicture { get; set; }

        public List<PictureModel> Pictures { get; set; }

        public List<DateTime> DatesBooked { get; set; }

        public ApplicationUser User { get; set; }

        public List<ListingICReview> ListingICReviews { get; set; }
    }
}