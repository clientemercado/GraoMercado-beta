using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TipoAnimalPecuariaMap : EntityTypeConfiguration<TipoAnimalPecuaria>
    {
        public TipoAnimalPecuariaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_AnimalPecuaria);

            // Properties
            this.Property(t => t.id_AnimalPecuaria)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TipoAnimalPecuaria");
            this.Property(t => t.id_AnimalPecuaria).HasColumnName("id_AnimalPecuaria");
            this.Property(t => t.Descricao_TipoAnimal).HasColumnName("Descricao_TipoAnimal");
        }
    }
}
