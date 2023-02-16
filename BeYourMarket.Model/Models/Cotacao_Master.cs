using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class Cotacao_Master : Repository.Pattern.Ef6.Entity
    {
		public int id_CotacaoMaster { get; set; }
		public int id_GrupoAtividades { get; set; }
		public int TipoCotacao { get; set; }
		public int id_UF_Cotacao { get; set; }
		public int id_Cidade_Cotacao { get; set; }
		public Nullable<double> Latitude { get; set; }
		public Nullable<double> Longitude { get; set; }
		public bool Cotacao_Disparada { get; set; }
		public DateTime Data_Cadastro_CotacaoMaster { get; set; }
		public DateTime Data_Encerramento_CotacaoMaster { get; set; }
		public string ObservacoesRelevantes { get; set; }
		public string Id_UsuarioCriou { get; set; }
		public int Id_Empresa_Vencedora_CotacaoMaster { get; set; }
		public bool Ativa_CotacaoMaster { get; set; }
		public bool Cancelada { get; set; }
		public string MotivoCancelamento { get; set; }
		public string Id_UsuarioExcluiu { get; set; }

		[ForeignKey("id_GrupoAtividades")]
        public virtual GrupoAtividadesEmpresa gruposatividades { get; set; }
    }
}
