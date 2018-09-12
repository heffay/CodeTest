using System;
using System.Collections.Generic;

namespace Invoices.API.Data
{
    public class Invoice : IEntity
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<InvoiceLine> Lines { get; set; }
    }
}