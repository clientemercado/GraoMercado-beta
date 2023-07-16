using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class VideosOferta : Repository.Pattern.Ef6.Entity
    {
        public int id_VideoOferta { get; set; }
        public int id_Oferta { get; set; }
        public string descricao_videoOferta { get; set; }
    }
}
