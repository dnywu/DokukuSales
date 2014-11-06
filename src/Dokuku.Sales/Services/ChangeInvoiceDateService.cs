using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Commands.Invoices;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;
using Dokuku.Sales.Aggregates;

namespace Dokuku.Sales.Services
{
    public class ChangeInvoiceDateService : CommandExecutorBase<ChangeInvoiceDate>
    {
        protected override void ExecuteInContext(IUnitOfWorkContext context, ChangeInvoiceDate command)
        {
            var invoice = context.GetById<Invoice>(command.InvoiceId);
            //check periode inventory
            invoice.ChangeDate(command.InvoiceDate, command.UserName);
            context.Accept();
        }
    }
}
