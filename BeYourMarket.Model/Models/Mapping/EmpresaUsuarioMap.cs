using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class EmpresaUsuarioMap : EntityTypeConfiguration<EmpresaUsuario>
    {
        public EmpresaUsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Empresa);

            // Properties
            this.Property(t => t.Fantasia_Empresa)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EmpresaUsuario");
            this.Property(t => t.Id_Empresa).HasColumnName("Id_Empresa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.id_GrupoAtividades).HasColumnName("id_GrupoAtividades");
            this.Property(t => t.Cnpj_Empresa).HasColumnName("Cnpj_Empresa");
            this.Property(t => t.Razao_Social_Empresa).HasColumnName("Razao_Social_Empresa");
            this.Property(t => t.Fantasia_Empresa).HasColumnName("Fantasia_Empresa");
            this.Property(t => t.Logo_Empresa).HasColumnName("Logo_Empresa");
            this.Property(t => t.Logradouro_Empresa).HasColumnName("Logradouro_Empresa");
            this.Property(t => t.Complemento_Endereco_Empresa).HasColumnName("Complemento_Endereco_Empresa");
            this.Property(t => t.Bairro_Empresa).HasColumnName("Bairro_Empresa");
            this.Property(t => t.Cidade_Empresa).HasColumnName("Cidade_Empresa");
            this.Property(t => t.UF_Empresa).HasColumnName("UF_Empresa");
            this.Property(t => t.Cep_Endereco_Empresa).HasColumnName("Cep_Endereco_Empresa");            
            this.Property(t => t.Fone1_Empresa).HasColumnName("Fone1_Empresa");
            this.Property(t => t.Fone2_Empresa).HasColumnName("Fone2_Empresa");
            this.Property(t => t.Email1_Empresa).HasColumnName("Email1_Empresa");
            this.Property(t => t.Email2_Empresa).HasColumnName("Email2_Empresa");
            this.Property(t => t.Receber_Emails_Empresa).HasColumnName("Receber_Emails_Empresa");
            this.Property(t => t.Data_Cadastro_Empresa).HasColumnName("Data_Cadastro_Empresa");
        }
    }
}
