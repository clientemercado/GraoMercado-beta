using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BeYourMarket.Service;
using System.Threading.Tasks;
using BeYourMarket.Model.Models;
using Repository.Pattern.UnitOfWork;
using Newtonsoft.Json;
using BeYourMarket.Web.Extensions;
using BeYourMarket.Web.Models.Grids;
using BeYourMarket.Web.Models;
using BeYourMarket.Web.Utilities;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using ImageProcessor;
using System.IO;
using System.Text;
using BeYourMarket.Model.Enum;
using RestSharp;
using BeYourMarket.Web.Areas.Admin.Models;
using Postal;
using System.Net.Mail;
using System.Net;
using BeYourMarket.Service.Models;
using BeYourMarket.Core.Plugins;
using BeYourMarket.Core.Web;

namespace BeYourMarket.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PluginController : Controller
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly ISettingDictionaryService _settingDictionaryService;
        private readonly ICategoryService _categoryService;
        private readonly IUnidadesService _unidadesService;
        private readonly ITiposFreteService _tiposFreteService;
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
        private readonly IFormasPagamentoService _formasPagamentoService;
        private readonly IListingService _listingService;
        private readonly ITipoAnimalProducaoService _tipoAnimalProducaoService;
        private readonly ITipoAnimalPecuariaService _tipoAnimalPecuariaService;
        private readonly ITiposRacasAnimaisPecuariaService _tiposRacasAnimaisService;
        private readonly DataCacheService _dataCacheService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IPluginFinder _pluginFinder;
        #endregion

        #region Constructor
        public PluginController(
            IUnitOfWorkAsync unitOfWorkAsync,
            ISettingService settingService,
            ISettingDictionaryService settingDictionaryService,
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
            ITipoAnimalProducaoService tipoAnimalProducaoService,
            ITipoAnimalPecuariaService tipoAnimalPecuariaService,
            ITiposRacasAnimaisPecuariaService tiposRacasAnimaisService,
            DataCacheService dataCacheService,
            IPluginFinder pluginFinder)
        {
            _settingService = settingService;
            _settingDictionaryService = settingDictionaryService;
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
            _unitOfWorkAsync = unitOfWorkAsync;
            _dataCacheService = dataCacheService;
            _pluginFinder = pluginFinder;
            _tipoAnimalProducaoService = tipoAnimalProducaoService;
            _tipoAnimalPecuariaService = tipoAnimalPecuariaService;
            _tiposRacasAnimaisService = tiposRacasAnimaisService;
        }
        #endregion

        #region Methods
        public ActionResult Plugins()
        {
            var plugins = _pluginFinder.GetPluginDescriptors(LoadPluginsMode.All).OrderBy(x => x.DisplayOrder).AsQueryable();

            var grid = new PluginsGrid(plugins);

            return View(grid);
        }
        
        public ActionResult Configure(string systemName)
        {
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName(systemName);
            
            string actionUrl = string.Empty;

            if (typeof(IHookPlugin).IsAssignableFrom(pluginDescriptor.PluginType))
            {
                actionUrl = Url.Action("ConfigureHook", "Hook", new { systemName = pluginDescriptor.SystemName });
            }

            // check if there is actionUrl
            if (string.IsNullOrEmpty(actionUrl))
                return HttpNotFound();

            return Redirect(actionUrl);
        }

        public ActionResult Installer(string systemName, int pluginAction)
        {
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName(systemName, LoadPluginsMode.All);

            switch ((BeYourMarket.Model.Enum.Enum_PluginAction)pluginAction)
            {
                case Enum_PluginAction.Install:
                    pluginDescriptor.Instance().Install();
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} foi instalado]]]", systemName);
                    break;
                case Enum_PluginAction.Uninstall:                    
                    pluginDescriptor.Instance().Uninstall();
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} foi desinstalado]]]", systemName);
                    break;
                case Enum_PluginAction.Enabled:
                    pluginDescriptor.Instance().Enable(true);
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is enabled]]]", systemName);
                    break;
                case Enum_PluginAction.Disabled:
                    pluginDescriptor.Instance().Enable(false);
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is disabled]]]", systemName);
                    break;
                default:
                    break;
            }                                    
            
            return RedirectToAction("Plugins");
        }


        #endregion
    }
}
