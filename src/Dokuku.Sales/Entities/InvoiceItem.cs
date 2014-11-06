using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Dokuku.Sales.Aggregates;
using Dokuku.Sales.Events.Invoices;

namespace Dokuku.Sales.Entities
{
    public class InvoiceItem : EntityMappedByConvention<Invoice>
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public double AmountBeforeDiscount { get; private set; }

        public InvoiceItem(Invoice invoice, Guid id) : base(invoice, id) { }

        public InvoiceItem(Invoice invoice, Guid id, Guid productId, string name, string description, int quantity, double price)
            : base(invoice, id)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
            this.AmountBeforeDiscount = CalculateAmountBeforeDiscount(quantity, price);
        }
        
        public void ChangeQty(int quantity, string userName)
        {
            ApplyEvent(new QtyInvoiceItemChanged
            {
                Quantity = quantity,
                AmountBeforeDiscount = CalculateAmountBeforeDiscount(quantity, this.Price)
            });
        }

        public void ChangePrice(double price)
        {            
            ApplyEvent(new PriceInvoiceItemChanged
            {
                Price = price,
                AmountBeforeDiscount = CalculateAmountBeforeDiscount(this.Quantity, price)
            });
        }

        private double CalculateAmountBeforeDiscount(int qty, double price)
        {
            return qty * price;
        }

        #region Event Handlers

        private void OnQtyInvoiceItemChanged(QtyInvoiceItemChanged ev)
        {
            this.Quantity = ev.Quantity;
            this.AmountBeforeDiscount = ev.AmountBeforeDiscount;
        }

        private void OnQtyInvoiceItemChanged(PriceInvoiceItemChanged ev)
        {
            this.Price = ev.Price;
            this.AmountBeforeDiscount = ev.AmountBeforeDiscount;
        }

        #endregion
    }
}
