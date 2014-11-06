using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Events.Invoices;

namespace Dokuku.Sales.Fixture.Given
{
    public class Given_Event_InvoiceItemCreated : Given_Event_InvoiceCreated
    {
        public static Guid InvoiceItemId = new Guid("DCCD617E-6083-4FAA-A328-15ADD3771DBC");
        public override IEnumerable<object> Events
        {
            get
            {
                Object[] result = new Object[1]{
                    new InvoiceItemCreated{
                         AggregateId = InvoiceId,
                         EntityId = InvoiceItemId,
                         ProductId = Guid.NewGuid(),
                         Name = "Asus ZenFone 5",
                         Description = "Warna Merah Maroon",
                         Quantity = 1,
                         Price = 2000000d//,
                         //AmountBeforeDiscount = 2000000
                    }
                };

                return base.Events.Concat(result).ToArray();
            }
        }
    }
}
