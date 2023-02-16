using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TiposFreteMap : EntityTypeConfiguration<TiposFrete>
    {
        public TiposFreteMap()
        {
            // Primary Key
            this.HasKey(t => t.id_TipoFrete);

            // Properties
            this.Property(t => t.Descricao_TipoFrete)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("TiposFrete");
            this.Property(t => t.id_TipoFrete).HasColumnName("id_TipoFrete");
            this.Property(t => t.Descricao_TipoFrete).HasColumnName("Descricao_TipoFrete");
        }
    }
}
