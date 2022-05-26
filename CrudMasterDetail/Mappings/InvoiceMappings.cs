using CrudMasterDetail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Mappings
{
    public class InvoiceMappings : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            //Table
            builder.ToTable("Invoice");

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.TotalItbis).HasColumnName("TotalItbis");
            builder.Property(t => t.SubTotal).HasColumnName("SubTotal");
            builder.Property(t => t.Total).HasColumnName("Total");

            builder.HasOne(t => t.Customers)
                .WithMany(t => t.Invoices)
                .HasForeignKey(t => t.CustomerId);
        }
    }
}