using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeYourMarket.Model.Models.Mapping;
using BeYourMarket.Core.Migrations;
using BeYourMarket.Core;

namespace BeYourMarket.Model.Models
{
    public partial class BeYourMarketContext : Repository.Pattern.Ef6.DataContext
    {
        static BeYourMarketContext()
        {
            // Check if migrate database to latest version automatically (using automatic migration)
            // AutomaticMigrationDataLossAllowed is disabled by default (can be configred in web.config)
            // reference: http://stackoverflow.com/questions/10646111/entity-framework-migrations-enable-automigrations-along-with-added-migration
            if (BeYourMarketConfigurationManager.MigrateDatabaseToLatestVersion){
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeYourMarketContext, ConfigurationInstall<BeYourMarket.Model.Models.BeYourMarketContext>>());
            }
            else { 
                Database.SetInitializer<BeYourMarketContext>(null);
            }
        }

        public BeYourMarketContext()
            : base("Name=DefaultConnection")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<TiposFrete> TiposFrete { get; set; }
        public DbSet<TiposCadastro> TiposCadastro { get; set; }
        public DbSet<CategoryListingType> CategoryListingTypes { get; set; }
        public DbSet<CategoryStat> CategoryStats { get; set; }
        public DbSet<ContentPage> ContentPages { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<ListingMeta> ListingMetas { get; set; }
        public DbSet<ListingPicture> ListingPictures { get; set; }
        public DbSet<ListingReview> ListingReviews { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingStat> ListingStats { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageParticipant> MessageParticipants { get; set; }
        public DbSet<MessageReadState> MessageReadStates { get; set; }
        public DbSet<MessageThread> MessageThreads { get; set; }
        public DbSet<MetaCategory> MetaCategories { get; set; }
        public DbSet<MetaField> MetaFields { get; set; }
        public DbSet<ModalidadesCompra> ModalidadesCompra { get; set; }
        public DbSet<IntencoesCompra> IntencoesCompra { get; set; }
        public DbSet<FormasPagamento> FormasPagamento { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<SettingDictionary> SettingDictionaries { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StripeConnect> StripeConnects { get; set; }
        public DbSet<StripeTransaction> StripeTransactions { get; set; }
        public DbSet<EmpresaUsuario> EmpresaUsuario { get; set; }
        public DbSet<GrupoAtividadesEmpresa> GrupoAtividadesEmpresa { get; set; }
        public DbSet<CIDADE> CIDADE { get; set; }
        public DbSet<CIDADE_GEOLOCALIZACAO> CIDADE_GEOLOCALIZACAO { get; set; }
        public DbSet<ESTADO> ESTADO { get; set; }
        public DbSet<PAIS> PAIS  { get; set; }
        public DbSet<Cotacao_Master> Cotacao_Master  { get; set; }
        public DbSet<Itens_Cotacao> Itens_Cotacao { get; set; }
        public DbSet<FornecedoresCotacao> FornecedoresCotacao { get; set; }
        public DbSet<Resposta_FornecedoresCotacao> Resposta_FornecedoresCotacao { get; set; }
        public DbSet<TipoAnimalPecuaria> TipoAnimalPecuaria { get; set; }
        public DbSet<TipoAnimalProducao> TipoAnimalProducao { get; set; }
        public DbSet<TiposRacasAnimaisPecuaria> TiposRacasAnimaisPecuaria { get; set; }
        public DbSet<UserBankDetails> UserBankDetails { get; set; }
        public DbSet<TiposChavePix> TiposChavePix { get; set; }
        public DbSet<TiposContaBancaria> TiposContaBancaria { get; set; }
        public DbSet<Banks> Banks { get; set; }
        public DbSet<Insurers> Insurers { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<ChatOferta> ChatOferta { get; set; }
        public DbSet<ShippingCompany> ShippingCompany { get; set; }
        public DbSet<MeiosDePagamento> MeiosDePagamento { get; set; }
        public DbSet<ModosPagamento> ModosPagamento { get; set; }
        public DbSet<CompraEfetuada> CompraEfetuada { get; set; }
        public DbSet<VideosOferta> VideosOferta { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CategoryListingTypeMap());
            modelBuilder.Configurations.Add(new CategoryStatMap());
            modelBuilder.Configurations.Add(new ContentPageMap());
            modelBuilder.Configurations.Add(new EmailTemplateMap());
            modelBuilder.Configurations.Add(new IntencoesCompraMap());
            modelBuilder.Configurations.Add(new ListingMetaMap());
            modelBuilder.Configurations.Add(new ListingPictureMap());
            modelBuilder.Configurations.Add(new ListingReviewMap());
            modelBuilder.Configurations.Add(new ListingMap());
            modelBuilder.Configurations.Add(new ListingStatMap());
            modelBuilder.Configurations.Add(new ListingTypeMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new MessageParticipantMap());
            modelBuilder.Configurations.Add(new MessageReadStateMap());
            modelBuilder.Configurations.Add(new MessageThreadMap());
            modelBuilder.Configurations.Add(new MetaCategoryMap());
            modelBuilder.Configurations.Add(new MetaFieldMap());
            modelBuilder.Configurations.Add(new ModalidadesCompraMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new PictureMap());
            modelBuilder.Configurations.Add(new SettingDictionaryMap());
            modelBuilder.Configurations.Add(new SettingMap());
            modelBuilder.Configurations.Add(new StripeConnectMap());
            modelBuilder.Configurations.Add(new StripeTransactionMap());
            modelBuilder.Configurations.Add(new UnidadesMap());
            modelBuilder.Configurations.Add(new TiposFreteMap());
            modelBuilder.Configurations.Add(new FormasPagamentoMap());
            modelBuilder.Configurations.Add(new TiposCadastroMap());
            modelBuilder.Configurations.Add(new EmpresaUsuarioMap());
            modelBuilder.Configurations.Add(new GrupoAtividadesEmpresaMap());
            modelBuilder.Configurations.Add(new CIDADEMap());
            modelBuilder.Configurations.Add(new CIDADE_GEOLOCALIZACAOMap());
            modelBuilder.Configurations.Add(new ESTADOMap());
            modelBuilder.Configurations.Add(new PAISMap());
            modelBuilder.Configurations.Add(new Cotacao_MasterMap());
            modelBuilder.Configurations.Add(new Itens_CotacaoMap());
            modelBuilder.Configurations.Add(new FornecedoresCotacaoMap());
            modelBuilder.Configurations.Add(new Resposta_FornecedoresCotacaoMap());
            modelBuilder.Configurations.Add(new TipoAnimalPecuariaMap());
            modelBuilder.Configurations.Add(new TipoAnimalProducaoMap());
            modelBuilder.Configurations.Add(new TiposRacasAnimaisPecuariaMap());
            modelBuilder.Configurations.Add(new UserBankDetailsMap());
            modelBuilder.Configurations.Add(new TiposChavePixMap());
            modelBuilder.Configurations.Add(new TiposContaBancariaMap());
            modelBuilder.Configurations.Add(new BanksMap());
            modelBuilder.Configurations.Add(new InsurersMap());
            modelBuilder.Configurations.Add(new OperationTypeMap());
            modelBuilder.Configurations.Add(new ChatOfertaMap());
            modelBuilder.Configurations.Add(new ShippingCompanyMap());
            modelBuilder.Configurations.Add(new MeiosDePagamentoMap());
            modelBuilder.Configurations.Add(new ModosPagamentoMap());
            modelBuilder.Configurations.Add(new CompraEfetuadaMap());
            modelBuilder.Configurations.Add(new VideosOfertaMap());            
        }
    }
}
