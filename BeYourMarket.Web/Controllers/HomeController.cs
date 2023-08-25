using BeYourMarket.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeYourMarket.Web.Extensions;
using BeYourMarket.Web.Utilities;
using System.Threading.Tasks;
using BeYourMarket.Model.Models;
using BeYourMarket.Web.Models;
using PagedList;
using BeYourMarket.Web.Models.Grids;
using i18n;
using i18n.Helpers;
using Microsoft.AspNet.Identity;
using BeYourMarket.Model.AdaptedModels;
using Microsoft.Owin.Security;

namespace BeYourMarket.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        private readonly IUnidadesService _unidadesService;
        private readonly IModalidadesCompraService _modalidadesCompraService;
        private readonly IIntencoesCompraService _intencoesCompraService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly ITiposCadastroService _tiposCadastroService;
        private readonly IGruposAtividadesService _gruposAtividadesService;
        private readonly ICidadesService _cidadesService;
        private readonly ICidadesGeolocalizacaoService _cidadesGeolocalizacaoService;
        private readonly IEstadoService _estadosService;
        private readonly IPaisService _paisService;
        private readonly ICotacaoMasterService _cotacaoMasterService;
        private readonly IItensCotacaoService _itensCotacaoService;
        private readonly IFornecedoresCotacaoService _fornecedoresCotacaoService;
        private readonly IRespostaFornecedoresCotacaoService _respostaFornecedoresCotacaoService;
        private readonly ITiposFreteService _tiposFreteService;
        private readonly IListingService _listingService;
        private readonly IContentPageService _contentPageService;
        private readonly IFormasPagamentoService _formasPagamentoService;
        #endregion

        #region Constructor
        public HomeController(
            ICategoryService categoryService,
            IUnidadesService unidadesService,
            IModalidadesCompraService modalidadesCompraService,
            IIntencoesCompraService intencoesCompraService,
            IEmpresaUsuarioService empresaUsuarioService,
            ITiposCadastroService tiposCadastroService,
            IGruposAtividadesService gruposAtividadesService,
            ICidadesService cidadesService,
            ICidadesGeolocalizacaoService cidadesGeolocalizacaoService,
            IEstadoService estadosService,
            IPaisService paisService,
            ICotacaoMasterService cotacaoMasterService,
            IItensCotacaoService itensCotacaoService,
            IFornecedoresCotacaoService fornecedoresCotacaoService,
            IRespostaFornecedoresCotacaoService respostaFornecedoresCotacaoService,
            ITiposFreteService tiposFreteService,
            IFormasPagamentoService formasPagamentoService,
            IListingService listingService,
            IContentPageService contentPageService
            )
        {
            _categoryService = categoryService;
            _unidadesService = unidadesService;
            _modalidadesCompraService = modalidadesCompraService;
            _intencoesCompraService = intencoesCompraService;
            _empresaUsuarioService = empresaUsuarioService;
            _tiposCadastroService = tiposCadastroService;
            _gruposAtividadesService = gruposAtividadesService;
            _cidadesService = cidadesService;
            _cidadesGeolocalizacaoService = cidadesGeolocalizacaoService;
            _estadosService = estadosService;
            _paisService = paisService;
            _cotacaoMasterService = cotacaoMasterService;
            _itensCotacaoService = itensCotacaoService;
            _fornecedoresCotacaoService = fornecedoresCotacaoService;
            _respostaFornecedoresCotacaoService = respostaFornecedoresCotacaoService;
            _tiposFreteService = tiposFreteService;
            _formasPagamentoService = formasPagamentoService;
            _listingService = listingService;
            _contentPageService = contentPageService;
        }
        #endregion

        #region Methods
        public async Task<ActionResult> Index(string id, int? oqeq)
        {
            var userId = User.Identity.GetUserId();
            if ((userId != null) && (id == null))
            {
                AuthenticationManager.SignOut();
                return RedirectToAction("Index", "Home");
            }

            if (!string.IsNullOrEmpty(id))
                return RedirectToAction("ContentPage", "Home", new { id = id.ToLowerInvariant(), oqeq = oqeq });

            var model = new SearchListingModel()
            {
                ListingTypeID = CacheHelper.ListingTypes.Select(x => x.ID).ToList(),
                EstadosUF = CacheHelper.EstadoUf.OrderBy(e => (e.CODIGO)).ToList(),
                Categories = CacheHelper.Categories
            };

            oqeq = (oqeq >= 0) ? oqeq : 0;
            await GetSearchResult(model, (int)oqeq);

            ViewBag.oqeq = oqeq;

            return View(model);
        }

        public async Task<ActionResult> Sobre(int? oqeq)
        {
            return View();
        }

        public async Task<ActionResult> ContentPage(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("Index", "Home");

            var slug = id.ToLowerInvariant();
            var contentPageQuery = await _contentPageService.Query(x => x.Slug == slug && x.Published).SelectAsync();
            var contentPage = contentPageQuery.FirstOrDefault();

            if (contentPage == null)
            {
                return new HttpNotFoundResult();
            }

            return View(contentPage);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int? oqeq)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            var model = new ContactModel();

            if (User.Identity.IsAuthenticated)
            {
                model.Email = User.Identity.User().Email;
            }

            return View(model);
        }

        /// <summary>
        /// Carrega a lista de Cidades Conforme descrição do Estado UF
        /// </summary>
        /// <param name="uf">String contendo a UF</param>
        /// <returns></returns>
        public ActionResult CarregaCidadesUF(string uf)
        {
            var estadoUF = CacheHelper.EstadoUf.FirstOrDefault(e => (e.NOME.ToUpper() == uf.ToUpper()));
            var listaCidades = CacheHelper.Cidade.Where(c => (c.FK_ESTADO == estadoUF.ID)).ToList();
            return Json(listaCidades, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Search(SearchListingModel model, int? oqeq)
        {
            oqeq = (oqeq >= 0) ? oqeq : 0;
            ViewBag.oqeq = oqeq;
            await GetSearchResult(model, oqeq);
            return View("~/Views/Listing/Listings.cshtml", model);
        }

        private async Task GetSearchResult(SearchListingModel model, int? oqeq)
        {
            IEnumerable<Listing> items = null;

            // Category
            if (model.CategoryID != 0)
            {
                items = await _listingService.Query(x => x.CategoryID == model.CategoryID)
                    .Include(x => x.ListingPictures)
                    .Include(x => x.Category)
                    .Include(x => x.ListingType)
                    .Include(x => x.AspNetUser)
                    .Include(x => x.ListingReviews)
                    .SelectAsync();

                // Set listing types
                model.ListingTypes = CacheHelper.ListingTypes.Where(x => x.CategoryListingTypes.Any(y => y.CategoryID == model.CategoryID)).ToList();
            }
            else
            {
                model.ListingTypes = CacheHelper.ListingTypes;
            }

            // Set default Listing Type if it's not set or listing type is not set
            if (model.ListingTypes.Count > 0 &&
                (model.ListingTypeID == null || !model.ListingTypes.Any(x => model.ListingTypeID.Contains(x.ID))))
            {
                model.ListingTypeID = new List<int>();
                model.ListingTypeID.Add(model.ListingTypes.FirstOrDefault().ID);
            }

            // Search Text
            if (!string.IsNullOrEmpty(model.SearchText))
            {
                model.SearchText = model.SearchText.ToLower();

                // Search by title, description, location
                if (items != null)
                {
                    items = items.Where(x =>
                        x.Title.ToLower().Contains(model.SearchText) ||
                        x.Description.ToLower().Contains(model.SearchText) ||
                        x.Location.ToLower().Contains(model.SearchText));
                }
                else
                    items = await _listingService.Query(
                        x => x.Title.ToLower().Contains(model.SearchText) ||
                        x.Description.ToLower().Contains(model.SearchText) ||
                        x.Location.ToLower().Contains(model.SearchText))
                        .Include(x => x.ListingPictures)
                        .Include(x => x.Category)
                        .Include(x => x.AspNetUser)
                        .Include(x => x.ListingReviews)
                        .SelectAsync();
            }

            // Latest
            if (items == null)
            {
                items = await _listingService.Query().OrderBy(x => x.OrderByDescending(y => y.Created))
                    .Include(x => x.ListingPictures)
                    .Include(x => x.Category)
                    .Include(x => x.AspNetUser)
                    .Include(x => x.ListingReviews)
                    .SelectAsync();
            }

            // Filter items by Listing Type
            items = items.Where(x => model.ListingTypeID.Contains(x.ListingTypeID));

            // Location
            if (!string.IsNullOrEmpty(model.Location))
            {
                items = items.Where(x => !string.IsNullOrEmpty(x.Location) && x.Location.IndexOf(model.Location, StringComparison.OrdinalIgnoreCase) != -1);
            }

            // Picture
            if (model.PhotoOnly)
                items = items.Where(x => x.ListingPictures.Count > 0);

            /// Price
            if (model.PriceFrom.HasValue)
                items = items.Where(x => x.Price >= model.PriceFrom.Value);

            if (model.PriceTo.HasValue)
                items = items.Where(x => x.Price <= model.PriceTo.Value);

            // Show active and enabled only
            var itemsModelList = new List<ListingItemModel>();
            foreach (var item in items.Where(x => x.Active && x.Enabled).OrderByDescending(x => x.Created))
            {
                itemsModelList.Add(new ListingItemModel()
                {
                    ListingCurrent = item,
                    UrlPicture = item.ListingPictures.Count == 0 ? ImageHelper.GetListingImagePath(0) : ImageHelper.GetListingImagePath(item.ListingPictures.OrderBy(x => x.Ordering).FirstOrDefault().PictureID)
                });
            }
            var breadCrumb = GetParents(model.CategoryID).Reverse().ToList();

            model.BreadCrumb = breadCrumb;
            model.Categories = CacheHelper.Categories;
            model.Listings = itemsModelList;
            model.ListingsPageList = itemsModelList.ToPagedList(model.PageNumber, model.PageSize);
            model.Grid = new ListingModelGrid(model.ListingsPageList.AsQueryable());
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
        }

        IEnumerable<Category> GetParents(int categoryId)
        {
            Category category = _categoryService.Find(categoryId);
            while (category != null && category.Parent != category.ID)
            {
                yield return category;
                category = _categoryService.Find(category.Parent);
            }
        }

        public async Task<ActionResult> Offers(string uf, string city, string category, int tptab, SearchListingModel model, int? oqeq)
        {
            await GetSearchResultFilter(model, oqeq, uf, city, category, tptab);
            var result = new { listaOfertasVenda = model.listaOfertasVenda, listaOfertasCompra = model.listaOfertasCompra };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private async Task GetSearchResultFilter(SearchListingModel model, int? oqeq, string uf, string city, string category, int tptab)
        {
            var estadoUF = CacheHelper.EstadoUf.FirstOrDefault(e => (e.NOME.ToLower() == uf.ToLower()));
            var localization = (city + '-' + estadoUF.SIGLA);

            IEnumerable<Listing> items = null;
            IEnumerable<IntencoesCompra> items_offers = null;
            if (Convert.ToInt32(category) > 0)
                model.CategoryID = Convert.ToInt32(category);

            // Category
            if (model.CategoryID != 0)
            {
                items = await _listingService.Query(x => x.CategoryID == model.CategoryID)
                    .Include(x => x.ListingPictures)
                    .Include(x => x.Category)
                    .Include(x => x.ListingType)
                    .Include(x => x.AspNetUser)
                    .Include(x => x.ListingReviews)
                    .SelectAsync();

                // Set listing types
                model.ListingTypes = CacheHelper.ListingTypes.Where(x => x.CategoryListingTypes.Any(y => y.CategoryID == model.CategoryID)).ToList();
            }
            else
            {
                model.ListingTypes = CacheHelper.ListingTypes;
            }

            // Set default Listing Type if it's not set or listing type is not set
            if (model.ListingTypes.Count > 0 &&
                (model.ListingTypeID == null || !model.ListingTypes.Any(x => model.ListingTypeID.Contains(x.ID))))
            {
                model.ListingTypeID = new List<int>();
                model.ListingTypeID.Add(model.ListingTypes.FirstOrDefault().ID);
            }

            if ((!string.IsNullOrEmpty(localization)) && (Convert.ToInt32(category) > 0))
            {
                // Search by title, description, location
                if (items != null)
                {
                    var teste1 = Convert.ToInt32(category);
                    var teste2 = localization.ToLower();
                    //items = items.Where(i => (i.CategoryID == Convert.ToInt32(category)) && (i.Location.ToLower().Contains(localization.ToLower())));
                    items = items.Where(i => (i.CategoryID == Convert.ToInt32(category)) && (i.Location.ToLower() == localization.ToLower()));
                    items_offers = CacheHelper.IntencoesCompra.Where(ic => (ic.CategoryID == Convert.ToInt32(category) && (ic.Location.ToLower() == localization.ToLower()))).ToList();
                }
                else
                    items = await _listingService.Query(
                        x => x.Title.ToLower().Contains(model.SearchText) ||
                        x.Description.ToLower().Contains(model.SearchText) ||
                        x.Location.ToLower().Contains(model.SearchText))
                        .Include(x => x.ListingPictures)
                        .Include(x => x.Category)
                        .Include(x => x.AspNetUser)
                        .Include(x => x.ListingReviews)
                        .SelectAsync();
            }

            // Latest
            if (items == null)
            {
                items = await _listingService.Query().OrderBy(x => x.OrderByDescending(y => y.Created))
                    .Include(x => x.ListingPictures)
                    .Include(x => x.Category)
                    .Include(x => x.AspNetUser)
                    .Include(x => x.ListingReviews)
                    .SelectAsync();
            }

            // Location
            if (!string.IsNullOrEmpty(model.Location))
            {
                items = items.Where(x => !string.IsNullOrEmpty(x.Location) && x.Location.IndexOf(model.Location, StringComparison.OrdinalIgnoreCase) != -1);
            }

            // Show active and enabled only
            var itemsModelList = new List<ListingItemModel>();
            var intensOfertaVenda = new List<ListOffersforSale>();
            var itensIntencaoCompra = new List<ListingItemICModel>();
            foreach (var item in items.Where(x => x.Active && x.Enabled).OrderByDescending(x => x.Created))
            {
                var quant1 = item.QuantidadeItemSale.ToString().Split(',');
                intensOfertaVenda.Add(new ListOffersforSale { 
                    ID = item.ID,
                    Title = item.Title,
                    UrlPicture = item.ListingPictures.Count == 0 ? ImageHelper.GetListingImagePath(0) : ImageHelper.GetListingImagePath(item.ListingPictures.OrderBy(x => x.Ordering).FirstOrDefault().PictureID),
                    Description = (item.Description.Length > 29) ? item.Description.Substring(0, 30) : item.Description,
                    CategoryID = item.CategoryID,
                    LinkCam = item.LinkCam,
                    LoteOferta = item.ReferLote,
                    LocalizacaoView = item.Location,
                    QuantItens = quant1[0]
                });
            }

            foreach (var item_oferta in items_offers.Where(x => x.OfertaValidaAte <= DateTime.Now).OrderByDescending(x => x.DataCadastroOferta))
            {
                itensIntencaoCompra.Add(new ListingItemICModel
                {
                    id_IC = item_oferta.id_IC,
                    DescricaoProduto = item_oferta.DescricaoProduto,
                    Location = item_oferta.Location,
                    CategoriaDescricao = (item_oferta.CategoryID > 0) ? CacheHelper.Categories.FirstOrDefault(x => (x.ID == item_oferta.CategoryID)).Name.ToString() : "",
                    DataPublicacao = String.Format("{0:dd/MM/yyyy}", item_oferta.DataCadastroOferta),
                    DataLimiteOferta = String.Format("{0:dd/MM/yyyy}", item_oferta.OfertaValidaAte)
                });
            }

            var breadCrumb = GetParents(model.CategoryID).Reverse().ToList();

            model.BreadCrumb = breadCrumb;
            model.Categories = CacheHelper.Categories;
            model.Listings = itemsModelList;
            model.listaOfertasVenda = intensOfertaVenda;
            model.listaOfertasCompra = itensIntencaoCompra;
            model.ListingsPageList = itemsModelList.ToPagedList(model.PageNumber, model.PageSize);
            model.Grid = new ListingModelGrid(model.ListingsPageList.AsQueryable());
        }

        [ChildActionOnly]
        public ActionResult NavigationSide(int? oqeq)
        {
            var rootId = 0;
            var categories = CacheHelper.Categories.ToList();

            var categoryTree = categories.OrderBy(x => x.Parent).ThenBy(x => x.Ordering).ToList().GenerateTree(x => x.ID, x => x.Parent, rootId);

            var contentPages = CacheHelper.ContentPages.Where(x => x.Published).OrderBy(x => x.Ordering);

            var model = new NavigationSideModel()
            {
                CategoryTree = categoryTree,
                ContentPages = contentPages
            };

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            return View("_NavigationSide", model);
        }

        [ChildActionOnly]
        public ActionResult LanguageSelector()
        {
            //var languages = i18n.LanguageHelpers.GetAppLanguages();
            var languages = LanguageHelper.AvailableLanguges.Languages;
            var languageCurrent = ControllerContext.RequestContext.HttpContext.GetPrincipalAppLanguageForRequest();

            var model = new LanguageSelectorModel();
            model.Culture = languageCurrent.GetLanguage();
            model.DisplayName = languageCurrent.GetCultureInfo().NativeName;

            foreach (var language in languages)
            {
                if (language.Culture != languageCurrent.GetLanguage() && language.Enabled)
                {
                    model.LanguageList.Add(new LanguageSelectorModel()
                    {
                        Culture = language.Culture,
                        DisplayName = language.LanguageTag.CultureInfo.NativeName
                    });
                }
            }

            return PartialView("_LanguageSelector", model);
        }

        [AllowAnonymous]
        public ActionResult SetLanguage(string langtag, string returnUrl)
        {
            // If valid 'langtag' passed.
            i18n.LanguageTag lt = i18n.LanguageTag.GetCachedInstance(langtag);
            if (lt.IsValid())
            {
                // Set persistent cookie in the client to remember the language choice.
                Response.Cookies.Add(new HttpCookie("i18n.langtag")
                {
                    Value = lt.ToString(),
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddYears(1)
                });
            }
            // Owise...delete any 'language' cookie in the client.
            else
            {
                var cookie = Response.Cookies["i18n.langtag"];
                if (cookie != null)
                {
                    cookie.Value = null;
                    cookie.Expires = DateTime.UtcNow.AddMonths(-1);
                }
            }
            // Update PAL setting so that new language is reflected in any URL patched in the 
            // response (Late URL Localization).
            HttpContext.SetPrincipalAppLanguageForRequest(lt);
            // Patch in the new langtag into any return URL.
            if (returnUrl.IsSet())
            {
                returnUrl = LocalizedApplication.Current.UrlLocalizerForApp.SetLangTagInUrlPath(HttpContext, returnUrl, UriKind.RelativeOrAbsolute, lt == null ? null : lt.ToString()).ToString();
            }
            //Redirect user agent as approp.
            return this.Redirect(returnUrl);
        }
        #endregion

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}