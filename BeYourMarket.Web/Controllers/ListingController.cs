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
using BeYourMarket.Core.Controllers;

namespace BeYourMarket.Web.Controllers
{
    [Authorize]
    public class ListingController : Controller
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
        private readonly ITipoAnimalPecuariaService _tipoAnimalPecuariaService;
        private readonly ITiposRacasAnimaisPecuariaService _tiposRacasAnimaisService;
        private readonly ITipoAnimalProducaoService _tipoAnimalProducaoService;
        private readonly IInsurersService _insurersService;
        private readonly IOperationTypeService _operationTypeService;
        private readonly IChatOfertaService _chatOfertaService;
        private readonly IShippingCompanyService _shippingCompanyService;
        //private readonly ITiposFreteService _tiposFreteService;
        private readonly IVideosOfertaService _videosOfertaService;
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
        public ListingController(
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
           ITipoAnimalPecuariaService tipoAnimalPecuariaService,
           ITiposRacasAnimaisPecuariaService tiposRacasAnimaisService,
           ITipoAnimalProducaoService tipoAnimalProducaoService,
           IInsurersService insurersService,
           IOperationTypeService operationTypeService,
           IChatOfertaService chatOfertaService,
           IShippingCompanyService shippingCompanyService,
           IVideosOfertaService videosOfertaService,
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
            _tipoAnimalPecuariaService = tipoAnimalPecuariaService;
            _tiposRacasAnimaisService = tiposRacasAnimaisService;
            _tipoAnimalProducaoService = tipoAnimalProducaoService;
            _insurersService = insurersService;
            _operationTypeService = operationTypeService;
            _chatOfertaService = chatOfertaService;
            _shippingCompanyService = shippingCompanyService;
            _videosOfertaService = videosOfertaService;
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

        [AllowAnonymous]
        public async Task<ActionResult> BuyInAction(int? id, int? oqeq, int? tp = null)
        {
            //Usuário logado, interessado em Comprar
            var userId = User.Identity.GetUserId();

            if (id.HasValue)
            {
                // return unauthorized if not authenticated
                if (!User.Identity.IsAuthenticated)
                    return new HttpUnauthorizedResult();
            }

            var itemQuery = await _listingService.Query(x => x.ID == id)
                                .Include(x => x.Category)
                                .Include(x => x.ListingMetas)
                                .Include(x => x.ListingMetas.Select(y => y.MetaField))
                                .Include(x => x.ListingStats)
                                .Include(x => x.ListingType)
                                .SelectAsync();

            var item = itemQuery.FirstOrDefault();

            if (item == null)
                return new HttpNotFoundResult();

            var orders = _orderService.Queryable()
                .Where(x => x.ListingID == id
                    && (x.Status != (int)Enum_OrderStatus.Pending || x.Status != (int)Enum_OrderStatus.Confirmed)
                    && (x.FromDate.HasValue && x.ToDate.HasValue)
                    && (x.FromDate >= DateTime.Now || x.ToDate >= DateTime.Now))
                    .ToList();

            List<DateTime> datesBooked = new List<DateTime>();
            foreach (var order in orders)
            {
                for (DateTime date = order.FromDate.Value; date <= order.ToDate.Value; date = date.Date.AddDays(1))
                {
                    datesBooked.Add(date);
                }
            }

            var pictures = await _listingPictureservice.Query(x => x.ListingID == id).SelectAsync();

            var picturesModel = pictures.Select(x =>
                new PictureModel()
                {
                    ID = x.PictureID,
                    Url = ImageHelper.GetListingImagePath(x.PictureID),
                    ListingID = x.ListingID,
                    Ordering = x.Ordering
                }).OrderBy(x => x.Ordering).ToList();

            var reviews = await _listingReviewService
                .Query(x => x.UserTo == item.UserID)
                .Include(x => x.AspNetUserFrom)
                .SelectAsync();

            //Dados do Usuário que Publicou a Oferta
            var user = await UserManager.FindByIdAsync(item.UserID);
            var itemModel = new ListingItemModel()
            {
                ListingCurrent = item,
                Pictures = picturesModel,
                DatesBooked = datesBooked,
                User = user,
                ListingReviews = reviews.ToList(),
                TpAcess = ((tp == 1) ? tp : 2)
            };

            // Update stat count
            var itemStat = item.ListingStats.FirstOrDefault();
            if (itemStat == null)
            {
                _ListingStatservice.Insert(new ListingStat()
                {
                    ListingID = (int)id,
                    CountView = 1,
                    Created = DateTime.Now,
                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                });
            }
            else
            {
                itemStat.CountView++;
                itemStat.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _ListingStatservice.Update(itemStat);
            }

            //await _unitOfWorkAsync.SaveChangesAsync();

            await PopulateListingUpdateModelOffer(itemModel, userId);
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            ViewBag.idOferta = id;

            return View("~/Views/Listing/BuyItemOffer.cshtml", itemModel);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Buying(int? idOf, int qt, int oqeq = 0, int? tp = null)
        {
            //Usuário logado, interessado em Comprar
            var userId = User.Identity.GetUserId();

            if (idOf.HasValue)
            {
                // return unauthorized if not authenticated
                if (!User.Identity.IsAuthenticated)
                    return new HttpUnauthorizedResult();
            }

            var itemQuery = await _listingService.Query(x => x.ID == idOf)
                                .Include(x => x.Category)
                                .Include(x => x.ListingMetas)
                                .Include(x => x.ListingMetas.Select(y => y.MetaField))
                                .Include(x => x.ListingStats)
                                .Include(x => x.ListingType)
                                .SelectAsync();

            var item = itemQuery.FirstOrDefault();

            if (item == null)
                return new HttpNotFoundResult();

            var orders = _orderService.Queryable()
                .Where(x => x.ListingID == idOf
                    && (x.Status != (int)Enum_OrderStatus.Pending || x.Status != (int)Enum_OrderStatus.Confirmed)
                    && (x.FromDate.HasValue && x.ToDate.HasValue)
                    && (x.FromDate >= DateTime.Now || x.ToDate >= DateTime.Now))
                    .ToList();

            List<DateTime> datesBooked = new List<DateTime>();
            foreach (var order in orders)
            {
                for (DateTime date = order.FromDate.Value; date <= order.ToDate.Value; date = date.Date.AddDays(1))
                {
                    datesBooked.Add(date);
                }
            }

            var pictures = await _listingPictureservice.Query(x => x.ListingID == idOf).SelectAsync();
            var picturesModel = pictures.Select(x =>
                new PictureModel()
                {
                    ID = x.PictureID,
                    Url = ImageHelper.GetListingImagePath(x.PictureID),
                    ListingID = x.ListingID,
                    Ordering = x.Ordering
                }).OrderBy(x => x.Ordering).ToList();

            var reviews = await _listingReviewService
                .Query(x => x.UserTo == item.UserID)
                .Include(x => x.AspNetUserFrom)
                .SelectAsync();

            //Dados do Usuário que Publicou a Oferta
            var user = await UserManager.FindByIdAsync(item.UserID);
            //Dados do Usuáruio interessado em Comprar o Item Ofertado
            var buyerUser = await UserManager.FindByIdAsync(userId);

            var listaTransportadoras = await _shippingCompanyService.Query(x => x.Id_SC > 0).SelectAsync();
            var transpHabilitadas = listaTransportadoras.Where(s => (s.Habilitado_View_Plataforma_SC)).ToList();
            var itemModel = new ListingItemModel()
            {
                ListingCurrent = item,
                Pictures = picturesModel,
                DatesBooked = datesBooked,
                User = user,
                ListingReviews = reviews.ToList(),
                TpAcess = ((tp == 1) ? tp : 2),
                UsuarioComprador = buyerUser,
                quantDesejaComprar = qt.ToString("N2"),
                quantCompraCalc = qt,
                CompanhiasTransporte = transpHabilitadas
            };

            itemModel.CompanhiasTransporte.Add(new ShippingCompany { Id_SC = 0, Nome_Fantasia_SC = "", Razao_Social_SC = "", Habilitado_View_Plataforma_SC = true });
            itemModel.CompanhiasTransporte = itemModel.CompanhiasTransporte.OrderBy(c => (c.Id_SC)).ToList();

            // Update stat count
            var itemStat = item.ListingStats.FirstOrDefault();
            if (itemStat == null)
            {
                _ListingStatservice.Insert(new ListingStat()
                {
                    ListingID = (int)idOf,
                    CountView = 1,
                    Created = DateTime.Now,
                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                });
            }
            else
            {
                itemStat.CountView++;
                itemStat.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _ListingStatservice.Update(itemStat);
            }

            await PopulateListingUpdateModelOffer(itemModel, userId);
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            ViewBag.idOferta = idOf;

            return View("~/Views/Listing/BuyItemOffer2.cshtml", itemModel);
        }

        //===========================================================================================
        [AllowAnonymous]    // CONTINUAR AQUI... PREPARAR PRA CARREGAR A VIEW DO FATURAMENTO E CONTRATAÇÃO DO FRETE --> Nomear como Billing.cshtml
        public async Task<ActionResult> Invoicing(int? idOf, int qt, int? oqeq)
        {
            //Usuário logado, interessado em Comprar
            var userId = User.Identity.GetUserId();

            if (idOf.HasValue)
            {
                // return unauthorized if not authenticated
                if (!User.Identity.IsAuthenticated)
                    return new HttpUnauthorizedResult();
            }

            var itemQuery = await _listingService.Query(x => x.ID == idOf)
                                .Include(x => x.Category)
                                .Include(x => x.ListingMetas)
                                .Include(x => x.ListingMetas.Select(y => y.MetaField))
                                .Include(x => x.ListingStats)
                                .Include(x => x.ListingType)
                                .SelectAsync();

            var item = itemQuery.FirstOrDefault();

            if (item == null)
                return new HttpNotFoundResult();

            var orders = _orderService.Queryable()
                .Where(x => x.ListingID == idOf
                    && (x.Status != (int)Enum_OrderStatus.Pending || x.Status != (int)Enum_OrderStatus.Confirmed)
                    && (x.FromDate.HasValue && x.ToDate.HasValue)
                    && (x.FromDate >= DateTime.Now || x.ToDate >= DateTime.Now))
                    .ToList();

            List<DateTime> datesBooked = new List<DateTime>();
            foreach (var order in orders)
            {
                for (DateTime date = order.FromDate.Value; date <= order.ToDate.Value; date = date.Date.AddDays(1))
                {
                    datesBooked.Add(date);
                }
            }

            var pictures = await _listingPictureservice.Query(x => x.ListingID == idOf).SelectAsync();
            var picturesModel = pictures.Select(x =>
                new PictureModel()
                {
                    ID = x.PictureID,
                    Url = ImageHelper.GetListingImagePath(x.PictureID),
                    ListingID = x.ListingID,
                    Ordering = x.Ordering
                }).OrderBy(x => x.Ordering).ToList();

            var reviews = await _listingReviewService
                .Query(x => x.UserTo == item.UserID)
                .Include(x => x.AspNetUserFrom)
                .SelectAsync();

            //Dados do Usuário que Publicou a Oferta
            var user = await UserManager.FindByIdAsync(item.UserID);
            //Dados do Usuáruio interessado em Comprar o Item Ofertado
            var buyerUser = await UserManager.FindByIdAsync(userId);

            var listaTransportadoras = await _shippingCompanyService.Query(x => x.Id_SC > 0).SelectAsync();
            var transpHabilitadas = listaTransportadoras.Where(s => (s.Habilitado_View_Plataforma_SC)).ToList();
            var itemModel = new ListingItemModel()
            {
                ListingCurrent = item,
                Pictures = picturesModel,
                DatesBooked = datesBooked,
                User = user,
                ListingReviews = reviews.ToList(),
                UsuarioComprador = buyerUser,
                quantDesejaComprar = qt.ToString("N2"),
                quantCompraCalc = qt,
                CompanhiasTransporte = transpHabilitadas
            };

            itemModel.CompanhiasTransporte.Add(new ShippingCompany { Id_SC = 0, Nome_Fantasia_SC = "", Razao_Social_SC = "", Habilitado_View_Plataforma_SC = true });
            itemModel.CompanhiasTransporte = itemModel.CompanhiasTransporte.OrderBy(c => (c.Id_SC)).ToList();

            // Update stat count
            var itemStat = item.ListingStats.FirstOrDefault();
            if (itemStat == null)
            {
                _ListingStatservice.Insert(new ListingStat()
                {
                    ListingID = (int)idOf,
                    CountView = 1,
                    Created = DateTime.Now,
                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                });
            }
            else
            {
                itemStat.CountView++;
                itemStat.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _ListingStatservice.Update(itemStat);
            }

            await PopulateListingUpdateModelOffer(itemModel, userId);
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            ViewBag.idOferta = idOf;

            //return View("~/Views/Listing/BuyItemOffer2.cshtml", itemModel);

            return View(itemModel); 
        }
        //===========================================================================================

        [AllowAnonymous]
        public async Task<ActionResult> ListingUpdate(int? id, int? oqeq)
        {
            if (CacheHelper.Categories.Count == 0)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Ainda não há categorias disponíveis]]]";
            }

            Listing listing;
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var model = new ListingUpdateModel()
            {
                Categories = CacheHelper.Categories,
                Unidades = CacheHelper.Unidades,
                TiposFrete = CacheHelper.TiposFrete,
                ModalidadesCompra = CacheHelper.ModalidadesCompra,
                FormasPagamento = CacheHelper.FormasPagamento,
                TiposAnimaisProducao = CacheHelper.TiposAnimaisProducao,
                RacasAnimais = CacheHelper.TiposRacasAnimaisPecuaria.Where(t => (t.id_AnimalProducao == 1)).ToList(),
                EmpresasSeguradoras = CacheHelper.Insurers.Where(t => (t.id_Insurer > 0)).ToList()
            };

            model.Unidades.Add(new Unidades { id_Unidade = 0, descricaoUnidade = "" });

            if (id.HasValue)
            {
                // return unauthorized if not authenticated
                if (!User.Identity.IsAuthenticated)
                    return new HttpUnauthorizedResult();

                if (await NotMeListing(id.Value))
                    return new HttpUnauthorizedResult();

                listing = await _listingService.FindAsync(id);
                if (listing == null)
                    return new HttpNotFoundResult();

                // Pictures
                var pictures = await _listingPictureservice.Query(x => x.ListingID == id).SelectAsync();
                var picturesModel = pictures.Select(x =>
                    new PictureModel()
                    {
                        ID = x.PictureID,
                        Url = ImageHelper.GetListingImagePath(x.PictureID),
                        ListingID = x.ListingID,
                        Ordering = x.Ordering
                    }).OrderBy(x => x.Ordering).ToList();

                model.Pictures = picturesModel;
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

                if (User.Identity.IsAuthenticated)
                {
                    listing.ContactEmail = user.Email;
                    listing.ContactName = string.Format("{0} {1}", user.FirstName, user.LastName);
                    listing.ContactPhone = user.PhoneNumber;
                }
            }

            // Populate model with listing
            await PopulateListingUpdateModel(listing, model);
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            return View("~/Views/Listing/ListingUpdate.cshtml", model);
        }

        private async Task<ListingUpdateModel> PopulateListingUpdateModel(Listing listing, ListingUpdateModel model)
        {
            var tipoDeOperacao = await _operationTypeService.Query(x => x.id_OperationType > 0).SelectAsync();
            var tipOper = tipoDeOperacao.FirstOrDefault(t => t.id_OperationType == 1);
            var valorPorItemOferta = listing.Price.ToString();

            model.ListingItem = listing;
            model.inQuantidadeItenSale = (listing.QuantidadeItemSale > 0) ? listing.QuantidadeItemSale.ToString("N2") : "";
            model.inPesoUnitarioKg = (listing.PesoKgPorItemSale > 0) ? listing.PesoKgPorItemSale.ToString("N2") : "";
            model.inPesoUnitarioArrobas = (listing.PesoArrobaPorItemSale > 0) ? listing.PesoArrobaPorItemSale.ToString("N2") : "";
            model.inPesoTotalLoteKg = (listing.PesoTotalLoteKgSale > 0) ? listing.PesoTotalLoteKgSale.ToString("N2") : "";
            model.inPesoTotalLoteArrobas = (listing.PesoTotalLoteArrobaSale > 0) ? listing.PesoTotalLoteArrobaSale.ToString("N2") : "";
            model.inValorPorAnimal = (listing.Price > 0) ? valorPorItemOferta : "";
            model.inValorTotalPorAnimalSale = (listing.ValorTotalPorAnimalSale > 0) ? listing.ValorTotalPorAnimalSale.ToString("N2") : "";
            model.inValorTotalDoLoteSale = (listing.ValorTotalDoLoteSale > 0) ? listing.ValorTotalDoLoteSale.ToString("N2") : "";
            model.inValorTotalPorKgSale = (listing.ValorTotalPorKgSale > 0) ? listing.ValorTotalPorKgSale.ToString("N2") : "";
            model.inValorTotalPorArrobaSale = (listing.ValorTotalPorArrobaSale > 0) ? listing.ValorTotalPorArrobaSale.ToString("N2") : "";
            model.inValorTotalPorAnimalSale = (listing.ValorTotalPorAnimalSale > 0) ? listing.ValorTotalPorAnimalSale.ToString("N2") : "";
            model.inValorTaxaPlataforma = (listing.ValorComissao > 0) ? listing.ValorComissao.ToString("N2") : "";
            model.inValorTotalMaisTaxa = (listing.ValorTotalDoLoteSaleAddComissao > 0) ? listing.ValorTotalDoLoteSaleAddComissao.ToString("N2") : "";
            model.Linkcam = (listing.LinkCam != null) ? listing.LinkCam : "";
            model.inLocalRetirada = (listing.LocalRetirada != null) ? listing.LocalRetirada : "";
            model.inCidadeEstadoRetirada = (listing.Location != null) ? listing.Location : "";
            model.inReferenciaLocalRetirada = (listing.ReferenciaLocalRetirada != null) ? listing.ReferenciaLocalRetirada : "";
            model.SeguradoraID = (listing.id_Insurer != null) ? (int)listing.id_Insurer : 0;
            model.id_TipoFrete = listing.id_TipoFrete;
            model.inNumApolice = listing.NumApolice.ToString();
            model.inPercentTaxaPlat = tipOper.Percentual_Comissao.ToString().Replace(",", ".");
            model.UrlVideo = Path.Combine(Server.MapPath("~/Videos/"), listing.NomeVideoOferta);

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


        private async Task<ListingItemModel> PopulateListingUpdateModelOffer(ListingItemModel itemModel, string userId = null) 
        {
            //OBS: ALTERAR AS CONSULTAS ABAIXO USANDO O CACHELPER, VERIFICANDO COMO EXEMPLO O CONTAÚDO DA LINHA 633 A 634
            var tipoDeAnimal = await _tipoAnimalProducaoService.Query(x => x.id_AnimalProducao > 0).SelectAsync();
            var tipAnimal = tipoDeAnimal.FirstOrDefault(t => t.id_AnimalProducao == itemModel.ListingCurrent.id_AnimalProducao);
            var racaAnimal = await _tiposRacasAnimaisService.Query(x => x.id_TipoRacasAnimais > 0).SelectAsync();
            var raca = racaAnimal.FirstOrDefault(t => t.id_TipoRacasAnimais == itemModel.ListingCurrent.id_TipoRacasAnimais);
            var tiposFrete = await _tiposFreteService.Query(x => x.id_TipoFrete > 0).SelectAsync();
            var tpFrete = tiposFrete.FirstOrDefault(t => t.id_TipoFrete == itemModel.ListingCurrent.id_TipoFrete);
            var tipoDeOperacao = await _operationTypeService.Query(x => x.id_OperationType > 0).SelectAsync();
            var tipOper = tipoDeOperacao.FirstOrDefault(t => t.id_OperationType == itemModel.ListingCurrent.id_OperationType);
            var listaChatsOferta = await _chatOfertaService.Query(c => (c.id_Oferta == itemModel.ListingCurrent.ID)).SelectAsync();
            var listaChatsLogadoOferta = listaChatsOferta.Where(c => (c.id_Oferta == itemModel.ListingCurrent.ID)).ToList();

            itemModel.inQuantidadeItenSale = 
                ((itemModel.ListingCurrent.QuantidadeItensVenda != null) && (itemModel.ListingCurrent.QuantidadeItensVenda > 0)) ? itemModel.ListingCurrent.QuantidadeItensVenda.ToString() : itemModel.ListingCurrent.QuantidadeItemSale.ToString("N2");
            itemModel.inPesoUnitarioKg = (itemModel.ListingCurrent.PesoKgPorItemSale > 0) ? itemModel.ListingCurrent.PesoKgPorItemSale.ToString("N2") : "";
            itemModel.inPesoUnitarioArrobas = (itemModel.ListingCurrent.PesoArrobaPorItemSale > 0) ? itemModel.ListingCurrent.PesoArrobaPorItemSale.ToString("N2") : "";
            itemModel.inPesoTotalLoteKg = (itemModel.ListingCurrent.PesoTotalLoteKgSale > 0) ? itemModel.ListingCurrent.PesoTotalLoteKgSale.ToString("N2") : "";
            itemModel.inPesoTotalLoteArrobas = (itemModel.ListingCurrent.PesoTotalLoteArrobaSale > 0) ? itemModel.ListingCurrent.PesoTotalLoteArrobaSale.ToString("N2") : "";
            itemModel.inValorTotalPorAnimalSale = (itemModel.ListingCurrent.ValorTotalPorAnimalSale > 0) ? itemModel.ListingCurrent.ValorTotalPorAnimalSale.ToString("N2") : "";
            itemModel.inValorTotalDoLoteSale = (itemModel.ListingCurrent.ValorTotalDoLoteSale > 0) ? itemModel.ListingCurrent.ValorTotalDoLoteSale.ToString("N2") : "";
            itemModel.inValorTotalPorKgSale = (itemModel.ListingCurrent.ValorTotalPorKgSale > 0) ? itemModel.ListingCurrent.ValorTotalPorKgSale.ToString("N2") : "";
            itemModel.inValorTotalPorArrobaSale = (itemModel.ListingCurrent.ValorTotalPorArrobaSale > 0) ? itemModel.ListingCurrent.ValorTotalPorArrobaSale.ToString("N2") : "";
            itemModel.Linkcam = (itemModel.ListingCurrent.LinkCam != null) ? itemModel.ListingCurrent.LinkCam : "";
            itemModel.inLocalRetirada = (itemModel.ListingCurrent.LocalRetirada != null) ? itemModel.ListingCurrent.LocalRetirada : "";
            itemModel.inCidadeEstadoRetirada = (itemModel.ListingCurrent.Location != null) ? itemModel.ListingCurrent.Location : "";
            itemModel.inLocalRetirada = (itemModel.ListingCurrent.LocalRetirada != null) ? itemModel.ListingCurrent.LocalRetirada : "";
            itemModel.inReferenciaLocalRetirada = (itemModel.ListingCurrent.ReferenciaLocalRetirada != null) ? itemModel.ListingCurrent.ReferenciaLocalRetirada : "";
            itemModel.descricaoTipoAnimal = (tipAnimal != null) ? tipAnimal.Descricao_TipoAnimalProducao : "";
            itemModel.descricaoracaAnimal = (raca != null) ? raca.Descricao_TipoRacaAnimais : "";
            itemModel.inIdadeAnimais = (itemModel.ListingCurrent.IdadeAnimais != null) ? itemModel.ListingCurrent.IdadeAnimais : "";
            itemModel.ValorTotalDoLoteSale = (itemModel.ListingCurrent.ValorTotalDoLoteSale > 0) ? itemModel.ListingCurrent.ValorTotalDoLoteSale.ToString("N2") : "";
            itemModel.inReferenciaLocalRetirada = itemModel.ListingCurrent.ReferenciaLocalRetirada;
            itemModel.PesoKgPorItemSale = (itemModel.ListingCurrent.PesoKgPorItemSale > 0) ? itemModel.ListingCurrent.PesoKgPorItemSale.ToString("N2") : "";
            itemModel.inPesoUnitarioArrobas = (itemModel.ListingCurrent.PesoArrobaPorItemSale > 0) ? itemModel.ListingCurrent.PesoArrobaPorItemSale.ToString("N2") : "";
            itemModel.PesoTotalLoteKgSale = (itemModel.ListingCurrent.PesoTotalLoteKgSale > 0) ? itemModel.ListingCurrent.PesoTotalLoteKgSale.ToString("N2") : "";
            itemModel.PesoTotalLoteArrobaSale = (itemModel.ListingCurrent.PesoTotalLoteArrobaSale > 0) ? itemModel.ListingCurrent.PesoTotalLoteArrobaSale.ToString("N2") : "";
            itemModel.inValorPorAnimal = (itemModel.ListingCurrent.ValorTotalPorAnimalSale > 0) ? itemModel.ListingCurrent.ValorTotalPorAnimalSale.ToString("N2") : "";
            itemModel.inValorPorKg = (itemModel.ListingCurrent.ValorTotalPorKgSale > 0) ? itemModel.ListingCurrent.ValorTotalPorKgSale.ToString("N2") : "";
            itemModel.inValorPorArroba = (itemModel.ListingCurrent.ValorTotalPorArrobaSale > 0) ? itemModel.ListingCurrent.ValorTotalPorArrobaSale.ToString("N2") : "";
            itemModel.dataPublicacao = itemModel.ListingCurrent.Created.ToString("dd/MM/yyyy");
            itemModel.freteOferta = (tpFrete != null) ? tpFrete.Descricao_TipoFrete : "A combinar";
            itemModel.dataRegistroUserPubl = itemModel.User.RegisterDate.ToString("dd/MM/yyyy");
            itemModel.temDialogo = (listaChatsLogadoOferta.Count > 0) ? true : false;

            itemModel.vlrComissPlataforma = 
                (tipOper.Percentual_Comissao > 0) ? ((itemModel.ListingCurrent.ValorTotalDoLoteSale / 100) * ((int)tipOper.Percentual_Comissao)).ToString("N2") : "0,00";
            itemModel.totalOfertaMaisComissao = (itemModel.ListingCurrent.ValorTotalDoLoteSale + ((itemModel.ListingCurrent.ValorTotalDoLoteSale / 100) 
                * ((int)tipOper.Percentual_Comissao))).ToString("N2");

            if (itemModel.UsuarioComprador != null)
            {
                var cidade_Comprador = CacheHelper.Cidade.Where(c => c.ID == itemModel.UsuarioComprador.id_Cidade).FirstOrDefault().NOME;
                var uf_Comprador = CacheHelper.EstadoUf.Where(u => u.ID == itemModel.UsuarioComprador.id_UF).FirstOrDefault().NOME;
                itemModel.Cidade_UF_Comprador = cidade_Comprador + '-' + uf_Comprador;
            }

            itemModel.valorTotalDaCompra = (itemModel.quantCompraCalc * itemModel.ListingCurrent.ValorTotalPorAnimalSale).ToString("N2");

            return itemModel;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Listing(int id, int? oqeq, int? tp = null)
        {
            var itemQuery = await _listingService.Query(x => x.ID == id)
                .Include(x => x.Category)
                .Include(x => x.ListingMetas)
                .Include(x => x.ListingMetas.Select(y => y.MetaField))
                .Include(x => x.ListingStats)
                .Include(x => x.ListingType)
                .SelectAsync();

            var item = itemQuery.FirstOrDefault();

            if (item == null)
                return new HttpNotFoundResult();

            var orders = _orderService.Queryable()
                .Where(x => x.ListingID == id
                    && (x.Status != (int)Enum_OrderStatus.Pending || x.Status != (int)Enum_OrderStatus.Confirmed)
                    && (x.FromDate.HasValue && x.ToDate.HasValue)
                    && (x.FromDate >= DateTime.Now || x.ToDate >= DateTime.Now))
                    .ToList();

            List<DateTime> datesBooked = new List<DateTime>();
            foreach (var order in orders)
            {
                for (DateTime date = order.FromDate.Value; date <= order.ToDate.Value; date = date.Date.AddDays(1))
                {
                    datesBooked.Add(date);
                }
            }

            var pictures = await _listingPictureservice.Query(x => x.ListingID == id).SelectAsync();

            var picturesModel = pictures.Select(x =>
                new PictureModel()
                {
                    ID = x.PictureID,
                    Url = ImageHelper.GetListingImagePath(x.PictureID),
                    ListingID = x.ListingID,
                    Ordering = x.Ordering
                }).OrderBy(x => x.Ordering).ToList();

            var reviews = await _listingReviewService
                .Query(x => x.UserTo == item.UserID)
                .Include(x => x.AspNetUserFrom)
                .SelectAsync();

            var user = await UserManager.FindByIdAsync(item.UserID);

            var itemModel = new ListingItemModel()
            {
                ListingCurrent = item,
                Pictures = picturesModel,
                DatesBooked = datesBooked,
                User = user,
                ListingReviews = reviews.ToList(),
                TpAcess = ((tp == 1) ? tp : 2)
            };

            // Update stat count
            var itemStat = item.ListingStats.FirstOrDefault();
            if (itemStat == null)
            {
                _ListingStatservice.Insert(new ListingStat()
                {
                    ListingID = id,
                    CountView = 1,
                    Created = DateTime.Now,
                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                });
            }
            else
            {
                itemStat.CountView++;
                itemStat.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _ListingStatservice.Update(itemStat);
            }

            //await _unitOfWorkAsync.SaveChangesAsync();

            await PopulateListingUpdateModelOffer(itemModel);
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            ViewBag.idOferta = id;

            return View("~/Views/Listing/Listing.cshtml", itemModel);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        //public async Task<ActionResult> ListingUpdate(Listing listing, FormCollection form, IEnumerable<HttpPostedFileBase> files, IEnumerable<HttpPostedFileBase> fileVideoUploads, int? oqeq)
        public async Task<ActionResult> ListingUpdate(Listing listing, FormCollection form, IEnumerable<HttpPostedFileBase> files, HttpPostedFileBase fileVideoUploads, int? oqeq)
        {
            var tipoAcao = 1;
            var lote = "";
            int[] tipsOper = new int[] { 1, 2, 3, 4, 6 };

            if (CacheHelper.Categories.Count == 0)
            {
                TempData[TempDataKeys.UserMessageAlertState] = "bg-danger";
                TempData[TempDataKeys.UserMessage] = "[[[Ainda não há categorias disponíveis]]]";

                return RedirectToAction("Listing", new { id = listing.ID });
            }

            var userIdCurrent = User.Identity.GetUserId();

            // Register account if not login
            if (!User.Identity.IsAuthenticated)
            {
                var accountController = BeYourMarket.Core.ContainerManager.GetConfiguredContainer().Resolve<AccountController>();

                var modelRegister = new RegisterViewModel()
                {
                    Email = listing.ContactEmail,
                    Password = form["Password"],
                    ConfirmPassword = form["ConfirmPassword"],
                };

                // Parse first and last name
                var names = listing.ContactName.Split(' ');
                if (names.Length == 1)
                {
                    modelRegister.FirstName = names[0];
                }
                else if (names.Length == 2)
                {
                    modelRegister.FirstName = names[0];
                    modelRegister.LastName = names[1];
                }
                else if (names.Length > 2)
                {
                    modelRegister.FirstName = names[0];
                    modelRegister.LastName = listing.ContactName.Substring(listing.ContactName.IndexOf(" ") + 1);
                }

                // Register account
                var resultRegister = await accountController.RegisterAccount(modelRegister);

                // Add errors
                AddErrors(resultRegister);

                // Show errors if not succeed
                if (!resultRegister.Succeeded)
                {
                    var model = new ListingUpdateModel()
                    {
                        ListingItem = listing
                    };
                    // Populate model with listing
                    await PopulateListingUpdateModel(listing, model);
                    return View("ListingUpdate", model);
                }

                // update current user id
                var user = await UserManager.FindByNameAsync(listing.ContactEmail);
                userIdCurrent = user.Id;
            }

            bool updateCount = false;
            int nextPictureOrderId = 0;

            var tiposUnidades = await _unidadesService.Query(x => x.id_Unidade > 0).SelectAsync();
            var unidadeSelec = tiposUnidades.FirstOrDefault(t => t.id_Unidade == ((listing.CategoryID == 6) ? 5 : 6));

            listing.ListingTypeID = 4;

            if (listing.ID == 0)
            {
                //INSERIR NOVO ITEM
                var valorUnitAdComissao = 
                    (Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteMaisTaxaSale")).Replace(".", ",")) / Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inQuantidadeItemSale")).Replace(".", ",")));

                listing.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                listing.IP = Request.GetVisitorIP();
                listing.Expiration = DateTime.MaxValue.AddDays(-1);
                listing.UserID = userIdCurrent;
                listing.Enabled = true;
                listing.Currency = CacheHelper.Settings.Currency;
                listing.ListingTypeID = 3; //Valor Default
                listing.Active = true;
                listing.UnidadeProduto = (form.Get("UnidadeProduto") != null) ? form.Get("UnidadeProduto") : unidadeSelec.descricaoUnidade;
                listing.IdadeAnimais = form.Get("inIdadeAnimais");
                listing.QuantidadeItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inQuantidadeItemSale")).Replace(".", ","));
                listing.PesoKgPorItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoKgPorItemSale")).Replace(".", ","));
                listing.PesoArrobaPorItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoArrobaPorItemSale")).Replace(".", ","));
                listing.PesoTotalLoteKgSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoTotalLoteKgSale")).Replace(".", ","));
                listing.PesoTotalLoteArrobaSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoTotalLoteArrobaSale")).Replace(".", ","));
                listing.ValorTotalDoLoteSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteSale")).Replace(".", ","));
                listing.Price = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorAnimalSale")).Replace(".", ","));
                //listing.ValorTotalPorAnimalSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorAnimalSale")).Replace(".", ""));
                listing.ValorTotalPorAnimalSale = valorUnitAdComissao;
                listing.ValorTotalPorKgSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorKgSale")).Replace(".", ","));
                listing.ValorTotalPorArrobaSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorArrobaSale")).Replace(".", ","));
                listing.id_AnimalProducao = Convert.ToInt32(form.Get("TiposAnimaisProducao"));
                listing.id_TipoRacasAnimais = Convert.ToInt32(form.Get("inTipoRacaAnimal"));
                listing.LinkCam = form.Get("Linkcam");
                listing.NomeVideoOferta = fileVideoUploads.FileName;                
                listing.Location = form.Get("inCidadeEstadoRetirada");
                listing.LocalRetirada = form.Get("inLocalRetirada");
                listing.ReferenciaLocalRetirada = form.Get("inReferenciaLocalRetirada");
                listing.id_TipoFrete = Convert.ToInt32(form.Get("id_TipoFrete"));
                //listing.id_Insurer = Convert.ToInt32(form.Get("SeguradoraID"));
                listing.id_OperationType = (Array.IndexOf(tipsOper, listing.CategoryID) > -1) ? 1 : 0; //OBS: VER DEPOIS OS TIPOS DE OPERACAO QUE PODEM SER CONSIDERADOS AQUI EM VEZ DO 0 (zero) 

                if (form.Get("inValorTaxa").IndexOf(".") > -1)
                {
                    listing.ValorComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTaxa").Replace(".", "")));
                }
                else
                {
                    listing.ValorComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTaxa").Replace(".", ","))); // ORIGINAL
                }

                listing.ValorTotalDoLoteSaleAddComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteMaisTaxaSale").Replace(".", ",")));

                //GERAR NOVA REFERÊNCIA PARA O LOTE OFERTADO
                var listOfertas = await _listingService.Query(l => (l.ID > 0)).SelectAsync();
                var listaIDsOfertas = listOfertas.OrderByDescending(l => l.ID).Select(l => l.ID).ToList();
                listing.ReferLote = ("GMC-" + listaIDsOfertas[0].ToString().PadLeft(6, '0'));   // OBS: PARA MAIS ZEROS À ESQUERD, ALTERAR O NÚMERO 6 PRA QUANT. DESEJADA, ATÉ 10 NO MÁXIMO
                lote = listing.ReferLote;

                updateCount = true;
                _listingService.Insert(listing);
            }
            else
            {
                //ALTERAÇÕES NO ITEM
                if (await NotMeListing(listing.ID))
                    return new HttpUnauthorizedResult();

                var listingExisting = await _listingService.FindAsync(listing.ID);

                var valorUnitAdComissao = 
                    (Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteMaisTaxaSale")).Replace(".", ",")) / Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inQuantidadeItemSale")).Replace(".", ",")));

                listingExisting.Title = listing.Title;
                listingExisting.Description = listing.Description;
                listingExisting.Active = true;
                listingExisting.Price = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorAnimalSale")).Replace(".", ","));
                listingExisting.ContactEmail = listing.ContactEmail;
                listingExisting.ContactName = listing.ContactName;
                listingExisting.ContactPhone = listing.ContactPhone;
                listingExisting.Latitude = listing.Latitude;
                listingExisting.Longitude = listing.Longitude;
                listingExisting.Location = listing.Location;
                listingExisting.ShowPhone = listing.ShowPhone;
                listingExisting.ShowEmail = listing.ShowEmail;
                listingExisting.CategoryID = listing.CategoryID;
                //listingExisting.ListingTypeID = listing.ListingTypeID;
                listingExisting.UnidadeProduto = (listing.UnidadeProduto != null) ? listing.UnidadeProduto : unidadeSelec.descricaoUnidade;
                listingExisting.QuantidadeItensVenda = listing.QuantidadeItensVenda;
                listingExisting.ValorEmDRC = listing.ValorEmDRC;
                listingExisting.IdadeAnimais = form.Get("inIdadeAnimais");
                listingExisting.QuantidadeItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inQuantidadeItemSale")).Replace(".", ","));

                if (form.Get("inPesoKgPorItemSale") != "")
                {
                    listingExisting.PesoKgPorItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoKgPorItemSale")).Replace(".", ","));
                    listingExisting.PesoArrobaPorItemSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoArrobaPorItemSale")).Replace(".", ","));
                    listingExisting.PesoTotalLoteKgSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoTotalLoteKgSale")).Replace(".", ","));
                    listingExisting.PesoTotalLoteArrobaSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inPesoTotalLoteArrobaSale")).Replace(".", ","));
                    listingExisting.ValorTotalPorKgSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorKgSale")).Replace(".", ","));
                    listingExisting.ValorTotalPorArrobaSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalPorArrobaSale")).Replace(".", ","));
                    listingExisting.id_AnimalProducao = Convert.ToInt32(form.Get("TiposAnimaisProducao"));
                    listingExisting.id_TipoRacasAnimais = Convert.ToInt32(form.Get("inTipoRacaAnimal"));
                }

                listingExisting.ValorTotalPorAnimalSale = valorUnitAdComissao;
                listingExisting.ValorTotalDoLoteSale = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteSale")).Replace(".", ","));
                listingExisting.LinkCam = form.Get("Linkcam");
                listingExisting.NomeVideoOferta = fileVideoUploads.FileName;
                listingExisting.Location = form.Get("inCidadeEstadoRetirada");
                listingExisting.LocalRetirada = form.Get("inLocalRetirada");
                listingExisting.ReferenciaLocalRetirada = form.Get("inReferenciaLocalRetirada");
                listingExisting.id_TipoFrete = Convert.ToInt32(form.Get("id_TipoFrete"));
                //listingExisting.id_Insurer = Convert.ToInt32(form.Get("SeguradoraID"));
                listingExisting.id_OperationType = (Array.IndexOf(tipsOper, listing.CategoryID) > -1) ? 1 : 0; //OBS: VER DEPOIS OS TIPOS DE OPERACAO QUE PODEM SER CONSIDERADOS AQUI EM VEZ DO 0 (zero) 

                if (form.Get("inValorTaxa").IndexOf(".") > -1)
                {
                    listingExisting.ValorComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTaxa").Replace(".", "")));
                }
                else
                {
                    listingExisting.ValorComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTaxa").Replace(".", ","))); // ORIGINAL
                }

                listingExisting.ValorTotalDoLoteSaleAddComissao = Convert.ToDecimal(MiscellaneousUtilitiesHelper.TratamentoMilharMonetario(form.Get("inValorTotalDoLoteMaisTaxaSale")).Replace(".", ","));
                listingExisting.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                tipoAcao = 2;
                lote = listingExisting.ReferLote;

                _listingService.Update(listingExisting);
            }

            // Delete existing fields on item
            var customFieldItemQuery = await _customFieldListingService.Query(x => x.ListingID == listing.ID).SelectAsync();
            var customFieldIds = customFieldItemQuery.Select(x => x.ID).ToList();
            foreach (var customFieldId in customFieldIds)
            {
                await _customFieldListingService.DeleteAsync(customFieldId);
            }

            // Get custom fields
            var customFieldCategoryQuery = await _customFieldCategoryService.Query(x => x.CategoryID == listing.CategoryID).Include(x => x.MetaField.ListingMetas).SelectAsync();
            var customFieldCategories = customFieldCategoryQuery.ToList();

            foreach (var metaCategory in customFieldCategories)
            {
                var field = metaCategory.MetaField;
                var controlType = (BeYourMarket.Model.Enum.Enum_MetaFieldControlType)field.ControlTypeID;

                string controlId = string.Format("customfield_{0}_{1}_{2}", metaCategory.ID, metaCategory.CategoryID, metaCategory.FieldID);

                var formValue = form[controlId];

                if (string.IsNullOrEmpty(formValue))
                    continue;

                formValue = formValue.ToString();

                var itemMeta = new ListingMeta()
                {
                    ListingID = listing.ID,
                    Value = formValue,
                    FieldID = field.ID,
                    ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                };

                _customFieldListingService.Insert(itemMeta);
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            if (Request.Files.Count > 0)
            {
                var itemPictureQuery = _listingPictureservice.Queryable().Where(x => x.ListingID == listing.ID);
                if (itemPictureQuery.Count() > 0)
                    nextPictureOrderId = itemPictureQuery.Max(x => x.Ordering);
            }

            if (files != null && files.Count() > 0)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        // Picture picture and get id
                        var picture = new Picture();
                        picture.MimeType = "image/jpeg";
                        _pictureService.Insert(picture);
                        await _unitOfWorkAsync.SaveChangesAsync();

                        // Format is automatically detected though can be changed.
                        ISupportedImageFormat format = new JpegFormat { Quality = 90 };
                        Size size = new Size(500, 0);

                        //https://naimhamadi.wordpress.com/2014/06/25/processing-images-in-c-easily-using-imageprocessor/
                        // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                        {
                            var path = Path.Combine(Server.MapPath("~/images/listing"), string.Format("{0}.{1}", picture.ID.ToString("00000000"), "jpg"));

                            // Load, resize, set the format and quality and save an image.
                            imageFactory.Load(file.InputStream)
                                        .Resize(size)
                                        .Format(format)
                                        .Save(path);
                        }

                        var itemPicture = new ListingPicture();
                        itemPicture.ListingID = listing.ID;
                        itemPicture.PictureID = picture.ID;
                        itemPicture.Ordering = nextPictureOrderId;

                        _listingPictureservice.Insert(itemPicture);

                        nextPictureOrderId++;
                    }
                }
            }

            //Upload do Vídeo - Implemented By Edwilson Curti
            if (fileVideoUploads != null)
            {
                UploadFiles(fileVideoUploads);
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            // Update statistics count
            if (updateCount)
            {
                _sqlDbService.UpdateCategoryItemCount(listing.CategoryID);
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (tipoAcao == 1) ? "[[[Oferta de VENDA LOTE: " + lote + " publicada com SUCESSO!]]]" : "[[[Oferta de VENDA LOTE: " + lote + " atualizada com SUCESSO!]]]";
            return RedirectToAction("Listing", new { id = listing.ID });
        }

        //======================================================================
        //UPLOAD de arquivos
        [HttpPost]
        public ContentResult UploadFiles(HttpPostedFileBase fileVideoUploads)
        {
            try
            {
                string nomeCaminhoMaisArquivo = "";
                var r = new List<UploadFilesResult>();

                //string pastaCodigoEmpresa = Sessao.IdEmpresaUsuario.ToString();
                string caminhoVideo = System.AppDomain.CurrentDomain.BaseDirectory.ToString(); //Pega o caminho físico do PROJETO, para ser usado na montagem do caminho real de armaz.

                //Montando o caminho de armazenamento a ser confirmada existência
                caminhoVideo = (caminhoVideo + "Videos/");

                //Verifica se a estrutura de pastas de armazenamento está criada. Se não existir, cria imediatamente
                DirectoryInfo dir = new DirectoryInfo(caminhoVideo);

                if (dir.Exists == false)
                    dir.Create();

                //Realizando o UPLOAD
                //foreach (string file in Request.Files)
                //{
                    //HttpPostedFileBase hpf = Request.Files[file];
                    //if (hpf.ContentLength == 0)
                    //    continue;

                    string fileName = Regex.Replace(fileVideoUploads.FileName, @"\s+", "_");
                    string savedFileName = Path.Combine(Server.MapPath("~/Videos/"), Path.GetFileName(fileName));
                    fileVideoUploads.SaveAs(savedFileName); //Salva o arquivo
                    nomeCaminhoMaisArquivo = ("~/Videos/" + fileName);

                    r.Add(new UploadFilesResult()
                    {
                        Name = fileName,
                        //Length = hpf.ContentLength,
                        //Type = hpf.ContentType,
                        Length = fileVideoUploads.ContentLength,
                        Type = fileVideoUploads.ContentType,
                        CaminhoArquivoVideo = nomeCaminhoMaisArquivo
                    });
                //}

                return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\",\"nomeCaminhoArquivo\":\"" + r[0].CaminhoArquivoVideo + "\"}", "application/json"); //ORIGINAL
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //======================================================================

        /// <summary>
        /// Grava a conversa do Chat
        /// </summary>
        /// <param name="idOf">Id da Oferta</param>
        /// <param name="sq">Texto do chat a ser grvado</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> RegisterChat(int? idOf, string sq)
        {
            var userId = User.Identity.GetUserId();
            var itemQuery = await _listingService.Query(x => x.ID == idOf)
                                .Include(x => x.Category)
                                .Include(x => x.ListingMetas)
                                .Include(x => x.ListingMetas.Select(y => y.MetaField))
                                .Include(x => x.ListingStats)
                                .Include(x => x.ListingType)
                                .SelectAsync();

            var item = itemQuery.FirstOrDefault();

            if (item == null)
                return new HttpNotFoundResult();

            var listaChats = await _chatOfertaService.Query(c => (c.id_Oferta > 0)).SelectAsync();
            var chats = listaChats.Where(c => (c.id_Oferta == idOf)).ToList();
            int maxOrdemExib = (chats.Count > 0) ? (chats.Select(c => (c.Ordem_Exibicao_ChatOferta)).Max() + 1) : 1;

            ChatOferta msgDaOferta = new ChatOferta();

            //INSERIR NOVA MENSAGEM NO CHAT
            msgDaOferta.id_Oferta = (int)idOf;

            if (userId != item.UserID)
            {
                // User que perguntou
                msgDaOferta.id_Usuario_Perguntou = userId;
            }
            else
            {
                // User que publicou e respondeu
                msgDaOferta.id_Usuario_Respondeu = item.UserID;
            }

            msgDaOferta.Texto_Chat = sq;
            msgDaOferta.Eh_Pergunta = true;
            msgDaOferta.Pergunta_Respondida = false;
            msgDaOferta.Data_Interacao_Chat = DateTime.Now;
            msgDaOferta.Ordem_Exibicao_ChatOferta = maxOrdemExib;

            _chatOfertaService.Insert(msgDaOferta);
            await _unitOfWorkAsync.SaveChangesAsync();

            var listaChatsAtualizada = await _chatOfertaService.Query(c => (c.id_Oferta == idOf) && (c.id_Usuario_Perguntou == userId)).SelectAsync();

            return Json(listaChatsAtualizada, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Carregar os dados de Chat do Usuário Logado
        /// </summary>
        /// <param name="idOf">id da oferta</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> LoadChatLog(int? idOf)
        {
            var userId = User.Identity.GetUserId();
            var listaChatsOferta = await _chatOfertaService.Query(c => (c.id_Oferta == idOf)).SelectAsync();
            var listaChatsLogadoOferta = listaChatsOferta.Where(c => (c.id_Usuario_Perguntou == userId)).OrderBy(c => c.id_ChatOferta).ThenBy(c => c.Ordem_Exibicao_ChatOferta).ToList();
            return Json(listaChatsLogadoOferta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Carregar os dados de Chat do Usuário Logado
        /// </summary>
        /// <param name="idOf">id da oferta</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> LoadChatOutros(int? idOf)
        {
            var userId = User.Identity.GetUserId();
            var listaChatsOferta = await _chatOfertaService.Query(c => (c.id_Oferta == idOf)).SelectAsync();
            //var listaChatsOutrosOferta = listaChatsOferta.Where(c => (c.id_Usuario_Perguntou != userId)).OrderBy(c => c.id_ChatOferta).ThenBy(c => c.Ordem_Exibicao_ChatOferta).ToList();
            var listaChatsOutrosOferta = listaChatsOferta.Where(c => (c.id_Usuario_Perguntou != userId)).OrderBy(c => c.id_Usuario_Perguntou).ThenBy(c => c.Ordem_Exibicao_ChatOferta).ToList();
            return Json(listaChatsOutrosOferta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Grava a resposta às perguntas do Chat
        /// </summary>
        /// <param name="idOf">Id da Oferta</param>
        /// <param name="sq">Texto do chat a ser grvado</param>
        /// <param name="tp">Tipo de gravação (Salvar novo ou Edição)</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> AnswerQuestion(int idOf, int idCO, string sq, int tp)
        {
            var existingQuestion = await _chatOfertaService.FindAsync(idCO);
            ChatOferta dadosChat = new ChatOferta();

            if (tp == 0)
            {
                //INSERIR RESPOSTA
                dadosChat.id_Oferta = idOf;
                dadosChat.id_Usuario_Perguntou = existingQuestion.id_Usuario_Perguntou;
                dadosChat.id_Usuario_Respondeu = User.Identity.GetUserId();
                dadosChat.Data_Interacao_Chat = DateTime.Now;
                dadosChat.Texto_Chat = sq;
                dadosChat.Eh_Pergunta = false;
                dadosChat.Pergunta_Respondida = true;
                dadosChat.Id_Pergunta = idCO;
                dadosChat.Ordem_Exibicao_ChatOferta = (existingQuestion.Ordem_Exibicao_ChatOferta + 1);
                _chatOfertaService.Insert(dadosChat);

                //SETAR PERGUNTA COMO RESPONDIDA
                existingQuestion.Pergunta_Respondida = true;
                _chatOfertaService.Update(existingQuestion);
            }

            await _unitOfWorkAsync.SaveChangesAsync();
            var result = new { Success = true, Message = "[[[Resposta registrada com Sucesso!]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ListingDelete(int id)
        {
            var item = await _listingService.FindAsync(id);
            var orderQuery = await _orderService.Query(x => x.ListingID == id).SelectAsync();

            // Delete item if no orders associated with it
            if (item.Orders.Count > 0)
            {
                var resultFailed = new { Success = false, Message = "[[[You cannot delete item with orders! You can deactivate it instead.]]]" };
                return Json(resultFailed, JsonRequestBehavior.AllowGet);
            }

            await _listingService.DeleteAsync(id);

            await _unitOfWorkAsync.SaveChangesAsync();

            var result = new { Success = true, Message = "[[[Your listing has been deleted.]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ListingPhotoDelete(int id)
        {
            try
            {
                await _pictureService.DeleteAsync(id);
                var itemPicture = _listingPictureservice.Query(x => x.PictureID == id).Select().FirstOrDefault();

                if (itemPicture != null)
                    await _listingPictureservice.DeleteAsync(itemPicture.ID);

                await _unitOfWorkAsync.SaveChangesAsync();

                var path = Path.Combine(Server.MapPath("~/images/listing"), string.Format("{0}.{1}", id.ToString("00000000"), "jpg"));

                System.IO.File.Delete(path);

                var result = new { Success = "true", Message = "" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Success = "false", Message = ex.Message };
                return Json(result, JsonRequestBehavior.AllowGet);
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

        public async Task<bool> NotMeListing(int id)
        {
            var userId = User.Identity.GetUserId();
            var item = await _listingService.FindAsync(id);
            return item.UserID != userId;
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
                Description = listingReview.Description.Replace("@", " arroba(s)"),
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
                Description = listingReview.Description.Replace("@", " arroba(s)"),
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

        /// <summary>
        /// Carrega a lista de Cidades Conforme descrição do Estado UF
        /// </summary>
        /// <param name="tp">Inteiro contendo o tipo de Animal</param>
        /// <returns></returns>
        public ActionResult CarregaRacasTp(int tp)
        {
            var listaRacas = CacheHelper.TiposRacasAnimaisPecuaria.Where(t => (t.id_AnimalProducao == tp)).ToList();
            return Json(listaRacas, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}