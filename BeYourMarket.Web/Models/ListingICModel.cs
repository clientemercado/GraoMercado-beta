using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingICModel
    {
        public BeYourMarket.Web.Models.Grids.ListingsICGrid Grid { get; set; }

        public List<ListingItemICModel> Listings { get; set; }

        public List<Category> Categories { get; set; }
    }
}