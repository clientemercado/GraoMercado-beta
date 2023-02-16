using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeYourMarket.Web.Models
{
    public class SettingsUpdateModel
    {
        public int id_CB { get; set; }
        public int id_Banco { get; set; }
        public List<Banks> BancosPais { get; set; }
        public string AgenciaBancaria { get; set; }
        public int id_TpConta { get; set; }
        public List<TiposContaBancaria> TpContaBancaria { get; set; }
        public string NumeroContaBancaria { get; set; }
        public string DigContaBancaria  { get; set; }
        public List<TiposChavePix> TpChavesPix { get; set; }
        public int id_TpChavePix { get; set; }
        public string ChavePix { get; set; }
    }
}