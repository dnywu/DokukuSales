using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Dokuku.Sales.Events.Invoices
{
    [Serializable]
    public class InvoiceCreated : SourcedEvent
    {
        public Guid InvoiceId { get; set; }
        public string PONumber { get; set; }
        public string OwnerId { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public int TermValue { get; set; }
        public DateTime LastUpdated { get { return DateTime.Now; } }
    }
}
