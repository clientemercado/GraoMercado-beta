using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models
{
    public partial class TipoAnimalPecuaria : Repository.Pattern.Ef6.Entity
    {
        public int id_AnimalPecuaria { get; set; }
        public string Descricao_TipoAnimal { get; set; }
    }
}
