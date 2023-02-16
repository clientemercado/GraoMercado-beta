using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class Resposta_FornecedoresCotacaoMap : EntityTypeConfiguration<Resposta_FornecedoresCotacao>
    {
        public Resposta_FornecedoresCotacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Resposta_FornecedoresCotacao);

            //// Properties
            //this.Property(t => t.Id_Empresa_Resposta)
            //    .IsRequired();
            // Properties
            this.Property(t => t.Id_ItemCotacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Resposta_FornecedoresCotacao");
            this.Property(t => t.Id_Resposta_FornecedoresCotacao).HasColumnName("Id_Resposta_FornecedoresCotacao");
            //this.Property(t => t.Id_Empresa_Resposta).HasColumnName("Id_Empresa_Resposta");
            this.Property(t => t.Id_ItemCotacao).HasColumnName("Id_ItemCotacao");
            this.Property(t => t.Id_FornecedoresCotacao).HasColumnName("Id_FornecedoresCotacao");
            this.Property(t => t.Id_UsuarioRespondeu).HasColumnName("Id_UsuarioRespondeu");
            this.Property(t => t.Data_Resposta).HasColumnName("Data_Resposta");
            this.Property(t => t.Quantidade_ItemCotado).HasColumnName("Quantidade_ItemCotado");            
            this.Property(t => t.ValorUnitario_Resposta).HasColumnName("ValorUnitario_Resposta");
            this.Property(t => t.id_TipoFrete).HasColumnName("id_TipoFrete");            
            this.Property(t => t.FormaPagamento_Resposta).HasColumnName("FormaPagamento_Resposta");
            this.Property(t => t.Resposta_Vencedora).HasColumnName("Resposta_Vencedora");
            this.Property(t => t.Observacao_Resposta).HasColumnName("Observacao_Resposta");
        }
    }
}
