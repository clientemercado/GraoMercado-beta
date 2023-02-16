using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class CIDADEMap : EntityTypeConfiguration<CIDADE>
    {
        public CIDADEMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.NOME)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CIDADE");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NOME).HasColumnName("NOME");
            this.Property(t => t.CODIGO_IBGE).HasColumnName("CODIGO_IBGE");
            this.Property(t => t.FK_ESTADO).HasColumnName("FK_ESTADO");
            this.Property(t => t.Data_Cadastro).HasColumnName("Data_Cadastro");
        }
    }
}
