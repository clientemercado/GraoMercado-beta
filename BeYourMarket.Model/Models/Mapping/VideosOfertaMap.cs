using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class VideosOfertaMap : EntityTypeConfiguration<VideosOferta>
    {
        public VideosOfertaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_VideoOferta);

            // Properties
            this.Property(t => t.id_Oferta)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("VideosOferta");
            this.Property(t => t.id_VideoOferta).HasColumnName("id_VideoOferta");
            this.Property(t => t.id_Oferta).HasColumnName("id_Oferta");
            this.Property(t => t.descricao_videoOferta).HasColumnName("descricao_videoOferta");
        }
    }
}
