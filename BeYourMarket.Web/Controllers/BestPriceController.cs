using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BeYourMarket.Web.Models;
using BeYourMarket.Model.Models;
using BeYourMarket.Web.Utilities;
using BeYourMarket.Service;
using Repository.Pattern.UnitOfWork;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using ImageProcessor;
using System.IO;
using System.Collections.Generic;
using BeYourMarket.Model.Enum;
using BeYourMarket.Web.Models.Grids;
using RestSharp;
using BeYourMarket.Core.Web;
using BeYourMarket.Service.Models;
using Microsoft.Practices.Unity;
using BeYourMarket.Web.Extensions;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;
using System.Globalization;

namespace BeYourMarket.Web.Controllers
{
    public class BestPriceController : Controller
    {
        #region Fields
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private readonly ISettingService _settingService;
        private readonly ISettingDictionaryService _settingDictionaryService;
        private readonly ICategoryService _categoryService;
        private readonly IUnidadesService _unidadesService;
        private readonly IModalidadesCompraService _modalidadesCompraService;
        private readonly IIntencoesCompraService _intencoesCompraService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly ITiposFreteService _tiposFreteService;
        private readonly IFormasPagamentoService _formasPagamentoService;
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
        private readonly IListingService _listingService;
        private readonly IListingStatService _ListingStatservice;
        private readonly IListingPictureService _listingPictureservice;
        private readonly IListingReviewService _listingReviewService;
        private readonly IPictureService _pictureService;
        private readonly IOrderService _orderService;
        private readonly ICustomFieldService _customFieldService;
        private readonly ICustomFieldCategoryService _customFieldCategoryService;
        private readonly ICustomFieldListingService _customFieldListingService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IMessageService _messageService;
        private readonly IMessageThreadService _messageThreadService;
        private readonly IMessageParticipantService _messageParticipantService;
        private readonly IMessageReadStateService _messageReadStateService;
        private readonly DataCacheService _dataCacheService;
        private readonly SqlDbService _sqlDbService;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion

