using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class Itens_Cotacao : Repository.Pattern.Ef6.Entity
    {
		public Itens_Cotacao()
		{
			this.resposta_fornecedores_cotacao = new List<Resposta_FornecedoresCotacao>();
		}

		public int Id_ItemCotacao { get; set; }
		public int id_CotacaoMaster { get; set; }
		public string Descricao_ItemCotacao { get; set; }
		public decimal Quantidade_ItemCotacao { get; set; }
		public string UnidadeProduto { get; set; }
		public string Id_UsuarioCriou { get; set; }

		[ForeignKey("id_CotacaoMaster")]
		public virtual Cotacao_Master cotacaomaster { get; set; }

		public virtual ICollection<Resposta_FornecedoresCotacao> resposta_fornecedores_cotacao { get; set; }
	}
}
