using BeYourMarket.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeYourMarket.Web.Models
{
    public class SettingsUpdateModel
    {
        //Dados do Perfil
        public string id_User { get; set; }
        public string primeiroNomeUsuario { get; set; }
        public string segundoNomeUsuario { get; set; }
        public string cpfUsuario { get; set; }
        public string Data_Nascimento { get; set; }
        public string emailUsuario { get; set; }
        public string dataNascimento { get; set; }
        public int? idEstadoUF { get; set; }
        public int? idCidadeUF { get; set; }
        public List<ESTADO> EstadosUF { get; set; }
        public List<CIDADE> CidadesUF { get; set; }
        public string inLogradouro { get; set; }
        public string inBairro { get; set; }
        public string inCep { get; set; }
        public string inTelefone1 { get; set; }
        public string inTelefone2 { get; set; }
        public string inComplemento { get; set; }
        //public List<SelectListItem> listaEstados { get; set; }
        //public List<SelectListItem> listaCidades { get; set; }

        //Dados Bancários
        public int id_CB { get; set; }
        public int id_Banco { get; set; }
        public List<Banks> BancosPais { get; set; }
        public string AgenciaBancaria { get; set; }
        public int id_TpConta { get; set; }
        public List<TiposContaBancaria> TpContaBancaria { get; set; }
        public string NumeroContaBancaria { get; set; }
        public string DigContaBancaria { get; set; }
        public List<TiposChavePix> TpChavesPix { get; set; }
        public int id_TpChavePix { get; set; }
        public string ChavePix { get; set; }

        //Dados Empresa
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpjEmpresa { get; set; }
    }
}