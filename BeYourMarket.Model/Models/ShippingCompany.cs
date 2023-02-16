using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class ShippingCompany : Repository.Pattern.Ef6.Entity
    {
        public int Id_SC { get; set; }
        public string Nome_Fantasia_SC { get; set; }
        public string Razao_Social_SC { get; set; }
        public string Cnpj_SC { get; set; }
        public string Logradouro_Cidade_SC { get; set; }
        public string Bairro_Cidade_SC { get; set; }
        public string Cep_Bairro_Cidade_SC { get;set; }
        public int? id_Cidade_SC { get; set; }
        public int? id_UF_SC { get; set; }
        public string RNTRC_SC { get; set; }
        public bool? Frota_Propria_SC { get; set; }
        public DateTime? Vencimento_RNTRC_SC { get; set; }
        public bool? Possui_Seguro_Carga_SC { get; set; }
        public bool? Possui_Seguro_Vitimas_SC { get; set; }
        public bool Habilitado_View_Plataforma_SC { get; set; }
    }
}
