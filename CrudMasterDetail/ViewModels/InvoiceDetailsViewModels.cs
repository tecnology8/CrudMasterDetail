using CrudMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.ViewModels
{
    public class InvoiceDetailsViewModels
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}