using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.DataContext;
using BeYourMarket.Model.Models;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using BeYourMarket.Service;
using BeYourMarket.Model.StoredProcedures;
using BeYourMarket.Core.Services;
using BeYourMarket.Core.Plugins;

namespace BeYourMarket.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<IDataContextAsync, BeYourMarketContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Setting>, Repository<Setting>>()
                .RegisterType<IRepositoryAsync<Category>, Repository<Category>>()
                .RegisterType<IRepositoryAsync<Unidades>, Repository<Unidades>>()
                .RegisterType<IRepositoryAsync<ModalidadesCompra>, Repository<ModalidadesCompra>>()
                .RegisterType<IRepositoryAsync<IntencoesCompra>, Repository<IntencoesCompra>>()
                .RegisterType<IRepositoryAsync<TiposCadastro>, Repository<TiposCadastro>>()
                .RegisterType<IRepositoryAsync<GrupoAtividadesEmpresa>, Repository<GrupoAtividadesEmpresa>>()
                .RegisterType<IRepositoryAsync<CIDADE>, Repository<CIDADE>>()
                .RegisterType<IRepositoryAsync<CIDADE_GEOLOCALIZACAO>, Repository<CIDADE_GEOLOCALIZACAO>>()
                .RegisterType<IRepositoryAsync<ESTADO>, Repository<ESTADO>>()
                .RegisterType<IRepositoryAsync<PAIS>, Repository<PAIS>>()
                .RegisterType<IRepositoryAsync<Cotacao_Master>, Repository<Cotacao_Master>>()
                .RegisterType<IRepositoryAsync<Itens_Cotacao>, Repository<Itens_Cotacao>>()
                .RegisterType<IRepositoryAsync<FornecedoresCotacao>, Repository<FornecedoresCotacao>>()
                .RegisterType<IRepositoryAsync<Resposta_FornecedoresCotacao>, Repository<Resposta_FornecedoresCotacao>>()
                .RegisterType<IRepositoryAsync<TiposFrete>, Repository<TiposFrete>>()
                .RegisterType<IRepositoryAsync<FormasPagamento>, Repository<FormasPagamento>>()
                .RegisterType<IRepositoryAsync<EmpresaUsuario>, Repository<EmpresaUsuario>>()
                .RegisterType<IRepositoryAsync<Listing>, Repository<Listing>>()
                .RegisterType<IRepositoryAsync<ListingPicture>, Repository<ListingPicture>>()
                .RegisterType<IRepositoryAsync<Picture>, Repository<Picture>>()
                .RegisterType<IRepositoryAsync<Order>, Repository<Order>>()
                .RegisterType<IRepositoryAsync<StripeConnect>, Repository<StripeConnect>>()
                .RegisterType<IRepositoryAsync<MetaField>, Repository<MetaField>>()
                .RegisterType<IRepositoryAsync<MetaCategory>, Repository<MetaCategory>>()
                .RegisterType<IRepositoryAsync<ListingMeta>, Repository<ListingMeta>>()
                .RegisterType<IRepositoryAsync<ContentPage>, Repository<ContentPage>>()
                .RegisterType<IRepositoryAsync<SettingDictionary>, Repository<SettingDictionary>>()
                .RegisterType<IRepositoryAsync<ListingStat>, Repository<ListingStat>>()
                .RegisterType<IRepositoryAsync<ListingReview>, Repository<ListingReview>>()
                .RegisterType<IRepositoryAsync<EmailTemplate>, Repository<EmailTemplate>>()
                .RegisterType<IRepositoryAsync<CategoryStat>, Repository<CategoryStat>>()
                .RegisterType<IRepositoryAsync<AspNetUser>, Repository<AspNetUser>>()
                .RegisterType<IRepositoryAsync<AspNetRole>, Repository<AspNetRole>>()
                .RegisterType<IRepositoryAsync<ListingType>, Repository<ListingType>>()
                .RegisterType<IRepositoryAsync<CategoryListingType>, Repository<CategoryListingType>>()
                .RegisterType<IRepositoryAsync<Message>, Repository<Message>>()
                .RegisterType<IRepositoryAsync<MessageParticipant>, Repository<MessageParticipant>>()
                .RegisterType<IRepositoryAsync<MessageReadState>, Repository<MessageReadState>>()
                .RegisterType<IRepositoryAsync<MessageThread>, Repository<MessageThread>>()
                .RegisterType<IRepositoryAsync<TipoAnimalPecuaria>, Repository<TipoAnimalPecuaria>>()
                .RegisterType<IRepositoryAsync<TipoAnimalProducao>, Repository<TipoAnimalProducao>>()
                .RegisterType<IRepositoryAsync<TiposRacasAnimaisPecuaria>, Repository<TiposRacasAnimaisPecuaria>>()
                .RegisterType<IRepositoryAsync<Banks>, Repository<Banks>>()
                .RegisterType<IRepositoryAsync<TiposContaBancaria>, Repository<TiposContaBancaria>>()
                .RegisterType<IRepositoryAsync<UserBankDetails>, Repository<UserBankDetails>>()
                .RegisterType<IRepositoryAsync<TiposChavePix>, Repository<TiposChavePix>>()
                .RegisterType<IRepositoryAsync<Insurers>, Repository<Insurers>>()
                .RegisterType<IRepositoryAsync<OperationType>, Repository<OperationType>>()
                .RegisterType<IRepositoryAsync<ChatOferta>, Repository<ChatOferta>>()
                .RegisterType<IRepositoryAsync<ShippingCompany>, Repository<ShippingCompany>>()
                .RegisterType<IRepositoryAsync<MeiosDePagamento>, Repository<MeiosDePagamento>>()
                .RegisterType<IRepositoryAsync<ModosPagamento>, Repository<ModosPagamento>>()
                .RegisterType<IRepositoryAsync<CompraEfetuada>, Repository<CompraEfetuada>>()
                .RegisterType<IRepositoryAsync<VideosOferta>, Repository<VideosOferta>>()
                .RegisterType<ISettingService, SettingService>()
                .RegisterType<ICategoryService, CategoryService>()
                .RegisterType<IUnidadesService, UnidadesService>()
                .RegisterType<IModalidadesCompraService, ModalidadesCompraService>()
                .RegisterType<IIntencoesCompraService, IntencoesCompraService>()
                .RegisterType<IEmpresaUsuarioService, EmpresaUsuarioService>()
                .RegisterType<ITiposCadastroService, TiposCadastroService>()
                .RegisterType<IGruposAtividadesService, GruposAtividadesService>()
                .RegisterType<ICidadesService, CidadesService>()
                .RegisterType<ICidadesGeolocalizacaoService, CidadesGeolocalizacaoService>()
                .RegisterType<IEstadoService, EstadoService>()
                .RegisterType<IPaisService, PaisService>()
                .RegisterType<ICotacaoMasterService, CotacaoMasterService>()
                .RegisterType<IItensCotacaoService, ItensCotacaoService>()
                .RegisterType<IFornecedoresCotacaoService, FornecedoresCotacaoService>()
                .RegisterType<IRespostaFornecedoresCotacaoService, RespostaFornecedoresCotacaoService>()
                .RegisterType<ITiposFreteService, TiposFreteService>()
                .RegisterType<IFormasPagamentoService, FormasPagamentoService>()
                .RegisterType<ICategoryStatService, CategoryStatService>()
                .RegisterType<IListingService, ListingService>()
                .RegisterType<IListingPictureService, ListingPictureService>()
                .RegisterType<IPictureService, PictureService>()
                .RegisterType<IOrderService, OrderService>()
                .RegisterType<ICustomFieldService, CustomFieldService>()
                .RegisterType<ICustomFieldCategoryService, CustomFieldCategoryService>()
                .RegisterType<ICustomFieldListingService, CustomFieldListingService>()
                .RegisterType<IContentPageService, ContentPageService>()
                .RegisterType<ISettingDictionaryService, SettingDictionaryService>()
                .RegisterType<IListingStatService, ListingStatService>()
                .RegisterType<IEmailTemplateService, EmailTemplateService>()
                .RegisterType<IAspNetUserService, AspNetUserService>()
                .RegisterType<IAspNetRoleService, AspNetRoleService>()
                .RegisterType<IListingTypeService, ListingTypeService>()
                .RegisterType<IListingReviewService, ListingReviewService>()
                .RegisterType<ICategoryListingTypeService, CategoryListingTypeService>()
                .RegisterType<IMessageService, MessageService>()
                .RegisterType<IMessageParticipantService, MessageParticipantService>()
                .RegisterType<IMessageReadStateService, MessageReadStateService>()
                .RegisterType<IMessageThreadService, MessageThreadService>()
                .RegisterType<ITipoAnimalPecuariaService, TipoAnimalPecuariaService>()
                .RegisterType<ITipoAnimalProducaoService, TipoAnimalProducaoService>()
                .RegisterType<ITiposRacasAnimaisPecuariaService, TiposRacasAnimaisPecuariaService>()
                .RegisterType<IBanksService, BanksService>()
                .RegisterType<IInsurersService, InsurersService>()
                .RegisterType<IOperationTypeService, OperationTypeService>()
                .RegisterType<ITiposContaBancariaService, TiposContaBancariaService>()
                .RegisterType<IUserBankDetailsService, UserBankDetailsService>()
                .RegisterType<ITiposChavePixService, TiposChavePixService>()
                .RegisterType<IChatOfertaService, ChatOfertaService>()
                .RegisterType<IShippingCompanyService, ShippingCompanyService>()
                .RegisterType<IMeiosDePagamentoService, MeiosDePagamentoService>()
                .RegisterType<IModosPagamentoService, ModosPagamentoService>()
                .RegisterType<ICompraEfetuadaService, CompraEfetuadaService>()
                .RegisterType<IVideosOfertaService, VideosOfertaService>()
                .RegisterType<IStoredProcedures, BeYourMarketContext>(new PerRequestLifetimeManager())
                .RegisterType<SqlDbService, SqlDbService>()
                .RegisterType<DataCacheService, DataCacheService>(new ContainerControlledLifetimeManager());
            container
                .RegisterType<IHookService, HookService>()
                .RegisterType<IPluginFinder, PluginFinder>();
        }
    }
}
