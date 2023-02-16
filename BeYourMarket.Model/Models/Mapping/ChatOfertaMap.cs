using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class ChatOfertaMap : EntityTypeConfiguration<ChatOferta>
    {
        public ChatOfertaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_ChatOferta);

            // Properties
            this.Property(t => t.id_Oferta)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ChatOferta");
            this.Property(t => t.id_ChatOferta).HasColumnName("id_ChatOferta");
            this.Property(t => t.id_Oferta).HasColumnName("id_Oferta");
            this.Property(t => t.id_Usuario_Perguntou).HasColumnName("id_Usuario_Perguntou");
            this.Property(t => t.id_Usuario_Respondeu).HasColumnName("id_Usuario_Respondeu");
            this.Property(t => t.Data_Interacao_Chat).HasColumnName("Data_Interacao_Chat");
            this.Property(t => t.Texto_Chat).HasColumnName("Texto_Chat");
            this.Property(t => t.Eh_Pergunta).HasColumnName("Eh_Pergunta");
            this.Property(t => t.Pergunta_Respondida).HasColumnName("Pergunta_Respondida");
            this.Property(t => t.Id_Pergunta).HasColumnName("Id_Pergunta");            
            this.Property(t => t.Ordem_Exibicao_ChatOferta).HasColumnName("Ordem_Exibicao_ChatOferta");
        }
    }
}
