using BeYourMarket.Core.Web;
using BeYourMarket.Model.Models;
using BeYourMarket.Service;
using BeYourMarket.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeYourMarket.Web.Controllers
{
    public class SearchPriceController : Controller
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
        public SearchPriceController(
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
        }
        #endregion

        // GET: SearchPrice IN GROUP
        /// <summary>
        /// Carregar a View para Criação da Cotação em Grupo
        /// </summary>
        /// <param name="id">Id da Cotação</param>
        /// <param name="userId_">Id do Usuário</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        public async Task<ActionResult> SearchInGroup(int? id, string userId_, int? oqeq)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            var model = new SearchUpdateModel()
            {
                idCotacao = 0,
                inTipoCotacao = 1,
                DataEncerramento = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(30)),
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf.OrderBy(e => (e.CODIGO)).ToList(),
                Unidades = CacheHelper.Unidades,
                Local = "E"
            };

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/SearchInGroup.cshtml", model);
        }

        /// <summary>
        /// Carrega a lista de Cidades
        /// </summary>
        /// <param name="idUf">String contendo a UF</param>
        /// <returns></returns>
        public ActionResult CarregaCidadesUF(int idUf)
        {
            var listaCidades = CacheHelper.Cidade.Where(c => (c.FK_ESTADO == idUf)).ToList();
            return Json(listaCidades, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Consulta lista de Empresas Fornecedoras de um determinado produto (Regionalm / País)
        /// </summary>
        /// <param name="quant">Quantidade de empresas a retornar</param>
        /// <param name="local">Local a ser considerado na consulta (UF ou BR)</param>
        /// <returns></returns>
        public ActionResult CarregarEmpresasFornecedoras(string quant, string local, int gativ)
        {
            var uf = (local != "BR") ? CacheHelper.EstadoUf.FirstOrDefault(e => (e.ID == Convert.ToInt32(local))) : null;
            var listaEmpresasForn = ((local != "BR") && (local != null)) 
                ? CacheHelper.EmpresaUsuario.Where(e => ((e.UF_Empresa == uf.SIGLA) && (e.id_GrupoAtividades == gativ))).Distinct().ToList().Take(Convert.ToInt32(quant)) 
                : CacheHelper.EmpresaUsuario.Where(e => (e.id_GrupoAtividades == gativ)).OrderBy(e => (Guid.NewGuid())).Distinct().ToList().Take(Convert.ToInt32(quant));
            return Json(listaEmpresasForn, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Carregar dados das Empresas Forncedoras Cotadas
        /// </summary>
        /// <param name="idcm">Id da Cotação Master</param>
        /// <returns></returns>
        public ActionResult CarregarEmpresasFornCotadas(int idcm)
        {
            var listaFornecedoresCotacao = CacheHelper.FornecedoresCotacao.Where(f => (f.id_CotacaoMaster == idcm)).Select(f => f.Id_Empresa).ToList();
            var listaDadosEmpresasForn = CacheHelper.EmpresaUsuario.Where(e => (listaFornecedoresCotacao.Contains(e.Id_Empresa))).Distinct().ToList();
            var fornecedoresCotados = CacheHelper.FornecedoresCotacao.Where(f => (f.id_CotacaoMaster == idcm)).ToList();
            var idsCotados = fornecedoresCotados.Select(f => f.Id_FornecedoresCotacao).ToArray();
            var fornecedoresCotadosResposta = CacheHelper.RespostaFornecedoresCotacao.Where(r => (idsCotados.Contains(r.Id_FornecedoresCotacao))).Distinct().ToList();
            var quantidadeTotalCompra = CacheHelper.ItensCotacao.Where(i => (i.id_CotacaoMaster == idcm)).Select(i => (i.Quantidade_ItemCotacao)).Sum();
            var idForncedorMelhorMenorPreco = FornecedorComMenorPrecoRespondido(fornecedoresCotadosResposta, quantidadeTotalCompra); 

            //PARA IMPLEMENTAR:
            //3º) EFETUAR O PEDIDO;

            var cont = 0;
            List<ListaEmpresasCotadasERespostas> listaCotantesComSuasRespostas = new List<ListaEmpresasCotadasERespostas>();
            foreach (var item in listaDadosEmpresasForn)
            {
                var respondidoFornecedor = fornecedoresCotadosResposta.FirstOrDefault(f => (f.Id_FornecedoresCotacao == fornecedoresCotados[cont].Id_FornecedoresCotacao));
                listaCotantesComSuasRespostas.Add(new ListaEmpresasCotadasERespostas { 
                    Fantasia_Empresa = item.Fantasia_Empresa,
                    Fone1_Empresa = item.Fone1_Empresa,
                    Email1_Empresa = item.Email1_Empresa,
                    localizacaoEmpresaFornecedor = item.Cidade_Empresa + "-" + item.UF_Empresa,
                    quantidadeQuePodeAtender = (respondidoFornecedor != null) ? respondidoFornecedor.Quantidade_ItemCotado.ToString("N2") : "0,00",
                    valorRespondidoPorUnidade = (respondidoFornecedor != null) ? respondidoFornecedor.ValorUnitario_Resposta.ToString("N2") : "0,00",
                    valorTotalCotado = (respondidoFornecedor != null) ? (Convert.ToDecimal(respondidoFornecedor.Quantidade_ItemCotado) * Convert.ToDecimal(respondidoFornecedor.ValorUnitario_Resposta)).ToString("N2")
                    : "0,00",
                    menorValorCotado = (fornecedoresCotados[cont].Id_FornecedoresCotacao == idForncedorMelhorMenorPreco) ? true : false
                });
                cont++;
            }
            return Json(listaCotantesComSuasRespostas, JsonRequestBehavior.AllowGet); 
        }

        /// <summary>
        /// Carregar a View para Criação da Cotação Individual
        /// </summary>
        /// <param name="id">Id da Cotação</param>
        /// <param name="userId_">Id do Usuário</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        public async Task<ActionResult> SearchIndividual(int? id, string userId_, int? oqeq)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            var model = new SearchUpdateModel()
            {
                idCotacao = 0,
                inTipoCotacao = 2,
                DataEncerramento = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(30)),
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf.OrderBy(e => (e.CODIGO)).ToList(),
                Unidades = CacheHelper.Unidades
            };

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/SearchInIndividual.cshtml", model);
        }

        public async Task<bool> NotMeListing(int id)
        {
            var userId = User.Identity.GetUserId();
            var item = await _listingService.FindAsync(id);
            return item.UserID != userId;
        }

        public async Task<bool> NotMeRespostaCotacao(int id)
        {
            var userId = User.Identity.GetUserId();
            var item = await _respostaFornecedoresCotacaoService.FindAsync(id);
            return item.Id_UsuarioRespondeu != userId;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SearchPGroupUpdate(FormCollection form, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            bool updateCount = false;
            int operation = 0;
            int idCotacao = 0;
            //TipoCotacao; 1 - Cotação Master - 2 - Cotação Individual

            if (Convert.ToInt32(form.Get("idSearchG")) == 0)
            {
                //INSERIR COTAÇÃO MASTER
                updateCount = true;
                string dataLimite = DateTime.Now.AddDays(30).Year.ToString() + "-" + DateTime.Now.AddDays(30).Month.ToString() + "-" + DateTime.Now.AddDays(30).Day.ToString();
                var cotacaoMaster= new Cotacao_Master()
                {
                    id_GrupoAtividades = Convert.ToInt32(form.Get("areaAtuacao")),
                    TipoCotacao = Convert.ToInt32(form.Get("inTipoCotacao")),
                    id_UF_Cotacao = Convert.ToInt32(form.Get("EstadoUF")),
                    id_Cidade_Cotacao = Convert.ToInt32(form.Get("selectedCity")),
                    Latitude = 0,
                    Longitude = 0,
                    Cotacao_Disparada = true,
                    Data_Cadastro_CotacaoMaster = DateTime.Now,
                    Data_Encerramento_CotacaoMaster = Convert.ToDateTime(dataLimite),
                    ObservacoesRelevantes = form.Get("inObsRelevant"),
                    Id_UsuarioCriou = userIdCurrent,
                    Ativa_CotacaoMaster = true
                };
                _cotacaoMasterService.Insert(cotacaoMaster);
                await _unitOfWorkAsync.SaveChangesAsync();

                //INSERIR O ITEM da COTAÇÃO MASTER
                var itemDaCotacao = new Itens_Cotacao()
                {
                    id_CotacaoMaster = cotacaoMaster.id_CotacaoMaster,
                    Descricao_ItemCotacao = form.Get("ProdutoCotado"),
                    Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantTotalCompra").Replace(",",".")),
                    UnidadeProduto = form.Get("UnidadeProduto"),
                    Id_UsuarioCriou = userIdCurrent
                };
                _itensCotacaoService.Insert(itemDaCotacao);
                await _unitOfWorkAsync.SaveChangesAsync();

                idCotacao = cotacaoMaster.id_CotacaoMaster;

                // DISPARAR E-MAILS AOS POSSÍVEIS INTERESSADOS EM PARTICIPAR DA COTAÇÃO EM GRUPO OU HABILITAR UM SERVIÇO QUE O FAÇA OPORTUNAMENTE EM OUTRO HORÁRIO.
                // OBS: QUANDO HOUVER PELO MENOS 2 PARTICIPANTES DA COTAÇÃO, VAMOS ENCAMINHAR E-MAILS AOS FORNECEDORES (DA ÁREA OU NÃO) QUE COMERCIALIZAM O TIPO DE PRODUTO PROCURADO.
                // MAIS TARDE, CRIAREMOS PARA OS FORNECEDORES UM PLANO PREMIUM QUE PERMITIRÁ AOS ASSINANTES RECEBEREM OS AVISOS DAS COTAÇÕES ANTES DE TODOS OS OUTROS; 
            }
            else
            {
                //EDITAR COTACAO MASTER
                if (await NotMeListing(Convert.ToInt32(form.Get("idSearchG"))))
                    return new HttpUnauthorizedResult();

                var cotacaoMasterExisting = await _cotacaoMasterService.FindAsync(Convert.ToInt32(form.Get("idSearchG")));

                cotacaoMasterExisting.id_GrupoAtividades = Convert.ToInt32(form.Get("areaAtuacao"));
                cotacaoMasterExisting.id_UF_Cotacao = Convert.ToInt32(form.Get("EstadoUF"));
                cotacaoMasterExisting.id_Cidade_Cotacao = Convert.ToInt32(form.Get("selectedCity"));
                cotacaoMasterExisting.ObservacoesRelevantes = form.Get("inObsRelevant");

                _cotacaoMasterService.Update(cotacaoMasterExisting);

                //EDITAR ITEM da COTACAO MASTER
                var itensCotacaoMasterExisting = await _itensCotacaoService.FindAsync(Convert.ToInt32(form.Get("idIC")));

                itensCotacaoMasterExisting.Descricao_ItemCotacao = form.Get("ProdutoCotado");
                itensCotacaoMasterExisting.Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantTotalCompra").Replace(",", "."));
                itensCotacaoMasterExisting.UnidadeProduto = form.Get("UnidadeProduto");

                _itensCotacaoService.Update(itensCotacaoMasterExisting);

                await _unitOfWorkAsync.SaveChangesAsync();
                idCotacao = cotacaoMasterExisting.id_CotacaoMaster;
                operation = 1;
            }

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[COTAÇÃO em GRUPO incluída com Sucesso!]]]" : "[[[COTAÇÃO em GRUPO alterada com Sucesso!]]]";
            return RedirectToAction("SearchPGroupUpdate", new { id = idCotacao, userId_ = userIdCurrent });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SearchPGroupUpdateAdd(FormCollection form, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            bool updateCount = false;
            int operation = 0;
            int idCotacao = 0;
            //TipoCotacao; 1 - Cotação Master - 2 - Cotação Individual

            if (Convert.ToInt32(form.Get("idIC")) == 0)
            {
                //INSERIR MINHA PARTICIPAÇÃO NA COTAÇÃO EM GRUPO
                updateCount = true;
                var itemDaCotacao = new Itens_Cotacao()
                {
                    id_CotacaoMaster = Convert.ToInt32(form.Get("idSearchG")),
                    Descricao_ItemCotacao = form.Get("ProdutoCotado"),
                    Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantMeuPedido").Replace(",", ".")),
                    UnidadeProduto = form.Get("inUnidadeProduto"),
                    Id_UsuarioCriou = userIdCurrent
                };
                _itensCotacaoService.Insert(itemDaCotacao);
                await _unitOfWorkAsync.SaveChangesAsync();

                idCotacao = itemDaCotacao.id_CotacaoMaster;

                // DISPARAR E-MAILS AOS POSSÍVEIS INTERESSADOS EM PARTICIPAR DA COTAÇÃO EM GRUPO OU HABILITAR UM SERVIÇO QUE O FAÇA OPORTUNAMENTE EM OUTRO HORÁRIO.
                // OBS: QUANDO HOUVER PELO MENOS 2 PARTICIPANTES DA COTAÇÃO, VAMOS ENCAMINHAR E-MAILS AOS FORNECEDORES (DA ÁREA OU NÃO) QUE COMERCIALIZAM O TIPO DE PRODUTO PROCURADO.
                // MAIS TARDE, CRIAREMOS PARA OS FORNECEDORES UM PLANO PREMIUM QUE PERMITIRÁ AOS ASSINANTES RECEBEREM OS AVISOS DAS COTAÇÕES ANTES DE TODOS OS OUTROS; 
            }
            else
            {
                //EDITAR MINHA PARTICIPAÇÃO NA COTAÇÃO EM GRUPO
                //if (await NotMeListing(Convert.ToInt32(form.Get("idSearchG"))))
                //    return new HttpUnauthorizedResult();

                var itensCotacaoMasterExisting = await _itensCotacaoService.FindAsync(Convert.ToInt32(form.Get("idIC")));

                itensCotacaoMasterExisting.Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantMeuPedido").Replace(",", "."));

                _itensCotacaoService.Update(itensCotacaoMasterExisting);

                await _unitOfWorkAsync.SaveChangesAsync();
                idCotacao = itensCotacaoMasterExisting.id_CotacaoMaster;
                operation = 1;
            }

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[Minha PARTICIPAÇÃO na COTAÇÃO em GRUPO incluída com Sucesso!]]]" : "[[[Minha PARTICIPAÇÃO na COTAÇÃO em GRUPO alterada com Sucesso!]]]";
            return RedirectToAction("SearchPGroupUpdateAdd", new { id = idCotacao, userId_ = userIdCurrent });
        }

        /// <summary>
        /// Inserir / Editar Cotação Individual
        /// </summary>
        /// <param name="form">Formulário da View</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SearchPInIndividualUpdate(FormCollection form, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            bool updateCount = false;
            int operation = 0;
            int idCotacao = 0;
            //TipoCotacao; 1 - Cotação Master - 2 - Cotação Individual

            if (Convert.ToInt32(form.Get("idSearchI")) == 0)
            {
                //INSERIR COTAÇÃO INDIVIDUAL
                updateCount = true;
                string dataLimite = DateTime.Now.AddDays(30).Year.ToString() + "-" + DateTime.Now.AddDays(30).Month.ToString() + "-" + DateTime.Now.AddDays(30).Day.ToString();
                var cotacaoMaster = new Cotacao_Master()
                {
                    id_GrupoAtividades = Convert.ToInt32(form.Get("areaAtuacao")),
                    TipoCotacao = Convert.ToInt32(form.Get("inTipoCotacao")),
                    id_UF_Cotacao = Convert.ToInt32(form.Get("EstadoUF")),
                    id_Cidade_Cotacao = Convert.ToInt32(form.Get("selectedCity")),
                    Latitude = 0,
                    Longitude = 0,
                    Cotacao_Disparada = true,
                    Data_Cadastro_CotacaoMaster = DateTime.Now,
                    Data_Encerramento_CotacaoMaster = Convert.ToDateTime(dataLimite),
                    ObservacoesRelevantes = form.Get("inObsRelevant"),
                    Id_UsuarioCriou = userIdCurrent,
                    Ativa_CotacaoMaster = true
                };
                _cotacaoMasterService.Insert(cotacaoMaster);
                await _unitOfWorkAsync.SaveChangesAsync();

                //INSERIR O ITEM da COTAÇÃO INDIVIDUAL
                var itemDaCotacao = new Itens_Cotacao()
                {
                    id_CotacaoMaster = cotacaoMaster.id_CotacaoMaster,
                    Descricao_ItemCotacao = form.Get("ProdutoCotado"),
                    Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantTotalCompra").Replace(",", ".")),
                    UnidadeProduto = form.Get("UnidadeProduto"),
                    Id_UsuarioCriou = userIdCurrent
                };
                _itensCotacaoService.Insert(itemDaCotacao);
                await _unitOfWorkAsync.SaveChangesAsync();

                idCotacao = cotacaoMaster.id_CotacaoMaster;

                // DISPARAR E-MAILS AOS FORNCEDORES OU HABILITAR UM SERVIÇO QUE O FAÇA OPORTUNAMENTE EM OUTRO HORÁRIO.
                // OBS: POR ORA, VAMOS ENCAMINHAR E-MAILS AOS FORNECEDORES DA ÁREA QUE COMERCIALIZAM O TIPO DE PRODUTO PROCURADO. MAIS TARDE, CRIAREMOS PARA OS FORNECEDORES UM PLANO PREMIUM QUE PERMITIRÁ
                // AOS ASSINANTES RECEBEREM OS AVISOS DAS COTAÇÕES ANTES DE TODOS OS OUTROS; 
            }
            else
            {
                //EDITAR COTACAO INDIVIDUAL
                if (await NotMeListing(Convert.ToInt32(form.Get("idSearchI"))))
                    return new HttpUnauthorizedResult();

                var cotacaoMasterExisting = await _cotacaoMasterService.FindAsync(Convert.ToInt32(form.Get("idSearchI")));

                cotacaoMasterExisting.id_GrupoAtividades = Convert.ToInt32(form.Get("areaAtuacao"));
                cotacaoMasterExisting.id_UF_Cotacao = Convert.ToInt32(form.Get("EstadoUF"));
                cotacaoMasterExisting.id_Cidade_Cotacao = Convert.ToInt32(form.Get("selectedCity"));
                cotacaoMasterExisting.ObservacoesRelevantes = form.Get("inObsRelevant");

                _cotacaoMasterService.Update(cotacaoMasterExisting);

                //EDITAR ITEM da COTAÇÃO INDIVIDUAL
                var itensCotacaoMasterExisting = await _itensCotacaoService.FindAsync(Convert.ToInt32(form.Get("idIC")));
                itensCotacaoMasterExisting.Descricao_ItemCotacao = form.Get("ProdutoCotado");
                itensCotacaoMasterExisting.Quantidade_ItemCotacao = Convert.ToDecimal(form.Get("inQuantTotalCompra").Replace(",", "."));
                itensCotacaoMasterExisting.UnidadeProduto = form.Get("UnidadeProduto");

                _itensCotacaoService.Update(itensCotacaoMasterExisting);

                await _unitOfWorkAsync.SaveChangesAsync();
                idCotacao = cotacaoMasterExisting.id_CotacaoMaster;
                operation = 1;
            }

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[COTAÇÃO INDIVIDUAL incluída com Sucesso!]]]" : "[[[COTAÇÃO INDIVIDUAL alterada com Sucesso!]]]";
            return RedirectToAction("SearchPInIndividualUpdate", new { id = idCotacao, userId_ = userIdCurrent });
        }

        [AllowAnonymous]
        public async Task<ActionResult> SearchPGroupUpdate(int? id, string userId_, int? oqeq)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            Cotacao_Master cotacaoMaster;
            List<Itens_Cotacao> itensCotacao = new List<Itens_Cotacao>();
            List<Itens_Cotacao> itensCotacaoAdd = new List<Itens_Cotacao>();
            List<Itens_Cotacao> itensCotacaoAddOutros = new List<Itens_Cotacao>();
            List<FornecedoresCotacao> fornecedoresCotados = new List<FornecedoresCotacao>();
            List<Resposta_FornecedoresCotacao> fornecedoresCotadosResposta = new List<Resposta_FornecedoresCotacao>();

            // LISTAS
            var model = new SearchUpdateModel()
            {
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf,
                CidadesUF = CacheHelper.Cidade,
                cidades_coordenadas = CacheHelper.Cidade_Geo,
                Unidades = CacheHelper.Unidades
            };

            if (id.HasValue)
            {
                cotacaoMaster = await _cotacaoMasterService.FindAsync(id);
                itensCotacao = CacheHelper.ItensCotacao.Where(i => i.id_CotacaoMaster == id).ToList();
                itensCotacaoAdd = CacheHelper.ItensCotacao.Where(i => ((i.id_CotacaoMaster == id) && (i.Id_UsuarioCriou == userId) && (userId == cotacaoMaster.Id_UsuarioCriou))).ToList();
                itensCotacaoAddOutros = CacheHelper.ItensCotacao.Where(i => ((i.id_CotacaoMaster == id) && (i.Id_UsuarioCriou != userId))).ToList();
                fornecedoresCotados = CacheHelper.FornecedoresCotacao.Where(f => (f.id_CotacaoMaster == id)).ToList();
                var idsCotados = fornecedoresCotados.Select(f => f.Id_FornecedoresCotacao).ToArray();
                fornecedoresCotadosResposta = CacheHelper.RespostaFornecedoresCotacao.Where(r => (idsCotados.Contains(r.Id_FornecedoresCotacao))).Distinct().ToList();
            }
            else
            {
                cotacaoMaster = new Cotacao_Master()
                {
                    id_GrupoAtividades = CacheHelper.GrupoAtividadesEmpresa.Any() ? CacheHelper.GrupoAtividadesEmpresa.FirstOrDefault().id_GrupoAtividades : 0,
                    id_UF_Cotacao = CacheHelper.EstadoUf.Any() ? CacheHelper.EstadoUf.FirstOrDefault().ID : 0,
                    id_Cidade_Cotacao = CacheHelper.Cidade.Any() ? CacheHelper.Cidade.FirstOrDefault().ID : 0,
                    Id_UsuarioCriou = userId,
                    Id_Empresa_Vencedora_CotacaoMaster = CacheHelper.EmpresaUsuario.Any() ? CacheHelper.EmpresaUsuario.FirstOrDefault().Id_Empresa : 0
                };
            }

            // Populate model with listing
            await PopulateSearchPGroupUpdateModel(cotacaoMaster, itensCotacao, itensCotacaoAdd, itensCotacaoAddOutros, fornecedoresCotados, fornecedoresCotadosResposta, model);

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/SearchInGroup.cshtml", model);
        }

        [AllowAnonymous]
        public async Task<ActionResult> SearchPGroupUpdateAdd(int? id, string userId_, int? oqeq)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            Cotacao_Master cotacaoMaster;
            List<Itens_Cotacao> itensCotacao = new List<Itens_Cotacao>();
            List<Itens_Cotacao> itensCotacaoAdd = new List<Itens_Cotacao>();
            List<Itens_Cotacao> itensCotacaoAddOutros = new List<Itens_Cotacao>();
            List<FornecedoresCotacao> fornecedoresCotados = new List<FornecedoresCotacao>();
            List<Resposta_FornecedoresCotacao> fornecedoresCotadosResposta = new List<Resposta_FornecedoresCotacao>();

            // LISTAS
            var model = new SearchUpdateModel()
            {
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf,
                CidadesUF = CacheHelper.Cidade,
                cidades_coordenadas = CacheHelper.Cidade_Geo,
                Unidades = CacheHelper.Unidades
            };

            if (id.HasValue)
            {
                cotacaoMaster = await _cotacaoMasterService.FindAsync(id);
                itensCotacao = CacheHelper.ItensCotacao.Where(i => i.id_CotacaoMaster == id).ToList();
                itensCotacaoAdd = CacheHelper.ItensCotacao.Where(i => ((i.id_CotacaoMaster == id) && (i.Id_UsuarioCriou == userId) && (userId != cotacaoMaster.Id_UsuarioCriou))).ToList();
                if (itensCotacaoAdd.Count == 0)
                    itensCotacaoAdd.Add(new Itens_Cotacao { Id_ItemCotacao = 0,  Quantidade_ItemCotacao = 0 });
                fornecedoresCotados = CacheHelper.FornecedoresCotacao.Where(f => (f.id_CotacaoMaster == id)).ToList(); //PRECISO NOME DA EMPRESA. SE RESPONDEU OU NAO, DATA Q RECEBEU <== CONTINUAR AQUI
            }
            else
            {
                cotacaoMaster = new Cotacao_Master()
                {
                    id_GrupoAtividades = CacheHelper.GrupoAtividadesEmpresa.Any() ? CacheHelper.GrupoAtividadesEmpresa.FirstOrDefault().id_GrupoAtividades : 0,
                    id_UF_Cotacao = CacheHelper.EstadoUf.Any() ? CacheHelper.EstadoUf.FirstOrDefault().ID : 0,
                    id_Cidade_Cotacao = CacheHelper.Cidade.Any() ? CacheHelper.Cidade.FirstOrDefault().ID : 0,
                    Id_UsuarioCriou = userId,
                    Id_Empresa_Vencedora_CotacaoMaster = CacheHelper.EmpresaUsuario.Any() ? CacheHelper.EmpresaUsuario.FirstOrDefault().Id_Empresa : 0
                };
            }

            // Populate model with listing
            await PopulateSearchPGroupUpdateModel(cotacaoMaster, itensCotacao, itensCotacaoAdd, itensCotacaoAddOutros, fornecedoresCotados, fornecedoresCotadosResposta, model);

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/AddMyQuote.cshtml", model);
        }

        private async Task<SearchUpdateModel> PopulateSearchPGroupUpdateModel(Cotacao_Master cotacaoMaster, List<Itens_Cotacao> itensCotacao, List<Itens_Cotacao> itensCotacaoAdd, 
            List<Itens_Cotacao> itensCotacaoAddOutros, List<FornecedoresCotacao> fornecedoresCotados, List<Resposta_FornecedoresCotacao> fornecedoresCotadosResposta, SearchUpdateModel model)
        {
            model.idCotacao = cotacaoMaster.id_CotacaoMaster;
            model.areaAtuacao = cotacaoMaster.id_GrupoAtividades.ToString();
            model.inTipoCotacao = cotacaoMaster.TipoCotacao;
            model.EstadoUF = cotacaoMaster.id_UF_Cotacao.ToString();
            model.CidadeUF = cotacaoMaster.id_Cidade_Cotacao.ToString();
            model.Latitude = cotacaoMaster.Latitude;
            model.Longitude = cotacaoMaster.Longitude;
            model.DataEncerramento = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Encerramento_CotacaoMaster);
            model.DataCadastro = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Cadastro_CotacaoMaster);
            model.id_ItemCotacao = itensCotacao[0].Id_ItemCotacao;
            model.id_ItemCotacaoAdd = (itensCotacaoAdd.Count > 0) ? itensCotacaoAdd[0].Id_ItemCotacao : 0;
            model.ProdutoCotado = itensCotacao[0].Descricao_ItemCotacao;
            model.UnidadeProduto = itensCotacao[0].UnidadeProduto;
            model.QuantidadeTotalCompra = itensCotacao.Where(i => (i.id_CotacaoMaster == cotacaoMaster.id_CotacaoMaster)).Select(i => (i.Quantidade_ItemCotacao)).Sum().ToString("N2");
            model.QuantidadeMeuPedido = (itensCotacaoAdd.Count > 0) ? itensCotacaoAdd[0].Quantidade_ItemCotacao.ToString("N2") : "";
            model.ObservacoesRelevantes = cotacaoMaster.ObservacoesRelevantes;
            model.FornecedoresCotados = fornecedoresCotados;
            model.RespostaFornecedoresCotados = fornecedoresCotadosResposta;
            model.ListaDeOutrosCotantes = CarregarDadosDeCotantes(itensCotacaoAddOutros);
            model.Local = "E";
            return model;
        }

        /// <summary>
        /// Carregar dados de Usuários Cotantes que fazem parte da Cotação
        /// </summary>
        /// <param name="itensCotacaoAddOutros">Lista de ids de Outros participantes da Cotação</param>
        /// <returns></returns>
        private List<ListingDadosCotantes> CarregarDadosDeCotantes(List<Itens_Cotacao> itensCotacaoAddOutros)
        {
            var b = 0;
            var idsCotantes = itensCotacaoAddOutros.Select(i => i.Id_UsuarioCriou).ToArray();
            var listaUsuarios = CacheHelper.AspNetUsers.Where(a => idsCotantes.Contains(a.Id)).ToList();
            List<ListingDadosCotantes> listaDadosUsersCotantes = new List<ListingDadosCotantes>();
            foreach (var item in listaUsuarios)
            {
                ListingDadosCotantes dadosCotante = new ListingDadosCotantes();
                dadosCotante.Id = item.Id;
                dadosCotante.FirstName = item.FirstName;
                dadosCotante.Email = item.Email;
                dadosCotante.PhoneNumber = item.PhoneNumber;
                var cidade = CacheHelper.Cidade.FirstOrDefault(c => (c.ID == item.id_Cidade));
                var estado = CacheHelper.EstadoUf.FirstOrDefault(e => (e.ID == item.id_UF));
                dadosCotante.cidadePed = cidade.NOME + "-" + estado.SIGLA;
                dadosCotante.qPed = itensCotacaoAddOutros[b].Quantidade_ItemCotacao.ToString("N2");
                listaDadosUsersCotantes.Add(dadosCotante);
                b++;
            }
            return listaDadosUsersCotantes;
        }

        /// <summary>
        /// Carregar dados para exibição na View, geralmente usado para Edição
        /// </summary>
        /// <param name="id">Id da Cotação</param>
        /// <param name="userId_">Id do Usuário</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> SearchPInIndividualUpdate(int? id, string userId_, int? oqeq)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            Cotacao_Master cotacaoMaster;
            List<Itens_Cotacao> itensCotacao = new List<Itens_Cotacao>();

            // LISTAS
            var model = new SearchUpdateModel()
            {
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf,
                CidadesUF = CacheHelper.Cidade,
                cidades_coordenadas = CacheHelper.Cidade_Geo,
                Unidades = CacheHelper.Unidades
            };

            if (id.HasValue)
            {
                cotacaoMaster = await _cotacaoMasterService.FindAsync(id);
                itensCotacao = CacheHelper.ItensCotacao.Where(i => i.id_CotacaoMaster == id).ToList();
            }
            else
            {
                cotacaoMaster = new Cotacao_Master()
                {
                    id_GrupoAtividades = CacheHelper.GrupoAtividadesEmpresa.Any() ? CacheHelper.GrupoAtividadesEmpresa.FirstOrDefault().id_GrupoAtividades : 0,
                    id_UF_Cotacao = CacheHelper.EstadoUf.Any() ? CacheHelper.EstadoUf.FirstOrDefault().ID : 0,
                    id_Cidade_Cotacao = CacheHelper.Cidade.Any() ? CacheHelper.Cidade.FirstOrDefault().ID : 0,
                    Id_UsuarioCriou = userId,
                    Id_Empresa_Vencedora_CotacaoMaster = CacheHelper.EmpresaUsuario.Any() ? CacheHelper.EmpresaUsuario.FirstOrDefault().Id_Empresa : 0
                };
            }

            // Populate model with listing
            await PopulateSearchPInIndividualUpdateModel(cotacaoMaster, itensCotacao, model);

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/SearchInIndividual.cshtml", model);
        }

        /// <summary>
        /// Carrega a View usada para Responder a Cotação
        /// </summary>
        /// <param name="id">Id da Cotação</param>
        /// <param name="userId_">Id do Usuário</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <param name="tpC">Tipo da Cotação (1-Em Grupo / 2-Individual)</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> ReplyQuoteUpdate(int? id, string userId_, int? oqeq, int tpC, int iE)
        {
            var userId = (User.Identity.GetUserId() != null) ? User.Identity.GetUserId() : userId_;
            var user = await UserManager.FindByIdAsync(userId);

            Cotacao_Master cotacaoMaster;
            List<Itens_Cotacao> itensCotacao = new List<Itens_Cotacao>();
            FornecedoresCotacao fornecedoresCotados;
            Resposta_FornecedoresCotacao respostaCotacao = new Resposta_FornecedoresCotacao();

            // LISTAS
            var model = new SearchUpdateModel()
            {
                TiposAtividades = CacheHelper.GrupoAtividadesEmpresa,
                EstadosUF = CacheHelper.EstadoUf,
                CidadesUF = CacheHelper.Cidade,
                cidades_coordenadas = CacheHelper.Cidade_Geo,
                Unidades = CacheHelper.Unidades,
                TiposFrete = CacheHelper.TiposFrete
            };

            if (id.HasValue)
            {
                cotacaoMaster = await _cotacaoMasterService.FindAsync(id);
                fornecedoresCotados = CacheHelper.FornecedoresCotacao.FirstOrDefault(f => (f.id_CotacaoMaster == cotacaoMaster.id_CotacaoMaster) && (f.Id_Empresa == iE));
                itensCotacao = CacheHelper.ItensCotacao.Where(i => i.id_CotacaoMaster == id).ToList();
                respostaCotacao = CacheHelper.RespostaFornecedoresCotacao.FirstOrDefault(r => (r.Id_ItemCotacao == itensCotacao[0].Id_ItemCotacao) && (r.Id_FornecedoresCotacao == fornecedoresCotados.Id_FornecedoresCotacao));
            }
            else
            {
                cotacaoMaster = new Cotacao_Master()
                {
                    id_GrupoAtividades = CacheHelper.GrupoAtividadesEmpresa.Any() ? CacheHelper.GrupoAtividadesEmpresa.FirstOrDefault().id_GrupoAtividades : 0,
                    id_UF_Cotacao = CacheHelper.EstadoUf.Any() ? CacheHelper.EstadoUf.FirstOrDefault().ID : 0,
                    id_Cidade_Cotacao = CacheHelper.Cidade.Any() ? CacheHelper.Cidade.FirstOrDefault().ID : 0,
                    Id_UsuarioCriou = userId,
                    Id_Empresa_Vencedora_CotacaoMaster = CacheHelper.EmpresaUsuario.Any() ? CacheHelper.EmpresaUsuario.FirstOrDefault().Id_Empresa : 0
                };
            }

            // Populate model with listing
            await PopulateReplyQuoteUpdateModel(cotacaoMaster, itensCotacao, respostaCotacao, model);

            ViewBag.MessageTipoC = (tpC == 1) ? "Respondendo COTAÇÃO em GRUPO na plataforma" : "Respondendo COTAÇÃO INDIVIDUAL na plataforma";
            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            return View("~/Views/SearchPrice/ReplyQuote.cshtml", model);
        }

        /// <summary>
        /// Inserir Resposta / Editar Resposta da Cotação
        /// </summary>
        /// <param name="form">Formulário da View</param>
        /// <param name="oqeq">Valor correspondente ao que vai ser exibido - Obs: pouco utilizado</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ReplyQuoteUpdate(FormCollection form, int? oqeq)
        {
            var userIdCurrent = User.Identity.GetUserId();
            var empresaUser = CacheHelper.EmpresaUsuario.Where(x => (x.Id == userIdCurrent)).FirstOrDefault();
            var fornecedorCotacao = CacheHelper.FornecedoresCotacao.Where(f => (f.Id_Empresa == empresaUser.Id_Empresa) && (f.id_CotacaoMaster == Convert.ToInt32(form.Get("idSearch")))).FirstOrDefault();
            bool updateCount = false;
            int operation = 0;
            int idRespCotacao = 0;
            //TipoCotacao; 1 - Cotação Master - 2 - Cotação Individual

            if (Convert.ToInt32(form.Get("idItemResp")) == 0)
            {
                //INSERIR RESPOSTA DA COTAÇÃO
                updateCount = true;
                var respostaFornecedorACotacao = new Resposta_FornecedoresCotacao()
                {
                    Id_ItemCotacao = Convert.ToInt32(form.Get("idIC")),
                    Id_FornecedoresCotacao = fornecedorCotacao.Id_FornecedoresCotacao,
                    Id_UsuarioRespondeu = userIdCurrent,
                    Data_Resposta = DateTime.Now,
                    Quantidade_ItemCotado = Convert.ToDecimal(Regex.Replace(form.Get("inQuantTotalAtend"), "[.]", "").Replace(",", ".")),
                    ValorUnitario_Resposta = Convert.ToDecimal(Regex.Replace(form.Get("inValor"), "[.]", "").Replace(",", ".")),
                    id_TipoFrete = Convert.ToInt32(form.Get("TipoFrete")),
                    FormaPagamento_Resposta = ""
                };
                _respostaFornecedoresCotacaoService.Insert(respostaFornecedorACotacao);
                await _unitOfWorkAsync.SaveChangesAsync();

                idRespCotacao = respostaFornecedorACotacao.Id_Resposta_FornecedoresCotacao;

                // OBS: DISPARAR E-MAIL E SMS AO(s) COMPRADORES INFORMANDO SOBRE QUE A COTAÇÃO FOI RESPONDIDA... 
            }
            else
            {
                //EDITAR RESPOSTA do ITEM da COTACAO
                if (await NotMeRespostaCotacao(Convert.ToInt32(form.Get("idItemResp"))))
                    return new HttpUnauthorizedResult();

                //EDITAR RESPOSTA da COTAÇÃO
                var respostaCotacaoMasterExisting = await _respostaFornecedoresCotacaoService.FindAsync(Convert.ToInt32(form.Get("idItemResp")));
                respostaCotacaoMasterExisting.Id_UsuarioRespondeu = userIdCurrent;
                respostaCotacaoMasterExisting.Data_Resposta = DateTime.Now;
                respostaCotacaoMasterExisting.Quantidade_ItemCotado = Convert.ToDecimal(Regex.Replace(form.Get("inQuantTotalAtend"), "[.]", "").Replace(",", "."));
                respostaCotacaoMasterExisting.ValorUnitario_Resposta = Convert.ToDecimal(Regex.Replace(form.Get("inValor"), "[.]", "").Replace(",", "."));
                respostaCotacaoMasterExisting.id_TipoFrete = Convert.ToInt32(form.Get("TipoFrete"));
                respostaCotacaoMasterExisting.FormaPagamento_Resposta = "";

                _respostaFornecedoresCotacaoService.Update(respostaCotacaoMasterExisting);

                await _unitOfWorkAsync.SaveChangesAsync();
                idRespCotacao = respostaCotacaoMasterExisting.Id_Resposta_FornecedoresCotacao;
                operation = 1;

                // OBS: DISPARAR E-MAIL E SMS AO(s) COMPRADORES INFORMANDO SOBRE QUE A COTAÇÃO RESPONDIDA SOFREU ALTERAÇÕES... 
            }

            // Update statistics count
            if (updateCount)
            {
                _dataCacheService.RemoveCachedItem(CacheKeys.Statistics);
            }

            ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;

            TempData[TempDataKeys.UserMessage] = (operation == 0) ? "[[[COTAÇÃO RESPONDIDA com Sucesso!]]]" : "[[[RESPOSTA da COTAÇÃO alterada com Sucesso!]]]";
            return RedirectToAction("ReplyQuoteUpdate", new { 
                id = fornecedorCotacao.id_CotacaoMaster, userId_ = userIdCurrent, oqeq = (oqeq >= 0) ? oqeq : 0, tpC = form.Get("inTipoCotacao"), iE = empresaUser.Id_Empresa 
            });
        }

        /// <summary>
        /// Dispara a cotação para os forncedores selecionados na View
        /// </summary>
        /// <param name="form">Campos do formulário contendo os checkboxes marcados</param>
        /// <param name="oqeq">Prametro de redirecionamento de tela</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendQuote(FormCollection form, int? oqeq)
        {
            var idsForn = form.Get("checkbox").Split(',');
            var listaEmpresasForn = CacheHelper.EmpresaUsuario.Where(e => (idsForn.Contains(e.Id_Empresa.ToString()))).ToList();
            foreach (var item in idsForn)
            {
                //VERIFICAR DISTRIBUIÇÃO PARA OPS FORNECEDORES (E-MAIL, SMS E WHATSAPP) <-- CONTINUAR AQUI...
            }

            return null;
        }

        /// <summary>
        /// Carregar o modelo da View
        /// </summary>
        /// <param name="cotacaoMaster">Obj. Cotacao Master - Independente de ser em GRUPO ou INDIVIDUAL</param>
        /// <param name="itensCotacao">Obj. Itens da Cotação</param>
        /// <param name="model">Obj. Modelo da View</param>
        /// <returns></returns>
        private async Task<SearchUpdateModel> PopulateReplyQuoteUpdateModel(Cotacao_Master cotacaoMaster, List<Itens_Cotacao> itensCotacao, Resposta_FornecedoresCotacao respostaCotacao, 
            SearchUpdateModel model)
        {
            model.idCotacao = cotacaoMaster.id_CotacaoMaster;
            model.areaAtuacao = cotacaoMaster.id_GrupoAtividades.ToString();
            model.inTipoCotacao = cotacaoMaster.TipoCotacao;
            model.EstadoUF = cotacaoMaster.id_UF_Cotacao.ToString();
            model.CidadeUF = cotacaoMaster.id_Cidade_Cotacao.ToString();
            model.Latitude = cotacaoMaster.Latitude;
            model.Longitude = cotacaoMaster.Longitude;
            model.DataEncerramento = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Encerramento_CotacaoMaster);
            model.DataCadastro = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Cadastro_CotacaoMaster);
            model.id_ItemCotacao = itensCotacao[0].Id_ItemCotacao;
            model.ProdutoCotado = itensCotacao[0].Descricao_ItemCotacao;
            model.UnidadeProduto = itensCotacao[0].UnidadeProduto;
            //model.QuantidadeTotalCompra = itensCotacao[0].Quantidade_ItemCotacao.ToString("N2");
            model.ObservacoesRelevantes = cotacaoMaster.ObservacoesRelevantes;
            model.idRespostaCotacao = (respostaCotacao != null) ? respostaCotacao.Id_Resposta_FornecedoresCotacao : 0;
            model.QuantidadeTotalCompra = itensCotacao.Where(i => (i.id_CotacaoMaster == cotacaoMaster.id_CotacaoMaster)).Select(i => (i.Quantidade_ItemCotacao)).Sum().ToString("N2");
            model.QuantidadeAtendida = (respostaCotacao != null) ? respostaCotacao.Quantidade_ItemCotado.ToString("N2") : "";
            model.ValorCotado = (respostaCotacao != null) ? respostaCotacao.ValorUnitario_Resposta.ToString("N2") : "";
            model.id_TipoFrete = (respostaCotacao != null) ? respostaCotacao.id_TipoFrete : 0;

            return model;
        }

        /// <summary>
        /// Carregar o modelo da View
        /// </summary>
        /// <param name="cotacaoMaster">Obj. Cotacao Master - Independente de ser em GRUPO ou INDIVIDUAL</param>
        /// <param name="itensCotacao">Obj. Itens da Cotação</param>
        /// <param name="model">Obj. Modelo da View</param>
        /// <returns></returns>
        private async Task<SearchUpdateModel> PopulateSearchPInIndividualUpdateModel(Cotacao_Master cotacaoMaster, List<Itens_Cotacao> itensCotacao, SearchUpdateModel model)
        {
            model.idCotacao = cotacaoMaster.id_CotacaoMaster;
            model.areaAtuacao = cotacaoMaster.id_GrupoAtividades.ToString();
            model.inTipoCotacao = cotacaoMaster.TipoCotacao;
            model.EstadoUF = cotacaoMaster.id_UF_Cotacao.ToString();
            model.CidadeUF = cotacaoMaster.id_Cidade_Cotacao.ToString();
            model.Latitude = cotacaoMaster.Latitude;
            model.Longitude = cotacaoMaster.Longitude;
            model.DataEncerramento = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Encerramento_CotacaoMaster);
            model.DataCadastro = String.Format("{0:dd/MM/yyyy}", cotacaoMaster.Data_Cadastro_CotacaoMaster);
            model.id_ItemCotacao = itensCotacao[0].Id_ItemCotacao;
            model.ProdutoCotado = itensCotacao[0].Descricao_ItemCotacao;
            model.UnidadeProduto = itensCotacao[0].UnidadeProduto;
            model.QuantidadeTotalCompra = itensCotacao[0].Quantidade_ItemCotacao.ToString("N2");
            model.ObservacoesRelevantes = cotacaoMaster.ObservacoesRelevantes;

            return model;
        }

        /// <summary>
        /// Pesquisar um Fornecedor Específico
        /// </summary>
        /// <param name="searchText">Texto a ser pesquisado</param>
        /// <param name="oqeq">Parametro com valor a ser transportado</param>
        /// <returns></returns>
        public async Task<ActionResult> SearchSupplier(string searchText, int? oqeq)
        {
            ////var userId = User.Identity.GetUserId();

            //////Verifica se é Emnpresa que está se logando
            ////var empresaUser = CacheHelper.EmpresaUsuario.Where(x => (x.Id == userId)).FirstOrDefault();

            ////var guposativ = await _gruposAtividadesService.Query(g => g.id_GrupoAtividades > 0).SelectAsync();
            ////var cidades = await _cidadesService.Query(c => c.ID > 0).SelectAsync();
            ////var estados = await _estadosService.Query(e => e.ID > 0).SelectAsync();
            ////var itemsEnviados = await _cotacaoMasterService.Query(x => x.Id_UsuarioCriou == userId).SelectAsync();
            ////var itensRecebidos = (empresaUser != null) ? await _fornecedoresCotacaoService.Query(f => f.Id_Empresa == empresaUser.Id_Empresa).Include(x => x.cotacaomaster).SelectAsync() : null;
            ////var cotacoesEnviadasModel = new List<ListingCotacoesEnviadasModel>();
            ////var cotacoesRecebidas = new List<ListingCotacoesRecebidasModel>();

            ////if (empresaUser != null)
            ////{
            //    // Filter string Recebidas
            //    if (!string.IsNullOrEmpty(searchText))  // CONTINUAR AQUI <== ADEQUAR AS BUSCAS A FORNECEDORES (VER BUSCA INDIVIDUAL E SUGERIDAS DA REGIÃO)
            //        itensRecebidos = itensRecebidos.Where(x => x.id_CotacaoMaster == Convert.ToInt32(searchText));

            //    foreach (var item in itensRecebidos.OrderByDescending(x => x.Data_Recebimento))
            //    {
            //        var gi = guposativ.FirstOrDefault(g => g.id_GrupoAtividades == item.cotacaomaster.id_GrupoAtividades);
            //        var cid = cidades.FirstOrDefault(c => c.ID == item.cotacaomaster.id_Cidade_Cotacao);
            //        var uf = estados.FirstOrDefault(e => e.ID == item.cotacaomaster.id_UF_Cotacao);

            //        cotacoesRecebidas.Add(new ListingCotacoesRecebidasModel()
            //        {
            //            idCM = item.id_CotacaoMaster,
            //            identificadorCM = ZerosAEsquerda(item.id_CotacaoMaster.ToString()),
            //            grupoAtividadade = gi.Descricao_Atividades,
            //            tipoCotacao = (item.cotacaomaster.TipoCotacao == 1) ? "Em Grupo" : "Individual",
            //            tpCotacao = item.cotacaomaster.TipoCotacao,
            //            regiaoCotacao = cid.NOME + "-" + uf.SIGLA,
            //            cadastradoEm = String.Format("{0:dd/MM/yyyy}", item.cotacaomaster.Data_Cadastro_CotacaoMaster),
            //            idEmpresaReccebeu = empresaUser.Id_Empresa,
            //            EncerraEm = String.Format("{0:dd/MM/yyyy}", item.cotacaomaster.Data_Encerramento_CotacaoMaster),
            //            ativadaDesativada = (item.cotacaomaster.Ativa_CotacaoMaster) ? "SIM" : "NÃO"
            //        });
            //    }
            ////}
            ////else
            ////{
            ////    // Filter string Enviadas
            ////    if (!string.IsNullOrEmpty(searchText))
            ////        itemsEnviados = itemsEnviados.Where(x => x.id_CotacaoMaster == Convert.ToInt32(searchText));

            ////    foreach (var item in itemsEnviados.OrderByDescending(x => x.Data_Cadastro_CotacaoMaster))
            ////    {
            ////        var gi = guposativ.FirstOrDefault(g => g.id_GrupoAtividades == item.id_GrupoAtividades);
            ////        var cid = cidades.FirstOrDefault(c => c.ID == item.id_Cidade_Cotacao);
            ////        var uf = estados.FirstOrDefault(e => e.ID == item.id_UF_Cotacao);

            ////        cotacoesEnviadasModel.Add(new ListingCotacoesEnviadasModel()
            ////        {
            ////            idCM = item.id_CotacaoMaster,
            ////            identificadorCM = ZerosAEsquerda(item.id_CotacaoMaster.ToString()),
            ////            grupoAtividadade = gi.Descricao_Atividades,
            ////            tipoCotacao = (item.TipoCotacao == 1) ? "Em Grupo" : "Individual",
            ////            tpCotacao = item.TipoCotacao,
            ////            regiaoCotacao = cid.NOME + "-" + uf.SIGLA,
            ////            cadastradoEm = String.Format("{0:dd/MM/yyyy}", item.Data_Cadastro_CotacaoMaster),
            ////            EncerraEm = String.Format("{0:dd/MM/yyyy}", item.Data_Encerramento_CotacaoMaster),
            ////            ativadaDesativada = (item.Ativa_CotacaoMaster) ? "SIM" : "NÃO"
            ////        });
            ////    }
            ////}

            //var model = new ListingCotacaoesModel()
            //{
            //    ListaCotacoesEnviadas = cotacoesEnviadasModel,
            //    ListaCotacoesRecebidas = cotacoesRecebidas
            //};


            //ViewBag.oqeq = (oqeq >= 0) ? oqeq : 0;
            //ViewBag.EhEmpresa = (empresaUser != null) ? true : false;

            //return View(model);

            return null;
        }

        /// <summary>
        /// Excluir COTAÇÕES
        /// </summary>
        /// <param name="id">Id da Cotação</param>
        /// <param name="txt">Texto de justificativa da exclusão da Cotação</param>
        /// <param name="tp">Tipo de Exclusão (0 - Cotação em Andamento / 1 - Cotação ainda não enviada a Fornecedores)</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SearchPriceDelete(int id, string txt, int tp)
        {
            if (tp == 0)
            {
                //Setar a Cotação como EXCLUÍDA ou CANCELADA
                var cotacaoMasterASerExcluida = await _cotacaoMasterService.FindAsync(id);
                cotacaoMasterASerExcluida.Cancelada = true;
                cotacaoMasterASerExcluida.MotivoCancelamento = (txt != "") ? txt : "Não foi infomado."; ;
                cotacaoMasterASerExcluida.Id_UsuarioExcluiu = User.Identity.GetUserId();

                _cotacaoMasterService.Update(cotacaoMasterASerExcluida);
                await _unitOfWorkAsync.SaveChangesAsync();

                // OBS: DISPARAR E-MAIL E SMS AO(s) FORNCEDORES E COMPRADORES ADJUNTOS, INFORMANDO SOBRE QUE A COTAÇÃO EXCLUÍDA / CANCELADA E O MOTIVO... 
            }
            else
            {
                //Excluir Itens da Cotação
                var itensCotacao = CacheHelper.ItensCotacao.Where(i => i.id_CotacaoMaster == id).ToList();
                foreach (var item in itensCotacao)
                {
                    await _itensCotacaoService.DeleteAsync(item.Id_ItemCotacao);
                    await _unitOfWorkAsync.SaveChangesAsync();
                }

                //Excluir Cotação Master
                var cotacaoMaster = await _cotacaoMasterService.FindAsync(id);
                await _cotacaoMasterService.DeleteAsync(id);
                await _unitOfWorkAsync.SaveChangesAsync();
            }

            var result = new { Success = true, Message = "[[[A COTAÇÃO Nº " + ZerosAEsquerda(id.ToString()) + " foi excluída]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Seta uma flag na tabela FornecedoresCotacao, desistindo de responder a mesma
        /// </summary>
        /// <param name="id">Id da Cotação Master</param>
        /// <param name="idCR">Id da Cotação recebida por este Fornecedor</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DoNotAnswerQuotation(int id, int idCR)
        {
            // OBS: SE TIVER RESPOSTA REGISTRADA PRA ESSE FORNECEDOR, REMOVER A RESPOSTA... CONTINUAR AQUI... <== 

            var cotacaoASerRecusada = await _fornecedoresCotacaoService.FindAsync(idCR);
            cotacaoASerRecusada.NaoVaiResponder = true;
            cotacaoASerRecusada.Id_UsuarioRecusou = User.Identity.GetUserId();

            _fornecedoresCotacaoService.Update(cotacaoASerRecusada);
            await _unitOfWorkAsync.SaveChangesAsync();

            var result = new { Success = true, Message = "[[[A COTAÇÃO Nº " + ZerosAEsquerda(id.ToString()) + " foi recusada!]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cancelar a paarticipação do Usuário logado em uma Cotação em Grupo
        /// </summary>
        /// <param name="id">Id da Cotação Master</param>
        /// <returns></returns>
        public async Task<ActionResult> CancelParticipationGroupQuot(int id)
        {
            var userIdCurrent = User.Identity.GetUserId();
            var itemParticipacaoNaCotacao = CacheHelper.ItensCotacao.FirstOrDefault(i => ((i.id_CotacaoMaster == id) && (i.Id_UsuarioCriou == userIdCurrent)));
            
            //Excluir o Item da Cotação
            if (itemParticipacaoNaCotacao != null)
            {
                await _itensCotacaoService.DeleteAsync(itemParticipacaoNaCotacao.Id_ItemCotacao);
                await _unitOfWorkAsync.SaveChangesAsync();
            }

            var result = new { Success = true, Message = "[[[Sua participação na COTAÇÃO Nº " + ZerosAEsquerda(id.ToString()) + " foi cancelada]]]" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Solução provisória pra se apurar o menor valor respondido para uma cotação em grupo
        /// </summary>
        /// <param name="listaRespostas">Lista das respostas conforme parametros aceitáveis</param>
        /// <param name="quantidadeTotalCompra">Quantidade total cotado</param>
        /// <returns></returns>
        public int FornecedorComMenorPrecoRespondido(List<Resposta_FornecedoresCotacao> listaRespostas, decimal quantidadeTotalCompra)
        {
            var menorValor = listaRespostas.Where(f => ((f.Quantidade_ItemCotado == quantidadeTotalCompra) && (f.ValorUnitario_Resposta > 0))).Select(f => f.ValorUnitario_Resposta).Min();
            var resposta = listaRespostas.FirstOrDefault(r => (r.ValorUnitario_Resposta == menorValor));
            return resposta.Id_FornecedoresCotacao;
        }

        /// <summary>
        /// Preenche string com zeros a esquerda
        /// </summary>
        /// <param name="valor">Valor a ser tratado</param>
        /// <returns></returns>
        public string ZerosAEsquerda(string valor)
        {
            var tamanho = valor.ToString().Length;
            var difTamanho = (6 - tamanho);
            var valorFormatado = valor.ToString();

            for (int g = 0; g < difTamanho; g++)
            {
                valorFormatado = ("0" + valorFormatado);
            }
            return valorFormatado;
        }
    }
}