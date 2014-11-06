using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.ValueObjects;

namespace Dokuku.Sales.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public Term Term { get; private set; }
        public Currency Currency { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Customer(Guid id, Term term, Currency currency, string name, string email, string address, string city, string state)
        {
            this.Id = id;
            this.Term = term;
            this.Currency = currency;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.City = city;
            this.State = state;
        }
    }
}
