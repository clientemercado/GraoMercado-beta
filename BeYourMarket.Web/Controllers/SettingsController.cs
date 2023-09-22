//using BeYourMarket.Core.Web;
//using BeYourMarket.Model.Models;
//using BeYourMarket.Service;
//using BeYourMarket.Web.Models;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Repository.Pattern.UnitOfWork;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

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
using BeYourMarket.Web.Utilities;

namespace BeYourMarket.Web.Controllers
{

    public class SettingsController : Controller
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
        private readonly IAspNetUserService _aspNetUserService;
        private readonly IBanksService _banksService;
        private readonly ITiposContaBancariaService _tiposContaBancariaService;
        private readonly IUserBankDetailsService _userBankDetailsService;
        private readonly ITiposChavePixService _tiposChavePixService;
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
        public SettingsController(
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
           IAspNetUserService aspNetUserService,
           IBanksService banksService,
           ITiposContaBancariaService tiposContaBancariaService,
           IUserBankDetailsService userBankDetailsService,
           ITiposChavePixService tiposChavePixService,
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
            _aspNetUserService = aspNetUserService;
            _banksService = banksService;
            _tiposContaBancariaService = tiposContaBancariaService;
            _userBankDetailsService = userBankDetailsService;
            _tiposChavePixService = tiposChavePixService;
        }
        #endregion

