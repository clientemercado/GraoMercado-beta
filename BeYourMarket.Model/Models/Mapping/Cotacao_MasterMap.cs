using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class Cotacao_MasterMap : EntityTypeConfiguration<Cotacao_Master>
    {
        public Cotacao_MasterMap()
        {
            // Primary Key
            this.HasKey(t => t.id_CotacaoMaster);

            // Properties
            this.Property(t => t.id_GrupoAtividades)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Cotacao_Master");
            this.Property(t => t.id_CotacaoMaster).HasColumnName("id_CotacaoMaster");
            this.Property(t => t.id_GrupoAtividades).HasColumnName("id_GrupoAtividades");
            this.Property(t => t.TipoCotacao).HasColumnName("TipoCotacao");
            this.Property(t => t.id_UF_Cotacao).HasColumnName("id_UF_Cotacao");
            this.Property(t => t.id_Cidade_Cotacao).HasColumnName("id_Cidade_Cotacao");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.Cotacao_Disparada).HasColumnName("Cotacao_Disparada");
            this.Property(t => t.Data_Cadastro_CotacaoMaster).HasColumnName("Data_Cadastro_CotacaoMaster");
            this.Property(t => t.Data_Encerramento_CotacaoMaster).HasColumnName("Data_Encerramento_CotacaoMaster");
            this.Property(t => t.ObservacoesRelevantes).HasColumnName("ObservacoesRelevantes");            
            this.Property(t => t.Id_UsuarioCriou).HasColumnName("Id_UsuarioCriou");
            this.Property(t => t.Id_Empresa_Vencedora_CotacaoMaster).HasColumnName("Id_Empresa_Vencedora_CotacaoMaster");
            this.Property(t => t.Ativa_CotacaoMaster).HasColumnName("Ativa_CotacaoMaster");
        }
    }
}
