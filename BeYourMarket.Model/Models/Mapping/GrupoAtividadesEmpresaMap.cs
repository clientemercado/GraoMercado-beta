using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class GrupoAtividadesEmpresaMap : EntityTypeConfiguration<GrupoAtividadesEmpresa>
    {
        public GrupoAtividadesEmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_GrupoAtividades);

            // Properties
            this.Property(t => t.id_GrupoAtividades)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("GrupoAtividadesEmpresa");
            this.Property(t => t.id_GrupoAtividades).HasColumnName("id_GrupoAtividades");
            this.Property(t => t.Descricao_Atividades).HasColumnName("Descricao_Atividades");
        }
    }
}
