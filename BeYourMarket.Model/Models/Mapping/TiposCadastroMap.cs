using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class TiposCadastroMap : EntityTypeConfiguration<TiposCadastro>
    {
        public TiposCadastroMap()
        {
            // Primary Key
            this.HasKey(t => t.id_TipoCadastro);

            // Properties
            this.Property(t => t.Descricao_TipoCadastro)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("TiposCadastro");
            this.Property(t => t.id_TipoCadastro).HasColumnName("id_TipoCadastro");
            this.Property(t => t.Descricao_TipoCadastro).HasColumnName("Descricao_TipoCadastro");
            this.Property(t => t.DataCadastroTipoCad).HasColumnName("DataCadastroTipoCad");
        }
    }
}
