using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerTypes CustomerTypes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
