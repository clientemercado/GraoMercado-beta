using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeYourMarket.Web.Controllers
{
    public class CotacoesController : Controller
    {
        // GET: Cotacoes
        public ActionResult AgriculturalQuotes()
        {
            return View();
        }

        public ActionResult LivestockQuotes()
        {
            return View();
        }
    }
}