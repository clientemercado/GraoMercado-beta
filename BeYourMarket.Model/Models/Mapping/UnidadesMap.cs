using System.Data.Entity.ModelConfiguration;

namespace BeYourMarket.Model.Models.Mapping
{
    public class UnidadesMap : EntityTypeConfiguration<Unidades>
    {
        public UnidadesMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Unidade);

            // Properties
            this.Property(t => t.descricaoUnidade)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Unidades");
            this.Property(t => t.id_Unidade).HasColumnName("id_Unidade");
            this.Property(t => t.descricaoUnidade).HasColumnName("descricaoUnidade");
        }
    }
}
