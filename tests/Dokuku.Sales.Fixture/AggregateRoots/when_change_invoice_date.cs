using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Aggregates;
using Ncqrs.Spec;
using Dokuku.Sales.Events.Invoices;
using NUnit.Framework;
using Dokuku.Sales.ValueObjects;

namespace Dokuku.Sales.Fixture
{
    [Specification]
    public class when_change_invoice_date : AggregateRootTestFixture<Invoice>
    {
        private DateTime _newInvoiceDate = new DateTime(2014, 10, 29, 10, 0, 0);
        public when_change_invoice_date()
        {
            Configuration.Configure();
        }

        protected override IEnumerable<object> Given()
        {
            yield return new InvoiceCreated
            {
                UserName = "denny",
                CustomerAddress = "Sei Panas",
                CustomerCity = "Batam",
                CustomerEmail = "denny@inforsys.co.id",
                CustomerId = Guid.NewGuid(),
                CustomerName = "Denny Wu",
                CustomerState = "Indonesia",
                InvoiceDate = DateTime.Now,
                TermCode = "001",
                TermName = "30 Hari",
                TermValue = 30,
                DueDate = DateTime.Now.AddDays(30),
                OwnerId = "denny@inforsys.co.id",
                PONumber = "PO-001",
                Status = Status.DRAFT.ToString()
            };
        }

        protected override void When()
        {
            AggregateRoot.ChangeDate(_newInvoiceDate, "denny");
        }

        [Then]
        public void Then_the_InvoiceDateChanged_event_been_published()
        {
            Assert.AreEqual(PublishedEvents.Count, 1);
            Assert.AreEqual(PublishedEvents.First().Payload.GetType(), typeof(InvoiceDateChanged));
            InvoiceDateChanged ev = (InvoiceDateChanged)PublishedEvents.First().Payload;
        }

        [Then]
        public void InvoiceDate_should_be_changed()
        {
            InvoiceDateChanged ev = (InvoiceDateChanged)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.InvoiceDate, _newInvoiceDate);
        }

        [Then]
        public void DueDate_should_be_changed()
        {
            InvoiceDateChanged ev = (InvoiceDateChanged)PublishedEvents.First().Payload;
            DateTime dueDate = new DateTime(2014, 11, 28, 10, 0, 0);
            Assert.AreEqual(ev.DueDate, dueDate);
        }

        [Then]
        public void UserName_should_be_equals_Denny()
        {
            InvoiceDateChanged ev = (InvoiceDateChanged)PublishedEvents.First().Payload;
            Assert.AreEqual(ev.UserName, "denny");
        }
    }
}
