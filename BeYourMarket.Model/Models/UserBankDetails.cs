using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class UserBankDetails : Repository.Pattern.Ef6.Entity
    {
		public int Id_UBankDetails { get; set; }
        public string Id_User_UBankDetails { get; set; }
        public int id_TipoConta { get; set; }
        public int id_TipoChavePix { get; set; }
        public int id_Bank { get; set; }
        public string Cod_Agencia { get; set; }
        public string Cod_Conta { get; set; }
        public string Cod_Dig_Conta { get; set; }
        public string Chave_Pix_Conta { get; set; }
        public DateTime Data_Cadastro_UBankDetails { get; set; }

        //[ForeignKey("Id_User_UBankDetails")]
        //public virtual AspNetUser Usuario { get; set; }
        //[ForeignKey("id_TipoConta")]
        //public virtual TiposContaBancaria TiposContaBancaria { get; set; }
        //[ForeignKey("id_TipoChavePix")]
        //public virtual TiposChavePix TiposChavePix { get; set; }
    }
}
