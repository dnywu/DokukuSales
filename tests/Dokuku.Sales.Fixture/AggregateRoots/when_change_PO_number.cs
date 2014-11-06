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
    public class when_change_PO_number : AggregateRootTestFixture<Invoice>
    {
        protected override IEnumerable<object> Given()
        {
            return new Given_Event_InvoiceCreated().Events;
        }

        protected override void When()
        {
            AggregateRoot.ChangePONumber("PO-002");
        }

        [Then]
        public void Then_the_PONumberChanged_event_been_published()
        {
            Assert.AreEqual(PublishedEvents.Count, 1);
            Assert.AreEqual(PublishedEvents.First().Payload.GetType(), typeof(PONumberChanged));
            PONumberChanged ev = (PONumberChanged)PublishedEvents.First().Payload;
        }

        [Then]
        public void PONumber_should_be_changed()
        {
            PONumberChanged ev = (PONumberChanged)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.PONumber, "PO-002");
        }
    }
}
