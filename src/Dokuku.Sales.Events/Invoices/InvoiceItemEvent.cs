﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace Dokuku.Sales.Events.Invoices
{
    public class InvoiceItemEvent : EntitySourcedEventBase
    {
        public DateTime LastUpdated { get { return DateTime.Now; } }
    }
}
