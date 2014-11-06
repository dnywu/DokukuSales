using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Events.Invoices;
using Dokuku.Sales.ValueObjects;

namespace Dokuku.Sales.Fixture.Given
{
    public class Given_Event_InvoiceCreated
    {
        public static Guid InvoiceId = new Guid("AD4DB777-3329-46E9-9712-04465DED0722");
        public virtual IEnumerable<object> Events
        {
            get
            {
                return new Object[1]
                {
                    new InvoiceCreated
                    {
                        InvoiceId = InvoiceId,
                        UserName = "denny",
                        CustomerAddress = "Sei Panas",
                        CustomerCity = "Batam",
                        CustomerEmail = "denny@inforsys.co.id",
                        CustomerId = Guid.NewGuid(),
                        CustomerName = "Denny Wu",
                        CustomerState = "Indonesia",
                        InvoiceDate = DateTime.Now,
                        TermCode = "001",
                        TermName = "30 Hari",
                        TermValue = 30,
                        DueDate = DateTime.Now.AddDays(30),
                        OwnerId = "denny@inforsys.co.id",
                        PONumber = "PO-001",
                        Status = Enum.GetName(typeof(Status), Status.DRAFT)
                    }
                };
            }
        }
    }
}
