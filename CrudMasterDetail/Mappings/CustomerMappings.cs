using CrudMasterDetail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Mappings
{
    public class CustomerMappings : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Table
            builder.ToTable("Customers");

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.CustName).HasColumnName("CustName");
            builder.Property(t => t.Adress).HasColumnName("Adress");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.CustomerTypeId).HasColumnName("CustomerTypeId");

            builder.HasOne(t => t.CustomerTypes)
                .WithMany(t => t.Customers)
                .HasForeignKey(t => t.CustomerTypeId);
        }
    }
}
