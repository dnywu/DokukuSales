using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.Events.Invoices
{
    public class PriceInvoiceItemChanged : InvoiceItemEvent
    {
        public double Price { get; set; }
        public double AmountBeforeDiscount { get; set; }
    }
}
