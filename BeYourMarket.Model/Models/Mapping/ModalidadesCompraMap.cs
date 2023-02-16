using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class ModalidadesCompraMap : EntityTypeConfiguration<ModalidadesCompra>
    {
        public ModalidadesCompraMap()
        {
            // Primary Key
            this.HasKey(t => t.id_ModalCompra);

            // Properties
            this.Property(t => t.Descricao_ModalCompra)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ModalidadesCompra");
            this.Property(t => t.id_ModalCompra).HasColumnName("id_ModalCompra");
            this.Property(t => t.Descricao_ModalCompra).HasColumnName("Descricao_ModalCompra");
        }
    }
}
