using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class CompraEfetuadaMap : EntityTypeConfiguration<CompraEfetuada>
    {
        public CompraEfetuadaMap()
        {
            this.HasKey(t => t.Id_CompEfet);

            // Properties
            this.Property(t => t.Id_CompEfet)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CompraEfetuada");
            this.Property(t => t.Id_CompEfet).HasColumnName("Id_CompEfet");
            this.Property(t => t.Id_Oferta).HasColumnName("Id_Oferta");
            this.Property(t => t.Quant_CompEfet).HasColumnName("Quant_CompEfet");
            this.Property(t => t.ValorCompra_CompEfet).HasColumnName("ValorCompra_CompEfet");
            this.Property(t => t.MeiosPag_CompEfet).HasColumnName("MeiosPag_CompEfet");
            this.Property(t => t.ModoPag_CompEfet).HasColumnName("ModoPag_CompEfet");
        }
    }
}
