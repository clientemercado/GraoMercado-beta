using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Model.Models.Mapping
{
    public class BanksMap : EntityTypeConfiguration<Banks>
    {
        public BanksMap()
        {
            this.HasKey(t => t.id_Bank);

            // Properties
            this.Property(t => t.id_Country)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Banks");
            this.Property(t => t.id_Bank).HasColumnName("id_Bank");
            this.Property(t => t.id_Country).HasColumnName("id_Country");
            this.Property(t => t.COMPE).HasColumnName("COMPE");
            this.Property(t => t.ISPB).HasColumnName("ISPB");
            this.Property(t => t.Document).HasColumnName("Document");
            this.Property(t => t.LongName).HasColumnName("LongName");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.Network).HasColumnName("Network");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.PixType).HasColumnName("PixType");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.CreditDocument).HasColumnName("CreditDocument");
            this.Property(t => t.SalaryPortability).HasColumnName("SalaryPortability");
            this.Property(t => t.Products).HasColumnName("Products");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.DateOperationStarted).HasColumnName("DateOperationStarted");
            this.Property(t => t.DatePixStarted).HasColumnName("DatePixStarted");
            this.Property(t => t.DateRegistered).HasColumnName("DateRegistered");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
        }
    }
}
