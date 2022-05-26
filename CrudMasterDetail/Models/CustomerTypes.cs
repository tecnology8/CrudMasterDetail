using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMasterDetail.Models
{
    public class CustomerTypes
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}