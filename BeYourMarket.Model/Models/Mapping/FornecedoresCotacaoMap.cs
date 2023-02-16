using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class FornecedoresCotacaoMap : EntityTypeConfiguration<FornecedoresCotacao>
    {
        public FornecedoresCotacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_FornecedoresCotacao);

            // Properties
            this.Property(t => t.Id_Empresa)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("FornecedoresCotacao");
            this.Property(t => t.Id_FornecedoresCotacao).HasColumnName("Id_FornecedoresCotacao");
            this.Property(t => t.Id_Empresa).HasColumnName("Id_Empresa");
            this.Property(t => t.id_CotacaoMaster).HasColumnName("id_CotacaoMaster");
            this.Property(t => t.RespondeuCotacao).HasColumnName("RespondeuCotacao");
            this.Property(t => t.VenceuCotacao).HasColumnName("VenceuCotacao");
            this.Property(t => t.Data_Recebimento).HasColumnName("Data_Recebimento");
        }
    }
}
