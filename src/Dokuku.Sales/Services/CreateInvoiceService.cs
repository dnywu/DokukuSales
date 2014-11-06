using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Commands.Invoices;
using Ncqrs.Commanding.CommandExecution;
using Dokuku.Sales.Aggregates;
using Dokuku.Sales.Entities;
using Dokuku.Sales.Repositories;
using Ncqrs;
using Dokuku.Sales.Exceptions;

namespace Dokuku.Sales.Services
{
    public class CreateInvoiceService : CommandExecutorBase<CreateInvoice>
    {
        private ICustomerRepository customerRepository;

        protected override void ExecuteInContext(Ncqrs.Domain.IUnitOfWorkContext context, CreateInvoice command)
        {
            customerRepository = NcqrsEnvironment.Get<ICustomerRepository>();
            Customer customer = customerRepository.Get(command.CustomerId);
            //if (customer.IsNull()) throw new CustomerNotFoundException();
            //if(customer.Status == 
            //check customer is not null
            //check statuc customer must aktif

            new Invoice(command.InvoiceId, customer, command.PONumber, command.OwnerId, command.UserName);
            context.Accept();
        }
    }
}
