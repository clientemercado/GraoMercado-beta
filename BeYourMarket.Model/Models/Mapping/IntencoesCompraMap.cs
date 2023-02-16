using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class IntencoesCompraMap : EntityTypeConfiguration<IntencoesCompra>
    {
            public IntencoesCompraMap()
            {
                // Primary Key
                this.HasKey(t => t.id_IC);

                // Properties
                this.Property(t => t.id_IC)
                    .IsRequired();

                // Table & Column Mappings
                this.ToTable("IntencoesCompra");
                this.Property(t => t.id_IC).HasColumnName("id_IC");
                this.Property(t => t.DescricaoProduto).HasColumnName("DescricaoProduto");
            }
    }
}
