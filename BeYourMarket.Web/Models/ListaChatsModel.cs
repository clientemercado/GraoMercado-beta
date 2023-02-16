using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class ListaChatsModel
    {
        public List<ChatOferta> chatLogado { get; set; }
        public List<ChatOferta> chatOutros { get; set; }
    }
}