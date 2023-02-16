using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class InsurersMap : EntityTypeConfiguration<Insurers>
    {
        public InsurersMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Insurer);

            // Properties
            this.Property(t => t.Nome_Insurer)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Insurers");
            this.Property(t => t.id_Insurer).HasColumnName("id_Insurer");
            this.Property(t => t.Nome_Insurer).HasColumnName("Nome_Insurer");
        }
    }
}
