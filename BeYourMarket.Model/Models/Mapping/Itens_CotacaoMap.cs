using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class Itens_CotacaoMap : EntityTypeConfiguration<Itens_Cotacao>
    {
        public Itens_CotacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_ItemCotacao);

            // Properties
            this.Property(t => t.id_CotacaoMaster)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Itens_Cotacao");
            this.Property(t => t.Id_ItemCotacao).HasColumnName("Id_ItemCotacao");
            this.Property(t => t.id_CotacaoMaster).HasColumnName("id_CotacaoMaster");
            this.Property(t => t.Descricao_ItemCotacao).HasColumnName("Descricao_ItemCotacao");
            this.Property(t => t.Quantidade_ItemCotacao).HasColumnName("Quantidade_ItemCotacao");
            this.Property(t => t.UnidadeProduto).HasColumnName("UnidadeProduto");
            this.Property(t => t.Id_UsuarioCriou).HasColumnName("Id_UsuarioCriou");
        }
    }
}
