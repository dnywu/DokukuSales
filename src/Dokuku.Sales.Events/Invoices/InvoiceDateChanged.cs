using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.Events.Invoices
{
    public class InvoiceDateChanged : InvoiceEvent
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string UserName { get; set; }
    }
}
