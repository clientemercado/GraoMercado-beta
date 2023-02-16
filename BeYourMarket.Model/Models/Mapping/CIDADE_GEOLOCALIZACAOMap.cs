using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class CIDADE_GEOLOCALIZACAOMap : EntityTypeConfiguration<CIDADE_GEOLOCALIZACAO>
    {
        public CIDADE_GEOLOCALIZACAOMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FK_CIDADE)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("CIDADE_GEOLOCALIZACAO");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FK_CIDADE).HasColumnName("FK_CIDADE");
            this.Property(t => t.GEOLOCALIZACAO).HasColumnName("GEOLOCALIZACAO");
            this.Property(t => t.Data_Cadastro).HasColumnName("Data_Cadastro");
        }
    }
}
