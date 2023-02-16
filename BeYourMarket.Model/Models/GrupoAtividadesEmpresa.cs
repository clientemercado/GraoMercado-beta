using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class GrupoAtividadesEmpresa : Repository.Pattern.Ef6.Entity
    {
        public int id_GrupoAtividades { get; set; }
        public string Descricao_Atividades { get; set; }
        public DateTime Data_Cadastro_GrupoAtividades { get; set; }
    }
}
