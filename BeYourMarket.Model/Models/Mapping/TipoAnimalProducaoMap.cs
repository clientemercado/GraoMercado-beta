using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TipoAnimalProducaoMap : EntityTypeConfiguration<TipoAnimalProducao>
    {
        public TipoAnimalProducaoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_AnimalProducao);

            // Properties
            this.Property(t => t.Descricao_TipoAnimalProducao)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TipoAnimalProducao");
            this.Property(t => t.id_AnimalProducao).HasColumnName("id_AnimalProducao");
            this.Property(t => t.Descricao_TipoAnimalProducao).HasColumnName("Descricao_TipoAnimalProducao");
        }
    }
}
