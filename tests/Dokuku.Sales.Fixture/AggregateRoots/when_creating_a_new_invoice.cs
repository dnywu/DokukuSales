using System;
using System.Linq;
using Ncqrs.Spec;
using Dokuku.Sales.Aggregates;
using Dokuku.Sales.Entities;
using Dokuku.Sales.ValueObjects;
using NUnit.Framework;

namespace Dokuku.Sales.Fixture
{
    [Specification]
    public class when_creating_a_new_invoice : AggregateRootTestFixture<Invoice>
    {
        private Guid invoiceId;
        private Customer customer;
        private string poNumber;
        private string ownerId;
        private string userName;

        public when_creating_a_new_invoice()
        {
            this.invoiceId = Guid.NewGuid();
            this.poNumber = "PO-001";
            this.ownerId = "denny@inforsys.co.id";
            this.userName = "dennywu";
            var term = new Term("001", "30 Hari", 30);
            var currency = new Currency("IDR");
            this.customer = new Customer(Guid.NewGuid(), term, currency, "Denny Wu", "", "", "", "");
        }

        protected override void When()
        {
            AggregateRoot = new Invoice(invoiceId, customer, poNumber, ownerId, userName);
        }

        //Any bug with nqcrs AggregateRootTestFixture when create new aggregate
        //[Then]
        //public void Then_one_event_InvoiceCreated_should_have_been_published()
        //{
        //    Assert.AreEqual(PublishedEvents.Count, 1);
        //}
    }
}
