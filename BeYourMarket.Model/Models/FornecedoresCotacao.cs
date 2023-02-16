using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class FornecedoresCotacao : Repository.Pattern.Ef6.Entity
    {
        public int Id_FornecedoresCotacao { get; set; }
        public int Id_Empresa { get; set; }
        public int id_CotacaoMaster { get; set; }
        public bool RespondeuCotacao { get; set; }
        public bool VenceuCotacao { get; set; }
        public DateTime Data_Recebimento { get; set; }
        public bool NaoVaiResponder { get; set; }
        public string Id_UsuarioRecusou { get; set; }

        [ForeignKey("Id_Empresa")]
        public virtual EmpresaUsuario empresausuario { get; set; }
        [ForeignKey("id_CotacaoMaster")]
        public virtual Cotacao_Master cotacaomaster { get; set; }
    }
}
