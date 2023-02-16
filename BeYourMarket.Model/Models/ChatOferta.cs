using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class ChatOferta : Repository.Pattern.Ef6.Entity
    {
        public int id_ChatOferta { get; set; }
        public int id_Oferta { get; set; }
        public string id_Usuario_Perguntou { get; set; }
        public string id_Usuario_Respondeu { get; set; }
        public DateTime Data_Interacao_Chat { get; set; }
        public string Texto_Chat { get; set; }
        public bool Eh_Pergunta { get; set; }
        public bool Pergunta_Respondida { get; set; }
        public int Id_Pergunta { get; set; }
        public int Ordem_Exibicao_ChatOferta { get; set; }
    }
}
