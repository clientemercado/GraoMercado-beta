using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class MeiosDePagamentoMap : EntityTypeConfiguration<MeiosDePagamento>
    {
        public MeiosDePagamentoMap()
        {
            this.HasKey(t => t.Id_MeiosPag);

            // Properties
            this.Property(t => t.Id_MeiosPag)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MeiosDePagamento");
            this.Property(t => t.Id_MeiosPag).HasColumnName("Id_MeiosPag");
            this.Property(t => t.Descricao_MeiosPag).HasColumnName("Descricao_MeiosPag");
        }
    }
}
