using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class FormasPagamentoMap : EntityTypeConfiguration<FormasPagamento>
    {
        public FormasPagamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_FormaPgto);

            // Properties
            this.Property(t => t.Descricao_FormaPgto)
                .IsRequired()
                .HasMaxLength(100); ;

            // Table & Column Mappings
            this.ToTable("FormasPagamento");
            this.Property(t => t.id_FormaPgto).HasColumnName("id_FormaPgto");
            this.Property(t => t.Descricao_FormaPgto).HasColumnName("Descricao_FormaPgto");
        }
    }
}
