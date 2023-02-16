using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TiposContaBancariaMap : EntityTypeConfiguration<TiposContaBancaria>
    {
        public TiposContaBancariaMap()
        {
            this.HasKey(t => t.id_TipoConta);

            // Properties
            this.Property(t => t.Descricao_TipoConta)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TiposContaBancaria");
            this.Property(t => t.id_TipoConta).HasColumnName("id_TipoConta");
            this.Property(t => t.Descricao_TipoConta).HasColumnName("Descricao_TipoConta");
        }
    }
}
