using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class ESTADOMap : EntityTypeConfiguration<ESTADO>
    {
        public ESTADOMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.NOME)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ESTADO");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NOME).HasColumnName("NOME");
            this.Property(t => t.CODIGO).HasColumnName("CODIGO");
            this.Property(t => t.SIGLA).HasColumnName("SIGLA");
            this.Property(t => t.FK_PAIS).HasColumnName("FK_PAIS");
            this.Property(t => t.Data_Cadastro).HasColumnName("Data_Cadastro");
        }
    }
}
