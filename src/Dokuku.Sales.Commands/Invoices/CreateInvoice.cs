using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Dokuku.Sales.Commands.Invoices
{
    //[MapsToAggregateRootConstructor("Dokuku.Sales.Aggregates.Invoice, Dokuku.Sales")]
    public class CreateInvoice : CommandBase
    {
        public Guid InvoiceId { get; private set; }
        public Guid CustomerId { get; set; }
        public string PONumber { get; set; }
        public string OwnerId { get; set; }
        public string UserName { get; set; }

        public CreateInvoice(Guid invoiceId, Guid customerId, string poNumber, string ownerId, string userName)
        {
            this.InvoiceId = invoiceId;
            this.CustomerId = customerId;
            this.PONumber = poNumber;
            this.OwnerId = ownerId;
            this.UserName = userName;
        }
    }
}
