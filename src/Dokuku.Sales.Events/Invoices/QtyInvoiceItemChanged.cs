using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.Events.Invoices
{
    public class QtyInvoiceItemChanged : InvoiceItemEvent
    {
        public int Quantity { get; set; }
        public double AmountBeforeDiscount { get; set; }
    }
}
