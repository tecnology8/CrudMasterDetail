using CrudMasterDetail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Mappings
{
    public class InvoiceDetailMappings : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            //Table
            builder.ToTable("InvoiceDetail");

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.Qty).HasColumnName("Qty");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.TotalItbis).HasColumnName("TotalItbis");
            builder.Property(t => t.SubTotal).HasColumnName("SubTotal");
            builder.Property(t => t.Total).HasColumnName("Total");

            builder.HasOne(t => t.Customers)
                .WithMany(t => t.InvoiceDetails)
                .HasForeignKey(t => t.CustomerId);
        }
    }
}