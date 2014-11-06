using System;
using System.Linq;
using System.Collections;
using Ncqrs.Domain;
using Dokuku.Sales.Commands.Invoices;
using Dokuku.Sales.Events.Invoices;
using Dokuku.Sales.Entities;
using Dokuku.Sales.ValueObjects;
using System.Collections.Generic;

namespace Dokuku.Sales.Aggregates
{
    public class Invoice : AggregateRootMappedByConvention
    {
        private int _termValue;
        private IList<InvoiceItem> _items = new List<InvoiceItem>();

        private Invoice() { }

        public Invoice(Guid invoiceId, Customer customer, string poNumber, string ownerId, string userName)
            : base(invoiceId)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime dueDate = currentDateTime.AddDays(customer.Term.Value);
            ApplyEvent(new InvoiceCreated
            {
                InvoiceId = EventSourceId,
                InvoiceDate = currentDateTime,
                OwnerId = ownerId,
                PONumber = poNumber,
                UserName = userName,
                Status = Enum.GetName(typeof(Status), Status.DRAFT),
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CustomerCity = customer.City,
                CustomerAddress = customer.Address,
                CustomerEmail = customer.Email,
                CustomerState = customer.State,
                CustomerCurrencyCode = customer.Currency.Code,
                TermCode = customer.Term.Code,
                TermName = customer.Term.Name,
                TermValue = customer.Term.Value,
                DueDate = dueDate
            });
        }

        public void ChangeDate(DateTime invoiceDate, string userName)
        {
            DateTime dueDate = invoiceDate.AddDays(_termValue);
            ApplyEvent(new InvoiceDateChanged
            {
                InvoiceDate = invoiceDate,
                DueDate = dueDate,
                UserName = userName
            });
        }

        public void ChangePONumber(string poNumber)
        {
            ApplyEvent(new PONumberChanged
            {
                PONumber = poNumber
            });
        }

        public void AddItem(Guid invoiceItemId, Guid productId, string name, string description, int quantity, double price)
        {
            ApplyEvent(new InvoiceItemCreated
            {
                EntityId = invoiceItemId,
                ProductId = productId,
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                AggregateId = EventSourceId
            });
        }

        public void ChangeQty(Guid id, int quantity, string userName)
        {
            var item = _items.FirstOrDefault(i => i.EntityId.Equals(id));
            item.ChangeQty(quantity, userName);
        }

        public void ChangePrice(Guid id, double price)
        {
            var item = _items.FirstOrDefault(i => i.EntityId.Equals(id));
            item.ChangePrice(price);
        }

        #region Event Handlers

        private void OnInvoiceCreated(InvoiceCreated ev)
        {
            this._termValue = ev.TermValue;
        }

        private void OnInvoiceItemCreated(InvoiceItemCreated ev)
        {
            var item = new InvoiceItem(this, ev.EntityId, ev.ProductId, ev.Name, ev.Description, ev.Quantity, ev.Price);
            _items.Add(item);
        }

        private void OnInvoiceDateChanged(InvoiceDateChanged ev)
        {
        }

        private void OnPONumberChanged(PONumberChanged ev)
        {
        }

        #endregion
    }
}
