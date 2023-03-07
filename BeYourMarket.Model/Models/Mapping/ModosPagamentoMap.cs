using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class ModosPagamentoMap : EntityTypeConfiguration<ModosPagamento>
    {
        public ModosPagamentoMap()
        {
            this.HasKey(t => t.Id_ModosPag);

            // Properties
            this.Property(t => t.Id_ModosPag)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ModosPagamento");
            this.Property(t => t.Id_ModosPag).HasColumnName("Id_ModosPag");
            this.Property(t => t.Descricao_ModosPag).HasColumnName("Descricao_ModosPag");
        }
    }
}
