﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Dokuku.Sales.Events.Invoices
{
    [Serializable]
    public abstract class InvoiceEvent : SourcedEvent
    {
        public Guid InvoiceId { get { return EventSourceId; } }
        public DateTime LastUpdated { get { return DateTime.Now; } }
    }
}
