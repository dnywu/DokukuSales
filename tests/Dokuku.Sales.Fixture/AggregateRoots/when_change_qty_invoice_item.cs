using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Spec;
using Dokuku.Sales.Aggregates;
using Dokuku.Sales.Fixture.Given;
using NUnit.Framework;
using Dokuku.Sales.Events.Invoices;

namespace Dokuku.Sales.Fixture
{
    [Specification]
    public class when_change_qty_invoice_item : AggregateRootTestFixture<Invoice>
    {
        protected override IEnumerable<object> Given()
        {
            return new Given_Event_InvoiceItemCreated().Events;
        }

        protected override void When()
        {
            AggregateRoot.ChangeQty(Given_Event_InvoiceItemCreated.InvoiceItemId, 2, "denny");
        }

        [Then]
        public void Then_the_QtyInvoiceItemChanged_event_been_published()
        {
            Assert.AreEqual(PublishedEvents.Count, 1);
            Assert.AreEqual(PublishedEvents.First().Payload.GetType(), typeof(QtyInvoiceItemChanged));
            QtyInvoiceItemChanged ev = (QtyInvoiceItemChanged)PublishedEvents.First().Payload;
        }

        [Then]
        public void Then_the_QtyInvoiceItemChanged_should_be_correct()
        {
            QtyInvoiceItemChanged ev = (QtyInvoiceItemChanged)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.Quantity, 2);
            Assert.AreEqual(ev.AmountBeforeDiscount, 4000000);
        }
    }
}
