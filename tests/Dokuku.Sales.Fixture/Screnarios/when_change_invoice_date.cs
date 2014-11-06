using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Commands.Invoices;
using Dokuku.Sales.Events.Invoices;
using Ncqrs.Spec;
using Dokuku.Sales.Fixture.Given;
using NUnit.Framework;

namespace Dokuku.Sales.Fixture.Screnarios
{
    public class when_change_invoice_date : OneEventTestFixture<ChangeInvoiceDate, InvoiceDateChanged>
    {
        private DateTime newInvoiceDate = new DateTime(2014, 11, 3, 10, 0, 0);
        public when_change_invoice_date()
        {
            Configuration.Configure();
        }

        protected override IEnumerable<object> GivenEvents()
        {
            return new Given_Event_InvoiceCreated().Events;
        }

        protected override ChangeInvoiceDate WhenExecuting()
        {
            return new ChangeInvoiceDate(this.EventSourceId, newInvoiceDate, "denny wu");
        }

        [Then]
        public void The_event_should_have_correct()
        {
            Assert.AreEqual(TheEvent.InvoiceDate, newInvoiceDate);
            Assert.AreEqual(TheEvent.DueDate, newInvoiceDate.AddDays(30));
        }
    }
}
