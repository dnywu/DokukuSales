using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.Events.Invoices
{
    public class PONumberChanged : InvoiceEvent
    {
        public string PONumber { get; set; }
    }
}
