using BeYourMarket.Core;
using BeYourMarket.Model.Enum;
using BeYourMarket.Model.Models;
using BeYourMarket.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace BeYourMarket.Service
{
    public static class CacheHelper
    {
        public static Setting Settings
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Settings) as Setting;
            }
        }

        public static List<SettingDictionary> SettingDictionary
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.SettingDictionary) as List<SettingDictionary>;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Categories) as List<Category>;
            }
        }

        public static List<ListingType> ListingTypes
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.ListingTypes) as List<ListingType>;
            }
        }

        public static List<ContentPage> ContentPages
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.ContentPages) as List<ContentPage>;
            }
        }

        public static Statistics Statistics
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Statistics) as Statistics;
            }
        }

        public static string StripeConnectUrl
        {
            get
            {
                return string.Format("https://connect.stripe.com/oauth/authorize?response_type=code&amp;client_id={0}&amp;scope=read_write", GetSettingDictionary("StripeClientID").Value);
            }
        }

        public static List<Unidades> Unidades
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Unidades) as List<Unidades>;
            }
        }

        public static List<ModalidadesCompra> ModalidadesCompra
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.ModalidadesCompra) as List<ModalidadesCompra>;
            }
        }

        public static List<IntencoesCompra> IntencoesCompra
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.IntencoesCompra) as List<IntencoesCompra>;
            }
        }

        public static List<TiposFrete> TiposFrete
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposFrete) as List<TiposFrete>;
            }
        }

        public static List<FormasPagamento> FormasPagamento
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.FormasPagamento) as List<FormasPagamento>;
            }
        }

        public static List<TiposCadastro> TiposCadastro
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposCadastro) as List<TiposCadastro>;
            }
        }

        public static List<GrupoAtividadesEmpresa> GrupoAtividadesEmpresa
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.GrupoAtividadesEmpresa) as List<GrupoAtividadesEmpresa>;
            }
        }

        public static List<EmpresaUsuario> EmpresaUsuario
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.EmpresaUsuario) as List<EmpresaUsuario>;
            }
        }

        public static List<CIDADE> Cidade
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Cidade) as List<CIDADE>;
            }
        }

        public static List<CIDADE_GEOLOCALIZACAO> Cidade_Geo
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Cidade_Geo) as List<CIDADE_GEOLOCALIZACAO>;
            }
        }

        public static List<ESTADO> EstadoUf
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.EstadoUf) as List<ESTADO>;
            }
        }

        public static List<PAIS> Pais
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Pais) as List<PAIS>;
            }
        }

        public static List<Cotacao_Master> CotacaoMaster
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.CotacaoMaster) as List<Cotacao_Master>;
            }
        }

        public static List<Itens_Cotacao> ItensCotacao
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.ItensCotacao) as List<Itens_Cotacao>;
            }
        }

        public static List<FornecedoresCotacao> FornecedoresCotacao
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.FornecedoresCotacao) as List<FornecedoresCotacao>;
            }
        }

        public static List<Resposta_FornecedoresCotacao> RespostaFornecedoresCotacao
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.RespostaFornecedoresCotacao) as List<Resposta_FornecedoresCotacao>;
            }
        }

        public static List<AspNetUser> AspNetUsers
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.AspNetUsers) as List<AspNetUser>;
            }
        }

        public static List<TipoAnimalProducao> TiposAnimaisProducao
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposAnimaisProducao) as List<TipoAnimalProducao>;
            }
        }

        public static List<TipoAnimalPecuaria> TiposAnimalPecuaria
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TipoAnimalPecuaria) as List<TipoAnimalPecuaria>;
            }
        }

        public static List<TiposRacasAnimaisPecuaria> TiposRacasAnimaisPecuaria
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposRacasAnimaisPecuaria) as List<TiposRacasAnimaisPecuaria>;
            }
        }

        public static List<Banks> Banks
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Banks) as List<Banks>;
            }
        }

        public static List<TiposContaBancaria> TiposContaBancaria
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposContaBancaria) as List<TiposContaBancaria>;
            }
        }

        public static List<UserBankDetails> UserBankDetails
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.UserBankDetails) as List<UserBankDetails>;
            }
        }

        public static List<TiposChavePix> TiposChavePix
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.TiposChavePix) as List<TiposChavePix>;
            }
        }

        public static List<Insurers> Insurers
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.Insurers) as List<Insurers>;
            }
        }

        public static List<OperationType> OperationType
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<OperationType>;
            }
        }

        public static List<ChatOferta> ChatOferta
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<ChatOferta>;
            }
        }

        public static List<ShippingCompany> ShippingCompany
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<ShippingCompany>;
            }
        }

        public static List<MeiosDePagamento> MeiosDePagamento
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<MeiosDePagamento>;
            }
        }

        public static List<ModosPagamento> ModosPagamento
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<ModosPagamento>;
            }
        }

        public static List<CompraEfetuada> CompraEfetuada
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<CompraEfetuada>;
            }
        }

        public static List<VideosOferta> VideosOferta
        {
            get
            {
                return ContainerManager.GetConfiguredContainer().Resolve<BeYourMarket.Service.DataCacheService>().GetCachedItem(CacheKeys.OperationType) as List<VideosOferta>;
            }
        }

        public static SettingDictionary GetSettingDictionary(string settingKey)
        {
            var setting = SettingDictionary.Where(x => x.Name == settingKey).FirstOrDefault();

            if (setting == null)
                return new SettingDictionary()
                {
                    Name = settingKey.ToString(),
                    Value = string.Empty
                };

            return setting;
        }
    }
}
