using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class Resposta_FornecedoresCotacao : Repository.Pattern.Ef6.Entity
    {
		public int Id_Resposta_FornecedoresCotacao { get; set; }
		//public int Id_Empresa_Resposta { get; set; }
		public int Id_ItemCotacao { get; set; }
		public int Id_FornecedoresCotacao { get; set; }
		public string Id_UsuarioRespondeu { get; set; }
		public DateTime Data_Resposta { get; set; }
		public decimal Quantidade_ItemCotado { get; set; }
		public decimal ValorUnitario_Resposta { get; set; }
		public int id_TipoFrete { get; set; }
		public string FormaPagamento_Resposta { get; set; }
		public bool Resposta_Vencedora { get; set; }
		public string Observacao_Resposta { get; set; }

		[ForeignKey("Id_ItemCotacao")]
		public virtual Itens_Cotacao Itens_cotacao { get; set; }
		[ForeignKey("id_TipoFrete")]
		public virtual TiposFrete TiposFrete { get; set; }
		[ForeignKey("Id_UsuarioRespondeu")]
		public virtual AspNetUser aspnetuser { get; set; }
	}
}
