using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TiposRacasAnimaisPecuariaMap : EntityTypeConfiguration<TiposRacasAnimaisPecuaria>
    {
        public TiposRacasAnimaisPecuariaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_TipoRacasAnimais);

            // Properties
            this.Property(t => t.id_TipoRacasAnimais)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TiposRacasAnimaisPecuaria");
            this.Property(t => t.id_TipoRacasAnimais).HasColumnName("id_TipoRacasAnimais");
            this.Property(t => t.id_AnimalProducao).HasColumnName("id_AnimalProducao");
            this.Property(t => t.Descricao_TipoRacaAnimais).HasColumnName("Descricao_TipoRacaAnimais");
        }
    }
}
