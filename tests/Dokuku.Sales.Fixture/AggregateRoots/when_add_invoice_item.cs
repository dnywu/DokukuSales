using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Spec;
using Dokuku.Sales.Aggregates;
using Dokuku.Sales.Events.Invoices;
using Dokuku.Sales.ValueObjects;
using NUnit.Framework;
using Dokuku.Sales.Fixture.Given;

namespace Dokuku.Sales.Fixture
{
    [Specification]
    public class when_add_invoice_item : AggregateRootTestFixture<Invoice>
    {
        private Guid _invoiceItemId = Guid.NewGuid();
        private Guid _productId = Guid.NewGuid();
        private string _name = "Asus ZenFone 5";
        private string _description = "Warna Merah Maroon";

        protected override IEnumerable<object> Given()
        {
            return new Given_Event_InvoiceCreated().Events;
        }

        protected override void When()
        {
            var quantity = 1;
            var price = 2000000d;
            AggregateRoot.AddItem(_invoiceItemId, _productId, _name, _description, quantity, price);
        }

        [Then]
        public void Then_the_InvoiceItemCreated_event_been_published()
        {
            Assert.AreEqual(PublishedEvents.Count, 1);
            Assert.AreEqual(PublishedEvents.First().Payload.GetType(), typeof(InvoiceItemCreated));
            InvoiceItemCreated ev = (InvoiceItemCreated)PublishedEvents.First().Payload;
        }

        [Then]
        public void Then_the_InvoiceItemCreated_should_be_correct()
        {
            InvoiceItemCreated ev = (InvoiceItemCreated)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.EntityId, _invoiceItemId);
            Assert.AreEqual(ev.Name, _name);
            Assert.AreEqual(ev.Description, _description);
            Assert.AreEqual(ev.ProductId, _productId);
            Assert.AreEqual(ev.Quantity, 1);
            Assert.AreEqual(ev.Price, 2000000d);
            //Assert.AreEqual(ev.AmountBeforeDiscount, 2000000d);
        }
    }
}
