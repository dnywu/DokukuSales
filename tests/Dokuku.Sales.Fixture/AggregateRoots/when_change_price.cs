using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Aggregates;
using Ncqrs.Spec;
using Dokuku.Sales.Fixture.Given;
using Dokuku.Sales.Events.Invoices;
using NUnit.Framework;

namespace Dokuku.Sales.Fixture
{
    public class when_change_price : AggregateRootTestFixture<Invoice>
    {
        protected override IEnumerable<object> Given()
        {
            var events = new Given_Event_InvoiceItemCreated().Events;
            Object[] qtyInvoiceItemChanged = new Object[1]{
                new QtyInvoiceItemChanged
                {
                    AggregateId = Given_Event_InvoiceCreated.InvoiceId,
                    EntityId = Given_Event_InvoiceItemCreated.InvoiceItemId,
                    Quantity = 2,
                    AmountBeforeDiscount = 4000000
                }
            };
            return events.Concat(qtyInvoiceItemChanged).ToArray();
        }

        protected override void When()
        {
            AggregateRoot.ChangePrice(Given_Event_InvoiceItemCreated.InvoiceItemId, 2100000);
        }

        [Then]
        public void Then_the_PriceInvoiceItemChanged_event_been_published()
        {
            Assert.AreEqual(PublishedEvents.Count, 1);
            Assert.AreEqual(PublishedEvents.First().Payload.GetType(), typeof(PriceInvoiceItemChanged));
            PriceInvoiceItemChanged ev = (PriceInvoiceItemChanged)PublishedEvents.First().Payload;
        }

        [Then]
        public void Then_the_PriceInvoiceItemChanged_should_be_correct()
        {
            PriceInvoiceItemChanged ev = (PriceInvoiceItemChanged)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.Price, 2100000);
            Assert.AreEqual(ev.AmountBeforeDiscount, 4200000);
        }
    }
}
