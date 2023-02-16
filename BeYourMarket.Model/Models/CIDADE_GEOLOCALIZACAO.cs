using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class CIDADE_GEOLOCALIZACAO : Repository.Pattern.Ef6.Entity
    {
        public int ID { get; set; }
        public int FK_CIDADE { get; set; }
        public DbGeometry GEOLOCALIZACAO { get; set; }
        public DateTime Data_Cadastro { get; set; }
    }
}
