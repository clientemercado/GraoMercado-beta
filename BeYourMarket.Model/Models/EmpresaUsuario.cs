using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class EmpresaUsuario : Repository.Pattern.Ef6.Entity
    {
        public int Id_Empresa { get; set; }
        public string Id { get; set; }
        public int id_GrupoAtividades { get; set; }
        public string Cnpj_Empresa { get; set; }
        public string Razao_Social_Empresa { get; set; }
        public string Fantasia_Empresa { get; set; }
        public string Logo_Empresa { get; set; }
        public string Logradouro_Empresa { get; set; }
        public string Complemento_Endereco_Empresa { get; set; }
        public string Bairro_Empresa { get; set; }
        public string Cidade_Empresa { get; set; }
        public string UF_Empresa { get; set; }
        public string Cep_Endereco_Empresa { get; set; }
        public string Fone1_Empresa { get; set; }
        public string Fone2_Empresa { get; set; }
        public string Email1_Empresa { get; set; }
        public string Email2_Empresa { get; set; }
        public bool Receber_Emails_Empresa { get; set; }
        public DateTime Data_Cadastro_Empresa { get; set; }

        //[ForeignKey("Id")]
        //public virtual AspNetUser aspnetuser { get; set; }
    }
}
