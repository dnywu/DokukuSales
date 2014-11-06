using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Spec;
using Dokuku.Sales.Commands.Invoices;
using Dokuku.Sales.Events.Invoices;
using Ncqrs.Spec.Fakes;
using Dokuku.Sales.Repositories;
using Dokuku.Sales.Fixture.Screnarios.Fake;
using NUnit.Framework;

namespace Dokuku.Sales.Fixture.Screnarios
{
    [Specification]
    public class when_creating_a_new_invoice : OneEventTestFixture<CreateInvoice, InvoiceCreated>
    {
        public when_creating_a_new_invoice()
        {
            Configuration.Configure();
        }

        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            configuration.Register<ICustomerRepository>(new CustomerRepository());
        }

        protected override CreateInvoice WhenExecuting()
        {
            return new CreateInvoice(EventSourceId, CustomerRepository.CustomerID1, "PO-001", "denny@inforsys.co.id", "denny wu");
        }

        [Then]
        public void The_event_should_have_correct()
        {
            Assert.AreEqual(TheEvent.InvoiceId, EventSourceId);
            Assert.AreEqual(TheEvent.OwnerId, "denny@inforsys.co.id");
            Assert.AreEqual(TheEvent.PONumber, "PO-001");
            Assert.AreEqual(TheEvent.TermCode, "001");
            Assert.AreEqual(TheEvent.TermName, "30 Hari");
            Assert.AreEqual(TheEvent.TermValue, 30);
            Assert.AreEqual(TheEvent.UserName, "denny wu");
            Assert.AreEqual(TheEvent.Status, "DRAFT");
            Assert.AreEqual(TheEvent.CustomerId, CustomerRepository.CustomerID1);
            Assert.AreEqual(TheEvent.CustomerName, "Denny Wu");
            Assert.AreEqual(TheEvent.CustomerAddress, "Laksamana Bintan");
            Assert.AreEqual(TheEvent.CustomerCity, "Batam");
            Assert.AreEqual(TheEvent.CustomerEmail, "denny@inforsys.co.id");
            Assert.AreEqual(TheEvent.CustomerState, "Indonesia");
        }
    }
}
