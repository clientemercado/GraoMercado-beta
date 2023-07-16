using BeYourMarket.Core.Controllers;
using BeYourMarket.Model.Models;
using BeYourMarket.Service.Models;
using Microsoft.Practices.Unity;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Service
{
    public class DataCacheService
    {
        public MemoryCache MainCache { get; private set; }

        private ISettingService SettingService
        {
            get { return _container.Resolve<ISettingService>(); }
        }

        private ISettingDictionaryService SettingDictionaryService
        {
            get { return _container.Resolve<ISettingDictionaryService>(); }
        }

        private ICategoryService CategoryService
        {
            get { return _container.Resolve<ICategoryService>(); }
        }

        private IUnidadesService UnidadesService
        {
            get { return _container.Resolve<IUnidadesService>(); }
        }

        private IModalidadesCompraService ModalidadesCompraService
        {
            get { return _container.Resolve<IModalidadesCompraService>(); }
        }

        private IIntencoesCompraService IntencoesCompraService
        {
            get { return _container.Resolve<IIntencoesCompraService>(); }
        }

        private IEmpresaUsuarioService EmpresaUsuarioService
        {
            get { return _container.Resolve<IEmpresaUsuarioService>(); }
        }

        private ITiposCadastroService TiposCadastroService
        {
            get { return _container.Resolve<ITiposCadastroService>(); }
        }

        private IGruposAtividadesService GruposAtividadesService
        {
            get { return _container.Resolve<IGruposAtividadesService>(); }
        }

        private ICidadesService CidadesService
        {
            get { return _container.Resolve<ICidadesService>(); }
        }

        private ICidadesGeolocalizacaoService CidadeGeolocalizacaoService
        {
            get { return _container.Resolve<ICidadesGeolocalizacaoService>(); }
        }

        private IEstadoService EstadoService
        {
            get { return _container.Resolve<IEstadoService>(); }
        }

        private IPaisService PaisService
        {
            get { return _container.Resolve<IPaisService>(); }
        }

        private ICotacaoMasterService CotacaoMasterService
        {
            get { return _container.Resolve<ICotacaoMasterService>(); }
        }

        private IItensCotacaoService ItensCotacaoService
        {
            get { return _container.Resolve<IItensCotacaoService>(); }
        }

        private IFornecedoresCotacaoService FornecedoresCotacaoService
        {
            get { return _container.Resolve<IFornecedoresCotacaoService>(); }
        }

        private IRespostaFornecedoresCotacaoService RespostaForncedoresService
        {
            get { return _container.Resolve<IRespostaFornecedoresCotacaoService>(); }
        }
        private IAspNetUsersService AspNetUsersService
        {
            get { return _container.Resolve<IAspNetUsersService>(); }
        }

        private ITiposFreteService TiposFreteService
        {
            get { return _container.Resolve<ITiposFreteService>(); }
        }

        private IFormasPagamentoService FormasPagamentoService
        {
            get { return _container.Resolve<IFormasPagamentoService>(); }
        }

        private IListingTypeService ListingTypeService
        {
            get { return _container.Resolve<IListingTypeService>(); }
        }

        private IContentPageService ContentPageService
        {
            get { return _container.Resolve<IContentPageService>(); }
        }

        private IEmailTemplateService EmailTemplateService
        {
            get { return _container.Resolve<IEmailTemplateService>(); }
        }

        private ICategoryStatService CategoryStatService
        {
            get { return _container.Resolve<ICategoryStatService>(); }
        }

        private IListingService ListingService
        {
            get { return _container.Resolve<IListingService>(); }
        }

        private IListingStatService ListingStatservice
        {
            get { return _container.Resolve<IListingStatService>(); }
        }

        private IOrderService OrderService
        {
            get { return _container.Resolve<IOrderService>(); }
        }

        private IAspNetUserService AspNetUserService
        {
            get { return _container.Resolve<IAspNetUserService>(); }
        }

        private ITiposRacasAnimaisPecuariaService TiposRacasAnimaisPecuariaService
        {
            get { return _container.Resolve<ITiposRacasAnimaisPecuariaService>(); }
        }

        private ITipoAnimalPecuariaService TipoAnimalPecuariaService
        {
            get { return _container.Resolve<ITipoAnimalPecuariaService>(); }
        }

        private ITipoAnimalProducaoService TiposAnimaisProducaoService
        {
            get { return _container.Resolve<ITipoAnimalProducaoService>(); }
        }

        private IBanksService BanksService
        {
            get { return _container.Resolve<IBanksService>(); }
        }

        private ITiposContaBancariaService TiposContaBancariaService
        {
            get { return _container.Resolve<ITiposContaBancariaService>(); }
        }

        private IUserBankDetailsService UserBankDetailsService
        {
            get { return _container.Resolve<IUserBankDetailsService>(); }
        }

        private ITiposChavePixService TiposChavePixService
        {
            get { return _container.Resolve<ITiposChavePixService>(); }
        }

        private IInsurersService InsurersService
        {
            get { return _container.Resolve<IInsurersService>(); }
        }

        private IOperationTypeService OperationTypeService
        {
            get { return _container.Resolve<IOperationTypeService>(); }
        }

        private IChatOfertaService ChatOfertaService
        {
            get { return _container.Resolve<IChatOfertaService>(); }
        }

        private IShippingCompanyService ShippingCompanyService
        {
            get { return _container.Resolve<IShippingCompanyService>(); }
        }

        private IMeiosDePagamentoService MeiosDePagamentoService
        {
            get { return _container.Resolve<IMeiosDePagamentoService>(); }
        }

        private IModosPagamentoService ModosPagamentoService
        {
            get { return _container.Resolve<IModosPagamentoService>(); }
        }

        private ICompraEfetuadaService CompraEfetuadaService
        {
            get { return _container.Resolve<ICompraEfetuadaService>(); }
        }

        private IVideosOfertaService VideosOfertaService
        {
            get { return _container.Resolve<IVideosOfertaService>(); }
        }
                

        private IUnityContainer _container;

        private object _lock = new object();

        public DataCacheService(IUnityContainer container)
        {
            _container = container;

            MainCache = new MemoryCache("MainCache");

            GetCachedItem(CacheKeys.Settings);
            GetCachedItem(CacheKeys.SettingDictionary);
            GetCachedItem(CacheKeys.Categories);
            GetCachedItem(CacheKeys.ContentPages);
            GetCachedItem(CacheKeys.EmailTemplates);
            GetCachedItem(CacheKeys.Statistics);
        }

        public void UpdateCache(CacheKeys CacheKeyName, object CacheItem, int priority = (int)CacheItemPriority.NotRemovable)
        {
            lock (_lock)
            {
                var policy = new CacheItemPolicy();
                policy.Priority = (CacheItemPriority)priority;
                //policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.00);

                // Add inside cache 
                MainCache.Set(CacheKeyName.ToString(), CacheItem, policy);
            }
        }

        public object GetCachedItem(CacheKeys CacheKeyName)
        {
            lock (_lock)
            {
                if (!MainCache.Contains(CacheKeyName.ToString()))
                {
                    switch (CacheKeyName)
                    {
                        case CacheKeys.Settings:
                            var setting = SettingService.Queryable().FirstOrDefault();
                            UpdateCache(CacheKeys.Settings, setting);
                            break;
                        case CacheKeys.SettingDictionary:
                            var settingDictionary = SettingDictionaryService.Queryable().ToList();
                            UpdateCache(CacheKeys.SettingDictionary, settingDictionary);
                            break;
                        case CacheKeys.Categories:
                            var categories = CategoryService.Queryable().Where(x => x.Enabled).OrderBy(x => x.Ordering).ToList();
                            UpdateCache(CacheKeys.Categories, categories);
                            break;
                        case CacheKeys.Unidades:
                            var unidades = UnidadesService.Queryable().Where(x => x.descricaoUnidade != null).ToList();
                            UpdateCache(CacheKeys.Unidades, unidades);
                            break;
                        case CacheKeys.ModalidadesCompra:
                            var modalidadesCompra = ModalidadesCompraService.Queryable().Where(x => x.Descricao_ModalCompra != null).ToList();
                            UpdateCache(CacheKeys.ModalidadesCompra, modalidadesCompra);
                            break;
                        case CacheKeys.IntencoesCompra:
                            var intencoesCompra = IntencoesCompraService.Queryable().Where(x => x.DescricaoProduto != null).ToList();
                            UpdateCache(CacheKeys.IntencoesCompra, intencoesCompra);
                            break;
                        case CacheKeys.EmpresaUsuario:
                            var empresaUsuario = EmpresaUsuarioService.Queryable().Where(x => x.Fantasia_Empresa != null).ToList();
                            UpdateCache(CacheKeys.EmpresaUsuario, empresaUsuario);
                            break;
                        case CacheKeys.TiposCadastro:
                            var tiposCadastro = TiposCadastroService.Queryable().Where(x => x.Descricao_TipoCadastro != null).ToList();
                            UpdateCache(CacheKeys.TiposCadastro, tiposCadastro);
                            break;
                        case CacheKeys.GrupoAtividadesEmpresa:
                            var gruposAtividades = GruposAtividadesService.Queryable().Where(x => x.Descricao_Atividades != null).ToList();
                            UpdateCache(CacheKeys.GrupoAtividadesEmpresa, gruposAtividades);
                            break;
                        case CacheKeys.Cidade:
                            var cidades = CidadesService.Queryable().Where(x => x.NOME != null).ToList();
                            UpdateCache(CacheKeys.Cidade, cidades);
                            break;
                        case CacheKeys.Cidade_Geo:
                            var cidadesGeo = CidadeGeolocalizacaoService.Queryable().Where(x => x.GEOLOCALIZACAO != null).ToList();
                            UpdateCache(CacheKeys.Cidade_Geo, cidadesGeo);
                            break;
                        case CacheKeys.EstadoUf:
                            var estadouf = EstadoService.Queryable().Where(x => x.NOME != null).ToList();
                            UpdateCache(CacheKeys.EstadoUf, estadouf);
                            break;
                        case CacheKeys.Pais:
                            var pais = PaisService.Queryable().Where(x => x.NOME != null).ToList();
                            UpdateCache(CacheKeys.Pais, pais);
                            break;
                        case CacheKeys.CotacaoMaster:
                            var cotacaoMaster = CotacaoMasterService.Queryable().Where(x => x.Id_UsuarioCriou!= null).ToList();
                            UpdateCache(CacheKeys.CotacaoMaster, cotacaoMaster);
                            break;
                        case CacheKeys.ItensCotacao:
                            var itensCotacao = ItensCotacaoService.Queryable().Where(x => x.Descricao_ItemCotacao != null).ToList();
                            UpdateCache(CacheKeys.ItensCotacao, itensCotacao);
                            break;
                        case CacheKeys.FornecedoresCotacao:
                            var fornecedoresCotacao = FornecedoresCotacaoService.Queryable().Where(x => x.Id_Empresa > 0).ToList();
                            UpdateCache(CacheKeys.FornecedoresCotacao, fornecedoresCotacao);
                            break;
                        case CacheKeys.RespostaFornecedoresCotacao:
                            var respostaFornecedoresCotacao = RespostaForncedoresService.Queryable().Where(x => x.Id_ItemCotacao > 0).ToList();
                            UpdateCache(CacheKeys.RespostaFornecedoresCotacao, respostaFornecedoresCotacao);
                            break;
                        case CacheKeys.AspNetUsers:
                            var aspnetusers = AspNetUserService.Queryable().Where(x => x.Id != "").ToList();
                            UpdateCache(CacheKeys.AspNetUsers, aspnetusers);
                            break;
                        case CacheKeys.TiposFrete:
                            var tiposFrete = TiposFreteService.Queryable().Where(x => x.Descricao_TipoFrete != null).ToList();
                            UpdateCache(CacheKeys.TiposFrete, tiposFrete);
                            break;
                        case CacheKeys.FormasPagamento:
                            var formasPagamento = FormasPagamentoService.Queryable().Where(x => x.Descricao_FormaPgto != null).ToList();
                            UpdateCache(CacheKeys.FormasPagamento, formasPagamento);
                            break;
                        case CacheKeys.ListingTypes:
                            var ListingTypes = ListingTypeService.Query().Include(x => x.CategoryListingTypes).Select().ToList();
                            UpdateCache(CacheKeys.ListingTypes, ListingTypes);
                            break;
                        case CacheKeys.ContentPages:
                            var contentPages = ContentPageService.Queryable().Where(x => x.Published).OrderBy(x => x.Ordering).ToList();
                            UpdateCache(CacheKeys.ContentPages, contentPages);
                            break;
                        case CacheKeys.EmailTemplates:
                            var emailTemplates = EmailTemplateService.Queryable().ToList();
                            UpdateCache(CacheKeys.EmailTemplates, emailTemplates);
                            break;
                        case CacheKeys.TiposAnimaisProducao:
                            var tiposAnimais = TiposAnimaisProducaoService.Queryable().Where(x => x.id_AnimalProducao > 0).ToList();
                            UpdateCache(CacheKeys.TiposAnimaisProducao, tiposAnimais);
                            break;
                        case CacheKeys.AnimaisPecuaria:
                            var animaisPecuaria = TipoAnimalPecuariaService.Queryable().Where(x => x.id_AnimalPecuaria > 0).ToList();
                            UpdateCache(CacheKeys.AnimaisPecuaria, animaisPecuaria);
                            break;
                        case CacheKeys.TiposRacasAnimaisPecuaria:
                            var racasAnimaisPecuaria = TiposRacasAnimaisPecuariaService.Queryable().Where(x => x.id_AnimalProducao > 0).ToList();
                            UpdateCache(CacheKeys.TiposRacasAnimaisPecuaria, racasAnimaisPecuaria);
                            break;
                        case CacheKeys.Banks:
                            //var banks = BanksService.Queryable().Where(x => ((x.id_Bank > 0) && (x.id_Country == 1))).ToList();
                            var banks = BanksService.Queryable().Where(x => (x.ShortName.Contains("BANCO"))).ToList();
                            UpdateCache(CacheKeys.Banks, banks);
                            break; 
                        case CacheKeys.TiposContaBancaria:
                            var tiposComtaBancaria = TiposContaBancariaService.Queryable().Where(x => x.id_TipoConta > 0).ToList();
                            UpdateCache(CacheKeys.TiposContaBancaria, tiposComtaBancaria);
                            break;
                        case CacheKeys.UserBankDetails:
                            var userBankDetails = UserBankDetailsService.Queryable().Where(x => (x.Id_UBankDetails > 0)).ToList();
                            UpdateCache(CacheKeys.UserBankDetails, userBankDetails);
                            break;
                        case CacheKeys.TiposChavePix:
                            var tpsChavePix = TiposChavePixService.Queryable().Where(x => (x.id_TipoChavePix > 0)).ToList();
                            UpdateCache(CacheKeys.TiposChavePix, tpsChavePix);
                            break;
                        case CacheKeys.Insurers:
                            var insurers = InsurersService.Queryable().Where(x => (x.id_Insurer> 0)).ToList();
                            UpdateCache(CacheKeys.Insurers, insurers);
                            break;
                        case CacheKeys.OperationType:
                            var operacoes = OperationTypeService.Queryable().Where(x => (x.id_OperationType> 0)).ToList();
                            UpdateCache(CacheKeys.OperationType, operacoes);
                            break;
                        case CacheKeys.ChatOferta:
                            var chatOferta = ChatOfertaService.Queryable().Where(x => (x.id_ChatOferta > 0)).ToList();
                            UpdateCache(CacheKeys.ChatOferta, chatOferta);
                            break;
                        case CacheKeys.ShippingCompany:
                            //var shippingCompany = ShippingCompanyService.Queryable().Where(x => (x.Habilitado_View_Plataforma_SC == true)).ToList();
                            var shippingCompany = ShippingCompanyService.Queryable().Where(x => (x.Id_SC > 0)).ToList();
                            UpdateCache(CacheKeys.ShippingCompany, shippingCompany);
                            break;
                        case CacheKeys.MeiosDePagamento:
                            var meiosPagamento = MeiosDePagamentoService.Queryable().Where(x => (x.Id_MeiosPag > 0)).ToList();
                            UpdateCache(CacheKeys.MeiosDePagamento, meiosPagamento);
                            break;
                        case CacheKeys.ModosPagamento:
                            var modosPagamento = ModosPagamentoService.Queryable().Where(x => (x.Id_ModosPag> 0)).ToList();
                            UpdateCache(CacheKeys.ModosPagamento, modosPagamento);
                            break;
                        case CacheKeys.CompraEfetuada:
                            var compraEfetuada = CompraEfetuadaService.Queryable().Where(x => (x.Id_CompEfet > 0)).ToList();
                            UpdateCache(CacheKeys.CompraEfetuada, compraEfetuada);
                            break;
                        case CacheKeys.VideosOferta:
                            var videosOferta = VideosOfertaService.Queryable().Where(x => (x.id_VideoOferta > 0)).ToList();
                            UpdateCache(CacheKeys.VideosOferta, videosOferta);
                            break;

                            

                        case CacheKeys.Statistics:
                            SaveCategoryStats();

                            var statistics = new Statistics();
                            statistics.CategoryStats = CategoryStatService.Query().Include(x => x.Category).Select().ToList();

                            statistics.ListingCount = ListingService.Queryable().Count();
                            statistics.UserCount = AspNetUserService.Queryable().Count();
                            statistics.OrderCount = OrderService.Queryable().Count();
                            statistics.TransactionCount = 0;

                            statistics.ItemsCountDictionary = ListingService.GetItemsCount(DateTime.Now.AddDays(-10));

                            UpdateCache(CacheKeys.Statistics, statistics);
                            break;
                        default:
                            break;
                    }
                };

                return MainCache[CacheKeyName.ToString()] as Object;
            }
        }

        // Update categories stats
        private void SaveCategoryStats()
        {
            var unitOfWorkAsync = _container.Resolve<IUnitOfWorkAsync>();

            var categoryCountDctionary = ListingService.GetCategoryCount();

            foreach (var item in categoryCountDctionary)
            {
                var categoryStatQuery = CategoryStatService.Query(x => x.CategoryID == item.Key.ID).Select();

                var categoryStat = categoryStatQuery.FirstOrDefault();

                if (categoryStat != null)
                {
                    categoryStat.Count = item.Value;
                    categoryStat.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                }
                else
                {
                    CategoryStatService.Insert(new CategoryStat()
                    {
                        CategoryID = item.Key.ID,
                        Count = item.Value,
                        ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added
                    });
                }
            }

            unitOfWorkAsync.SaveChanges();
        }

        public void RemoveCachedItem(CacheKeys CacheKeyName)
        {
            if (MainCache.Contains(CacheKeyName.ToString()))
            {
                MainCache.Remove(CacheKeyName.ToString());
            }
        }

    }
}
