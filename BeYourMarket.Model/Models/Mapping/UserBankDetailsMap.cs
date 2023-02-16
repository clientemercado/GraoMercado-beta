using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class UserBankDetailsMap : EntityTypeConfiguration<UserBankDetails>
    {
        public UserBankDetailsMap()
        {
            this.HasKey(t => t.Id_UBankDetails);

            // Properties
            this.Property(t => t.Id_User_UBankDetails)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("UserBankDetails");
            this.Property(t => t.Id_UBankDetails).HasColumnName("Id_UBankDetails");
            this.Property(t => t.Id_User_UBankDetails).HasColumnName("Id_User_UBankDetails");
            this.Property(t => t.id_TipoConta).HasColumnName("id_TipoConta");
            this.Property(t => t.id_TipoChavePix).HasColumnName("id_TipoChavePix");
            this.Property(t => t.id_Bank).HasColumnName("id_Bank");
            this.Property(t => t.Cod_Agencia).HasColumnName("Cod_Agencia");
            this.Property(t => t.Cod_Conta).HasColumnName("Cod_Conta");
            this.Property(t => t.Cod_Dig_Conta).HasColumnName("Cod_Dig_Conta");
            this.Property(t => t.Chave_Pix_Conta).HasColumnName("Chave_Pix_Conta");
            this.Property(t => t.Data_Cadastro_UBankDetails).HasColumnName("Data_Cadastro_UBankDetails");
        }
    }
}
