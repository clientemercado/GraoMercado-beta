using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class OperationTypeMap : EntityTypeConfiguration<OperationType>
    {
        public OperationTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.id_OperationType);

            // Properties
            this.Property(t => t.Descricacao_Operacao)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.Percentual_Comissao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("OperationType");
            this.Property(t => t.id_OperationType).HasColumnName("id_OperationType");
            this.Property(t => t.Descricacao_Operacao).HasColumnName("Descricacao_Operacao");
            this.Property(t => t.Percentual_Comissao).HasColumnName("Percentual_Comissao");
            this.Property(t => t.ValorDoServico).HasColumnName("ValorDoServico");
        }
    }
}
