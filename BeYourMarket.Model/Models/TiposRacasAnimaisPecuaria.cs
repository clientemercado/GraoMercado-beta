using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TiposRacasAnimaisPecuaria : Repository.Pattern.Ef6.Entity
    {
        public int id_TipoRacasAnimais { get; set; }
        public int id_AnimalProducao { get; set; }
        public string Descricao_TipoRacaAnimais { get; set; }

        [ForeignKey("id_AnimalProducao")]
        public virtual TipoAnimalProducao TipoAnimalProducao { get; set; }
    }
}
