using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Dokuku.Sales.Commands.Invoices
{
    [Serializable]
    public class ChangeInvoiceDate : CommandBase
    {
        [AggregateRootId]
        public Guid InvoiceId { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public string UserName { get; private set; }

        public ChangeInvoiceDate(Guid invoiceId, DateTime invoiceDate, string userName)
        {
            this.InvoiceId = invoiceId;
            this.InvoiceDate = invoiceDate;
            this.UserName = userName;
        }
    }
}