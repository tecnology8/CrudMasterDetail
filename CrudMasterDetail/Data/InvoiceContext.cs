using CrudMasterDetail.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMasterDetail.ViewModels;

namespace CrudMasterDetail.Data
{
    public class InvoiceContext: DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTypes> CustomerTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceContext).Assembly);
        }
        public DbSet<CrudMasterDetail.ViewModels.InvoiceDetailsViewModels> InvoiceDetailsViewModels { get; set; }
    }
}