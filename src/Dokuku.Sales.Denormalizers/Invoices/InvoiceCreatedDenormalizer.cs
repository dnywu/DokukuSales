using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Events.Invoices;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace Dokuku.Sales.Denormalizers.Invoices
{
    public class InvoiceCreatedDenormalizer : IEventHandler<InvoiceCreated>
    {
        public void Handle(IPublishedEvent<InvoiceCreated> evnt)
        {
            throw new NotImplementedException();
        }
    }
}
