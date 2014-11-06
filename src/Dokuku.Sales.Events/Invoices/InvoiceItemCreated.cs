using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Dokuku.Sales.Events.Invoices
{
    public class InvoiceItemCreated : InvoiceItemEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        //public double AmountBeforeDiscount { get; set; }
    }
}
