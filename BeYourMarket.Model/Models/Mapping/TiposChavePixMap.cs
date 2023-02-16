using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TiposChavePixMap : EntityTypeConfiguration<TiposChavePix>
    {
        public TiposChavePixMap()
        {
            this.HasKey(t => t.id_TipoChavePix);

            // Properties
            this.Property(t => t.Descricao_TipoChavePix)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TiposChavePix");
            this.Property(t => t.id_TipoChavePix).HasColumnName("id_TipoChavePix");
            this.Property(t => t.Descricao_TipoChavePix).HasColumnName("Descricao_TipoChavePix");
        }
    }
}
