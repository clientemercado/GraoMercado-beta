using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class IntencoesCompra : Repository.Pattern.Ef6.Entity
    {
        public int id_IC { get; set; }
        //public string UserID { get; set; }
        public string Id { get; set; }
        public int id_TipoFrete { get; set; }
        public int id_ModalCompra { get; set; }
        public int CategoryID { get; set; }
        public int id_FormaPgto { get; set; }
        public string Location { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal QuantidadeTotalItensAComprar { get; set; }
        public decimal QuantidadeMinimaItensAComprar { get; set; }
        public string UnidadeProduto { get; set; }
        public decimal MnhaOfertaDePreco { get; set; }
        public System.DateTime DataCadastroOferta { get; set; }
        public System.DateTime? OfertaValidaAte { get; set; }
        public string ObservacoesRelevantes { get; set; }

        [ForeignKey("Id")]
        public virtual AspNetUser AspNetUser { get; set; }
        [ForeignKey("id_TipoFrete")]
        public virtual TiposFrete TiposFrete { get; set; }
        [ForeignKey("id_ModalCompra")]
        public virtual ModalidadesCompra ModalidadesCompra { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("id_FormaPgto")]
        public virtual FormasPagamento FormasPagamento { get; set; }
    }
}