        // GET: User Configuration
        /// <summary>
        /// Carregar a View para realizar as configurações de Usuário
        /// </summary>
        /// <param name="id">Id da Conta Bancária</param>
        /// <param name="userId_">Id do Usuário</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> SettingsUpdate(int? id, string userId_, int? oqeq) 
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);
            var uBank = CacheHelper.UserBankDetails.Where(u => (u.Id_User_UBankDetails == userId)).FirstOrDefault();

            id = ((uBank != null) && ((id == 0) || (id == null))) ? uBank.Id_UBankDetails : 0;

            UserBankDetails dadosBancariosUser = new UserBankDetails();
            var model = new SettingsUpdateModel()
            {
                id_User = userId,
                BancosPais = CacheHelper.Banks.ToList(),
                TpContaBancaria = CacheHelper.TiposContaBancaria,
                TpChavesPix = CacheHelper.TiposChavePix,
                id_CB = (int)id
            };

            if (id > 0)
            {
                // return unauthorized if not authenticated
                if (!User.Identity.IsAuthenticated)
                    return new HttpUnauthorizedResult();

                if (await NotMeListing(id.Value))
                    return new HttpUnauthorizedResult();

                dadosBancariosUser = await _userBankDetailsService.FindAsync(id);

                if (dadosBancariosUser == null)
                    return new HttpNotFoundResult();
            }

            // Populate model with listing
            //if (id > 0)
                await PopulateSettingsUpdateModel(id, dadosBancariosUser, model);

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/Settings/SettingsUpdate.cshtml", model);
        }

        private async Task<SettingsUpdateModel> PopulateSettingsUpdateModel(int? id, UserBankDetails dadosBancariosUser, SettingsUpdateModel model)
        {
            var userData = CacheHelper.AspNetUsers.Where(u => (u.Id == model.id_User)).FirstOrDefault();

            //Populando dados do perfil
            model.primeiroNomeUsuario = userData.FirstName;
            model.segundoNomeUsuario = userData.LastName;
            model.cpfUsuario = (userData.cpf_Usuario != null) ? Utilitarios.FormatCPF(userData.cpf_Usuario) : "";
            model.emailUsuario = userData.Email;
            model.dataNascimento = String.Format("{0:dd/MM/yyyy}", userData.Data_Nascimento);
            model.idEstadoUF = userData.id_UF;
            model.idCidadeUF = userData.id_Cidade;
            model.EstadosUF = CacheHelper.EstadoUf.Where(e => (e.ID > 0)).ToList();
            model.CidadesUF = CacheHelper.Cidade.Where(c => (c.FK_ESTADO == userData.id_UF)).ToList();
            model.inCep = !String.IsNullOrEmpty(userData.Cep_Bairro_Cidade) ? Convert.ToUInt64(userData.Cep_Bairro_Cidade.Replace("-","")).ToString(@"00000\-000").ToString() : "";
            model.inLogradouro = userData.Logradouro_Cidade;
            model.inComplemento = userData.Complemento_Endereco;
            model.inBairro = userData.Bairro_Cidade;
            model.inTelefone1 = !String.IsNullOrEmpty(userData.PhoneNumber) ? Utilitarios.formatPhNumber(userData.PhoneNumber,"") : "";
            model.inTelefone2 = !String.IsNullOrEmpty(userData.PhoneNumberWhats) ? Utilitarios.formatPhNumber(userData.PhoneNumberWhats, "") : "";

            //CONTINUAR AQUI...

            // 1) CARREGAR DADOS DA EMPRESA PARA EXIBIÇÃO;
            // 2) VER O QUE NECESSITA PRA GRAVAÇÃO;

            //Populando dados bancários do perfil
            model.id_CB = dadosBancariosUser.Id_UBankDetails;
            model.id_Banco = dadosBancariosUser.id_Bank;
            model.AgenciaBancaria = dadosBancariosUser.Cod_Agencia;
            model.id_TpConta = dadosBancariosUser.id_TipoConta;
            model.NumeroContaBancaria = dadosBancariosUser.Cod_Conta;
            model.DigContaBancaria = dadosBancariosUser.Cod_Dig_Conta;
            model.id_TpChavePix = dadosBancariosUser.id_TipoChavePix;
            model.ChavePix = dadosBancariosUser.Chave_Pix_Conta;

            return model;
        }

        //================================================================
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

        //public static string formatPhNumber(string phoneNum, string phoneFormat)
        //{
        //    if (phoneFormat == "")
        //    {
        //        phoneFormat = "(##) #####-####";
        //    }
        //    Regex regex = new Regex(@"[^\d]");
        //    phoneNum = regex.Replace(phoneNum, "");
        //    if (phoneNum.Length > 0)
        //    {
        //        phoneNum = Convert.ToInt64(phoneNum).ToString(phoneFormat);
        //    }
        //    return phoneNum;
        //}
        //================================================================

        public async Task<bool> NotMeListing(int id)
        {
            var userId = User.Identity.GetUserId();
            var item = await _userBankDetailsService.FindAsync(id);
            return item.Id_User_UBankDetails != userId;
        }

        /// <summary>
        /// Gravação dos dados de DESEJO COMPRAR, de um comprador do MKTPLACE. Inclusão de NOVO e EDIÇÃO
        /// </summary>
        /// <param name="form"></param>
        /// <param name="files"></param>
        /// <param name="oqeq"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public async Task<ActionResult> SettingsUpdate(UserBankDetails contaBancariaUsuario, FormCollection form, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            bool updateCount = false;
            int operation = 0; // 0 - Inclusão Oferta de Compra / 1 - Edição de Oferta de Compra

            if (Convert.ToInt32(form.Get("id_CB")) == 0)
            {
                //INSERIR NOVA CONTA BANCÁRIA
                updateCount = true;
                var contaBancariaDoUsuario = new UserBankDetails()
                {
                    Id_User_UBankDetails = userIdCurrent,
                    id_TipoConta = Convert.ToInt32(form.Get("id_TpConta")),
                    id_TipoChavePix = Convert.ToInt32(form.Get("id_TpChavePix")),
                    id_Bank = Convert.ToInt32(form.Get("id_Banco")),
                    Cod_Agencia = form.Get("inAgencia"),
                    Cod_Conta = form.Get("inNumeroConta"),
                    Cod_Dig_Conta = form.Get("inDigito"),
                    Chave_Pix_Conta = form.Get("inChavePix"),
                    Data_Cadastro_UBankDetails = DateTime.Now
                };

                contaBancariaUsuario = contaBancariaDoUsuario;
                _userBankDetailsService.Insert(contaBancariaUsuario);
            }
            else
            {
                //EDITAR CPONTA BANCÁRIA
                if (await NotMeListing(Convert.ToInt32(form.Get("id_CB"))))
                    return new HttpUnauthorizedResult();

                var contaBancariaExisting = await _userBankDetailsService.FindAsync(Convert.ToInt32(form.Get("id_CB")));

                contaBancariaExisting.id_TipoConta = Convert.ToInt32(form.Get("id_TpConta"));
                contaBancariaExisting.id_TipoChavePix = Convert.ToInt32(form.Get("id_TpChavePix"));
                contaBancariaExisting.id_Bank = Convert.ToInt32(form.Get("id_Banco"));
                contaBancariaExisting.Cod_Agencia = form.Get("inAgencia");
                contaBancariaExisting.Cod_Conta = form.Get("inNumeroConta");
                contaBancariaExisting.Cod_Dig_Conta = form.Get("inDigito");
                contaBancariaExisting.Chave_Pix_Conta = form.Get("inChavePix");
                contaBancariaExisting.Data_Cadastro_UBankDetails = DateTime.Now;

                contaBancariaUsuario = contaBancariaExisting;
                _userBankDetailsService.Update(contaBancariaUsuario);
                operation = 1;
            }

            await _unitOfWorkAsync.SaveChangesAsync();

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[Conta Bancária cadastrada com Sucesso!]]]" : "[[[Conta Bancária alterada com Sucesso!]]]";
            return RedirectToAction("SettingsUpdate", new { id = contaBancariaUsuario.Id_UBankDetails, userId_ = userIdCurrent });
        }
    }
}