using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListingDadosCotantes : AspNetUser
    {
        public string qPed { get; set; }
        public string cidadePed { get; set; }
    }
}