        #region Contructors
        public BestPriceController(
           IUnitOfWorkAsync unitOfWorkAsync,
           ISettingService settingService,
           ICategoryService categoryService,
           IUnidadesService unidadesService,
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
           IModalidadesCompraService modalidadesCompraService,
           ITiposFreteService tiposFreteService,
           IFormasPagamentoService formasPagamentoService,
           IListingService listingService,
           IPictureService pictureService,
           IListingPictureService listingPictureservice,
           IOrderService orderService,
           ICustomFieldService customFieldService,
           ICustomFieldCategoryService customFieldCategoryService,
           ICustomFieldListingService customFieldListingService,
           ISettingDictionaryService settingDictionaryService,
           IListingStatService listingStatservice,
           IListingReviewService listingReviewService,
           IEmailTemplateService emailTemplateService,
           IMessageService messageService,
           IMessageThreadService messageThreadService,
           IMessageParticipantService messageParticipantService,
           IMessageReadStateService messageReadStateService,
           DataCacheService dataCacheService,
           SqlDbService sqlDbService)
        {
            _settingService = settingService;
            _settingDictionaryService = settingDictionaryService;
            _categoryService = categoryService;
            _unidadesService = unidadesService;
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
            _modalidadesCompraService = modalidadesCompraService;
            _tiposFreteService = tiposFreteService;
            _formasPagamentoService = formasPagamentoService;
            _listingService = listingService;
            _listingReviewService = listingReviewService;
            _pictureService = pictureService;
            _listingPictureservice = listingPictureservice;
            _orderService = orderService;
            _customFieldService = customFieldService;
            _customFieldCategoryService = customFieldCategoryService;
            _customFieldListingService = customFieldListingService;
            _ListingStatservice = listingStatservice;
            _emailTemplateService = emailTemplateService;
            _messageService = messageService;
            _messageParticipantService = messageParticipantService;
            _messageReadStateService = messageReadStateService;
            _messageThreadService = messageThreadService;
            _dataCacheService = dataCacheService;
            _sqlDbService = sqlDbService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        #endregion

        #region Methods
        //http://stackoverflow.com/questions/11774741/load-partial-view-depending-on-dropdown-selection-in-mvc3
        public async Task<ActionResult> ListingPartial(int categoryID)
        {
            // Custom fields
            var customFieldCategoryQuery = await _customFieldCategoryService.Query(x => x.CategoryID == categoryID).Include(x => x.MetaField.ListingMetas).SelectAsync();
            var customFieldCategories = customFieldCategoryQuery.ToList();
            var customFieldModel = new CustomFieldListingModel()
            {
                MetaCategories = customFieldCategories
            };

            return PartialView("_CategoryCustomFields", customFieldModel);
        }

        public async Task<ActionResult> ListingTypesPartial(int categoryID, int listingID)
        {
            var model = new ListingUpdateModel();
            model.ListingTypes = CacheHelper.ListingTypes.Where(x => x.CategoryListingTypes.Any(y => y.CategoryID == categoryID)).ToList();
            model.ListingItem = new Listing();

            if (listingID > 0)
                model.ListingItem = await _listingService.FindAsync(listingID);

            model.ListingTypeID = model.ListingItem.ListingTypeID;

            return PartialView("_ListingTypes", model);
        }

        [HttpGet]
        public ActionResult ListingType(int listingTypeID)
        {
            var listingType = CacheHelper.ListingTypes.Where(x => x.ID == listingTypeID).FirstOrDefault();

            if (listingType == null)
                return new JsonResult();

            return Json(new
            {
                PaymentEnabled = listingType.PaymentEnabled,
                PriceEnabled = listingType.PriceEnabled
            }, JsonRequestBehavior.AllowGet);
        }

        //// GET: BestPrice
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        public async Task<ActionResult> BestPriceUpdate(int? id, string userId_, int? oqeq)
        {
            if (CacheHelper.Categories.Count == 0)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Ainda não há categorias disponíveis]]]";
            }

            Listing listing;
            IntencoesCompra intencomp;

            //var userId = User.Identity.GetUserId();
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            var model = new PurchaseUpdateModel()
            {
                Categories = CacheHelper.Categories,
                Unidades = CacheHelper.Unidades,
                TiposFrete = CacheHelper.TiposFrete,
                ModalidadesCompra = CacheHelper.ModalidadesCompra,
                FormasPagamento = CacheHelper.FormasPagamento
            };

            if (id.HasValue)
            {
                listing = await _listingService.FindAsync(id);
                intencomp = await _intencoesCompraService.FindAsync(id);
            }
            else
            {
                listing = new Listing()
                {
                    CategoryID = CacheHelper.Categories.Any() ? CacheHelper.Categories.FirstOrDefault().ID : 0,
                    Created = DateTime.Now.Date,
                    LastUpdated = DateTime.Now.Date,
                    Expiration = DateTime.MaxValue,
                    Enabled = true,
                    Active = true,
                    UnidadeProduto = CacheHelper.Unidades.Any() ? CacheHelper.Unidades.FirstOrDefault().descricaoUnidade : ""
                };

                intencomp = new IntencoesCompra()
                {
                    CategoryID = CacheHelper.Categories.Any() ? CacheHelper.Categories.FirstOrDefault().ID : 0,
                    UnidadeProduto = CacheHelper.Unidades.Any() ? CacheHelper.Unidades.FirstOrDefault().descricaoUnidade : "",
                    id_ModalCompra = CacheHelper.ModalidadesCompra.Any() ? CacheHelper.ModalidadesCompra.FirstOrDefault().id_ModalCompra : 0,
                    id_TipoFrete = CacheHelper.TiposFrete.Any() ? CacheHelper.TiposFrete.FirstOrDefault().id_TipoFrete : 0,
                    id_FormaPgto = CacheHelper.FormasPagamento.Any() ? CacheHelper.FormasPagamento.FirstOrDefault().id_FormaPgto : 0
                };

                if (User.Identity.IsAuthenticated)
                {
                    listing.ContactEmail = user.Email;
                    listing.ContactName = string.Format("{0} {1}", user.FirstName, user.LastName);
                    listing.ContactPhone = user.PhoneNumber;
                }
            }

            // Populate model with listing
            await PopulatePurchaseUpdateModel(listing, intencomp, model, userId);

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            return View("~/Views/BestPrice/BestPriceUpdate.cshtml", model);
        }

        private async Task<PurchaseUpdateModel> PopulateListingUpdateModel(Listing listing, PurchaseUpdateModel model)
        {
            model.ListingItem = listing;

            // Custom fields
            var customFieldCategoryQuery = await _customFieldCategoryService.Query(x => x.CategoryID == listing.CategoryID).Include(x => x.MetaField.ListingMetas).SelectAsync();
            var customFieldCategories = customFieldCategoryQuery.ToList();
            var customFieldModel = new CustomFieldListingModel()
            {
                ListingID = listing.ID,
                MetaCategories = customFieldCategories
            };

            model.CustomFields = customFieldModel;
            model.UserID = listing.UserID;
            model.CategoryID = listing.CategoryID;
            model.ListingTypeID = listing.ListingTypeID;

            // Listing types
            model.ListingTypes = CacheHelper.ListingTypes.Where(x => x.CategoryListingTypes.Any(y => y.CategoryID == model.CategoryID)).ToList();

            // Listing Categories
            model.Categories = CacheHelper.Categories;

            return model;
        }

        /// <summary>
        /// Gravação dos dados de DESEJO COMPRAR, de um comprador do MKTPLACE. Inclusão de NOVO e EDIÇÃO
        /// </summary>
        /// <param name="intencaoCompra"></param>
        /// <param name="form"></param>
        /// <param name="files"></param>
        /// <param name="oqeq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PurchaseUpdate(IntencoesCompra intencaoCompra, FormCollection form, IEnumerable<HttpPostedFileBase> files, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            bool updateCount = false;
            int operation; // 0 - Inclusão Oferta de Compra / 1 - Edição de Oferta de Compra

            if (Convert.ToInt32(form.Get("idPurchase")) == 0)
            {
                //INSERIR NOVO ITEM
                updateCount = true;

                string dataLimite = DateTime.Now.AddDays(30).Year.ToString() + "-" + DateTime.Now.AddDays(30).Month.ToString() + "-" + DateTime.Now.AddDays(30).Day.ToString();
                var intencaoDeCompra = new IntencoesCompra()
                {
                    Id = userIdCurrent,
                    id_TipoFrete = Convert.ToInt32(form.Get("TipoFrete")),
                    id_ModalCompra = Convert.ToInt32(form.Get("ModalidadeCompra")),
                    CategoryID = Convert.ToInt32(form.Get("CategoryID")),
                    id_FormaPgto = (form.Get("FormaPagamento") != null) ? Convert.ToInt32(form.Get("FormaPagamento")) : 1,
                    Location = form.Get("Location"),
                    DescricaoProduto = form.Get("inProdutoCompra"),
                    QuantidadeTotalItensAComprar = Convert.ToDecimal(Regex.Replace(form.Get("inQuantTotalCompra"), "[.]", "").Replace(",", ".")),
                    QuantidadeMinimaItensAComprar = Convert.ToDecimal(Regex.Replace(form.Get("inQuantMinimaPorVendedor"), "[.]", "").Replace(",", ".")),
                    UnidadeProduto = form.Get("UnidadeProduto"),
                    MnhaOfertaDePreco = (!String.IsNullOrEmpty(form.Get("inMinhaOfertaPreco"))) ? Convert.ToDecimal(Regex.Replace(form.Get("inMinhaOfertaPreco"), "[.]", "").Replace(",", ".")) : 0,
                    DataCadastroOferta = DateTime.Now,
                    OfertaValidaAte = Convert.ToDateTime(dataLimite),
                    ObservacoesRelevantes = form.Get("inObsRelevant")
                };

                intencaoCompra = intencaoDeCompra;
                _intencoesCompraService.Insert(intencaoCompra);
                operation = 0;
            }
            else
            {
                //EDITAR ITEM
                if (await NotMeListing(Convert.ToInt32(form.Get("idPurchase"))))
                    return new HttpUnauthorizedResult();

                var intencaoCompraExisting = await _intencoesCompraService.FindAsync(Convert.ToInt32(form.Get("idPurchase")));

                intencaoCompraExisting.id_TipoFrete = Convert.ToInt32(form.Get("TipoFrete"));
                intencaoCompraExisting.id_ModalCompra = Convert.ToInt32(form.Get("ModalidadeCompra"));
                intencaoCompraExisting.CategoryID = Convert.ToInt32(form.Get("CategoryID"));
                intencaoCompraExisting.id_FormaPgto = (form.Get("FormaPagamento") != null) ? Convert.ToInt32(form.Get("FormaPagamento")) : 1;
                intencaoCompraExisting.Location = form.Get("Location");
                intencaoCompraExisting.DescricaoProduto = form.Get("inProdutoCompra");
                intencaoCompraExisting.QuantidadeTotalItensAComprar = Convert.ToDecimal(Regex.Replace(form.Get("inQuantTotalCompra"), "[.]", "").Replace(",", "."));
                intencaoCompraExisting.QuantidadeMinimaItensAComprar = Convert.ToDecimal(Regex.Replace(form.Get("inQuantMinimaPorVendedor"), "[.]", "").Replace(",", "."));
                intencaoCompraExisting.UnidadeProduto = form.Get("UnidadeProduto");
                intencaoCompraExisting.MnhaOfertaDePreco = (!String.IsNullOrEmpty(form.Get("inMinhaOfertaPreco"))) ? Convert.ToDecimal(Regex.Replace(form.Get("inMinhaOfertaPreco"), "[.]", "").Replace(",", ".")) : 0;
                intencaoCompraExisting.ObservacoesRelevantes = form.Get("inObsRelevant");
                intencaoCompraExisting.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;

                intencaoCompra = intencaoCompraExisting;
                _intencoesCompraService.Update(intencaoCompra);
                operation = 1;
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[Oferta de Compra incluída com Sucesso!]]]" : "[[[Oferta de Compra alterada com Sucesso!]]]";
            return RedirectToAction("PurchaseUpdate", new { id = intencaoCompra.id_IC, userId_ = userIdCurrent });
        }

        public async Task<bool> NotMeListing(int id)
        {
            var userId = User.Identity.GetUserId();
            var item = await _listingService.FindAsync(id);
            return item.UserID != userId;
        }

        private async Task<PurchaseUpdateModel> PopulatePurchaseUpdateModel(Listing listing, IntencoesCompra intencomp, PurchaseUpdateModel model, string userId)
        {
            model.ListingItem = listing;
            model.ICItem = intencomp;

            // Custom fields
            var customFieldCategoryQuery = await _customFieldCategoryService.Query(x => x.CategoryID == listing.CategoryID).Include(x => x.MetaField.ListingMetas).SelectAsync();
            var customFieldCategories = customFieldCategoryQuery.ToList();
            var customFieldModel = new CustomFieldListingModel()
            {
                ListingID = listing.ID,
                MetaCategories = customFieldCategories
            };

            model.CustomFields = customFieldModel;
            model.UserID = (listing.UserID != null) ? listing.UserID : userId;
            model.CategoryID = listing.CategoryID;
            model.ListingTypeID = listing.ListingTypeID;
            model.QuantidadeTotalCompra = (intencomp.QuantidadeTotalItensAComprar > 0) ? intencomp.QuantidadeTotalItensAComprar.ToString("N2") : "";
            model.QuantidadeMinimaCompra = (intencomp.QuantidadeMinimaItensAComprar > 0) ? intencomp.QuantidadeMinimaItensAComprar.ToString("N2") : "";
            model.MnhaOfertaDePreco = (intencomp.MnhaOfertaDePreco > 0) ? intencomp.MnhaOfertaDePreco.ToString("N2") : "";
            model.OfertaValidaAte = (intencomp.id_IC > 0) ? String.Format("{0:dd/MM/yyyy}", intencomp.OfertaValidaAte) : String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(30));
            model.CategoryID = model.ICItem.CategoryID;

            //// Listing types
            //model.ListingTypes = CacheHelper.ListingTypes.Where(x => x.CategoryListingTypes.Any(y => y.CategoryID == model.CategoryID)).ToList();

            // Listing Categories
            model.Categories = CacheHelper.Categories;

            return model;
        }

        [HttpPost]
        public async Task<ActionResult> PurchaseDelete(int id)
        {
            var item = await _intencoesCompraService.FindAsync(id);
            var orderQuery = await _orderService.Query(x => x.ListingID == id).SelectAsync();

            // Excluir item se a data atual for maior que a data limite da oferta
            if (DateTime.Now <= item.OfertaValidaAte)
            {
                var resultFailed = new { Success = false, Message = "[[[A oferta não pode ser excluída pois a data limite ainda não expirou]]]" };
                return Json(resultFailed, JsonRequestBehavior.AllowGet);
            }

            await _intencoesCompraService.DeleteAsync(id);
            await _unitOfWorkAsync.SaveChangesAsync();

            var result = new { Success = true, Message = "[[[A oferta de compra foi excluída]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [AllowAnonymous]
        public async new Task<ActionResult> Profile(string id, int? oqeq)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
                return new HttpNotFoundResult();

            var items = await _listingService.Query(x => x.UserID == id)
                .Include(x => x.ListingPictures)
                .Include(x => x.ListingType)
                .Include(x => x.AspNetUser)
                .Include(x => x.ListingReviews)
                .SelectAsync();

            var itemsModel = new List<ListingItemModel>();
            foreach (var item in items.OrderByDescending(x => x.Created))
            {
                itemsModel.Add(new ListingItemModel()
                {
                    ListingCurrent = item,
                    UrlPicture = item.ListingPictures.Count == 0 ? ImageHelper.GetListingImagePath(0) : ImageHelper.GetListingImagePath(item.ListingPictures.OrderBy(x => x.Ordering).FirstOrDefault().PictureID)
                });
            }

            // include reviews
            var reviews = await _listingReviewService
                .Query(x => x.UserTo == id)
                .Include(x => x.AspNetUserFrom)
                .SelectAsync();

            var model = new ProfileModel()
            {
                Listings = itemsModel,
                User = user,
                ListingReviews = reviews.ToList()
            };

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            return View("~/Views/Listing/Profile.cshtml", model);
        }

        public async Task<ActionResult> ContactUser(ContactUserModel model)
        {
            var listing = await _listingService.FindAsync(model.ListingID);

            var userIdCurrent = User.Identity.GetUserId();
            var user = userIdCurrent.User();

            // Check if user send message to itself, which is not allowed
            if (listing.UserID == userIdCurrent)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[You cannot send message to yourself!]]]";
                return RedirectToAction("Listing", "Listing", new { id = model.ListingID });
            }

            // Send message to user
            var message = new MessageSendModel()
            {
                UserFrom = userIdCurrent,
                UserTo = listing.UserID,
                Subject = listing.Title,
                Body = model.Message,
                ListingID = listing.ID
            };

            await MessageHelper.SendMessage(message);

            // Send email with notification
            var emailTemplateQuery = await _emailTemplateService.Query(x => x.Slug.ToLower() == "privatemessage").SelectAsync();
            var emailTemplate = emailTemplateQuery.Single();

            dynamic email = new Postal.Email("Email");
            email.To = user.Email;
            email.From = CacheHelper.Settings.EmailAddress;
            email.Subject = emailTemplate.Subject;
            email.Body = emailTemplate.Body;
            email.Message = model.Message;
            EmailHelper.SendEmail(email);

            TempData[TempDataKeys.UserMessage] = "[[[Message sent succesfully!]]]";

            return RedirectToAction("Listing", "Listing", new { id = model.ListingID });
        }

        /// <summary>
        /// review for an order on a listing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Review(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            // check if user has right to review the order            
            var reviewModel = new ListingReview();

            var orderQuery = await _orderService
                .Query(x => x.ID == id)
                .Include(x => x.Listing)
                .Include(x => x.Listing.AspNetUser)
                .Include(x => x.Listing.ListingType)
                .Include(x => x.Listing.ListingReviews)
                .Include(x => x.AspNetUserProvider)
                .Include(x => x.AspNetUserReceiver)
                .SelectAsync();

            var order = orderQuery.FirstOrDefault();

            reviewModel.Listing = order.Listing;
            reviewModel.OrderID = order.ID;
            reviewModel.ListingID = order.ListingID;

            // set user for review
            reviewModel.AspNetUserTo = currentUserId == order.UserProvider ? order.AspNetUserReceiver : order.AspNetUserProvider;

            return View(reviewModel);
        }

        /// <summary>
        /// Submit review
        /// </summary>
        /// <param name="listingReview"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Review(ListingReview listingReview)
        {
            var currentUserId = User.Identity.GetUserId();

            var orderQuery = await _orderService.Query(x => x.ID == listingReview.OrderID)
                .Include(x => x.Listing)
                .SelectAsync();

            var order = orderQuery.FirstOrDefault();

            var userTo = order.UserProvider == currentUserId ? order.UserReceiver : order.UserProvider;

            // User cannot comment himself
            if (currentUserId == userTo)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Você não pode avaliar a si mesmo!]]]";
                return RedirectToAction("Orders", "Payment");
            }

            // check if user has right to review the order
            if (order == null || (order.UserProvider != currentUserId && order.UserReceiver != currentUserId))
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[You cannot review the order!]]]";
                return RedirectToAction("Orders", "Payment");
            }

            // update review id on the order
            var review = new ListingReview()
            {
                UserFrom = currentUserId,
                UserTo = userTo,
                OrderID = listingReview.OrderID,
                Description = listingReview.Description,
                Rating = listingReview.Rating,
                Spam = false,
                Active = true,
                Enabled = true,
                ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added,
                Created = DateTime.Now
            };

            // Set listing id if it's service receiver
            if (order.UserReceiver == currentUserId)
                review.ListingID = order.ListingID;

            _listingReviewService.Insert(review);

            await _unitOfWorkAsync.SaveChangesAsync();

            // update rating on the user            
            var listingReviewQuery = await _listingReviewService.Query(x => x.UserTo == userTo).SelectAsync();
            var rating = listingReviewQuery.Average(x => x.Rating);

            var user = await UserManager.FindByIdAsync(userTo);
            user.Rating = rating;
            await UserManager.UpdateAsync(user);

            // Notify the user with the rating and comment
            var message = new MessageSendModel()
            {
                UserFrom = review.UserFrom,
                UserTo = review.UserTo,
                Subject = review.Title,
                Body = string.Format("{0} <span class=\"score s{1} text-xs\"></span>", review.Description, review.RatingClass),
                ListingID = order.ListingID
            };

            await MessageHelper.SendMessage(message);

            TempData[TempDataKeys.UserMessage] = "[[[Obrigado pelo seu feedback!]]]";
            return RedirectToAction("Orders", "Payment");
        }

        /// <summary>
        /// Submit review by listing id
        /// </summary>
        /// <param name="listingReview"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ReviewListing(ListingReview listingReview)
        {
            var currentUserId = User.Identity.GetUserId();

            // Check if listing review is enabled
            if (!CacheHelper.Settings.ListingReviewEnabled)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Listing review is not allowed!]]]";
                return RedirectToAction("Listing", "Listing", new { id = listingReview.ID });
            }

            // Check if users reach max review limit       
            var today = DateTime.Today.Date;
            var reviewQuery = await _listingReviewService.Query(x => x.UserFrom == currentUserId
            && System.Data.Entity.DbFunctions.TruncateTime(x.Created) == today).SelectAsync();
            var reviewCount = reviewQuery.Count();

            if (reviewCount >= CacheHelper.Settings.ListingReviewMaxPerDay)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[You have reach the review limits today!]]]";
                return RedirectToAction("Listing", "Listing", new { id = listingReview.ID });
            }

            var listingQuery = await _listingService.Query(x => x.ID == listingReview.ID)
                .Include(x => x.AspNetUser)
                .SelectAsync();

            var listing = listingQuery.FirstOrDefault();

            // User cannot comment himself
            if (currentUserId == listing.UserID)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Você não pode avaliar a si mesmo!]]]";
                return RedirectToAction("Listing", "Listing", new { id = listingReview.ID });
            }

            // update review id on the order
            var review = new ListingReview()
            {
                UserFrom = currentUserId,
                UserTo = listing.UserID,
                Description = listingReview.Description,
                Rating = listingReview.Rating,
                Spam = false,
                Active = true,
                Enabled = true,
                ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added,
                Created = DateTime.Now
            };

            review.ListingID = listingReview.ID;

            _listingReviewService.Insert(review);

            await _unitOfWorkAsync.SaveChangesAsync();

            // update rating on the user            
            var listingReviewQuery = await _listingReviewService.Query(x => x.UserTo == listing.UserID).SelectAsync();
            var rating = listingReviewQuery.Average(x => x.Rating);

            var user = await UserManager.FindByIdAsync(listing.UserID);
            user.Rating = rating;
            await UserManager.UpdateAsync(user);

            // Notify the user with the rating and comment
            var message = new MessageSendModel()
            {
                UserFrom = review.UserFrom,
                UserTo = review.UserTo,
                Subject = review.Title,
                Body = string.Format("{0} <span class=\"score s{1} text-xs\"></span>", review.Description, review.RatingClass),
                ListingID = listingReview.ID
            };

            await MessageHelper.SendMessage(message);

            TempData[TempDataKeys.UserMessage] = "[[[Obrigado pelo seu feedback!]]]";
            return RedirectToAction("Listing", "Listing", new { id = listingReview.ID });
        }
        #endregion
    }
}