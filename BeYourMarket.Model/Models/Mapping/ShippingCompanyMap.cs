using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class ShippingCompanyMap : EntityTypeConfiguration<ShippingCompany>
    {
        public ShippingCompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_SC);

            // Properties
            this.Property(t => t.Nome_Fantasia_SC)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ShippingCompany");
            this.Property(t => t.Id_SC).HasColumnName("Id_SC");
            this.Property(t => t.Nome_Fantasia_SC).HasColumnName("Nome_Fantasia_SC");
            this.Property(t => t.Razao_Social_SC).HasColumnName("Razao_Social_SC");
            this.Property(t => t.Cnpj_SC).HasColumnName("Cnpj_SC");
            this.Property(t => t.Logradouro_Cidade_SC).HasColumnName("Logradouro_Cidade_SC");
            this.Property(t => t.Bairro_Cidade_SC).HasColumnName("Bairro_Cidade_SC");
            this.Property(t => t.Cep_Bairro_Cidade_SC).HasColumnName("Cep_Bairro_Cidade_SC");
            this.Property(t => t.id_Cidade_SC).HasColumnName("id_Cidade_SC");
            this.Property(t => t.id_UF_SC).HasColumnName("id_UF_SC");
            this.Property(t => t.RNTRC_SC).HasColumnName("RNTRC_SC");
            this.Property(t => t.Frota_Propria_SC).HasColumnName("Frota_Propria_SC");
            this.Property(t => t.Vencimento_RNTRC_SC).HasColumnName("Vencimento_RNTRC_SC");
            this.Property(t => t.Possui_Seguro_Carga_SC).HasColumnName("Possui_Seguro_Carga_SC");
            this.Property(t => t.Possui_Seguro_Vitimas_SC).HasColumnName("Possui_Seguro_Vitimas_SC");
            this.Property(t => t.Habilitado_View_Plataforma_SC).HasColumnName("Habilitado_View_Plataforma_SC");
        }
    }
}
