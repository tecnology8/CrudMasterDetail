using CrudMasterDetail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Mappings
{
    public class CustomerTypeMappings : IEntityTypeConfiguration<CustomerTypes>
    {
        public void Configure(EntityTypeBuilder<CustomerTypes> builder)
        {
            //Table
            builder.ToTable("CustomerTypes");

            //Primary Key
            builder.HasKey(t => t.Id);

            //Properties
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
