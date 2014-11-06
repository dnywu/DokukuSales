using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Repositories;
using Dokuku.Sales.Entities;
using Dokuku.Sales.ValueObjects;

namespace Dokuku.Sales.Fixture.Screnarios.Fake
{
    public class CustomerRepository : ICustomerRepository
    {
        public static Guid CustomerID1 = new Guid("CC882CFB-1F4C-46D6-A6EB-196F22904A12");
        public Customer Get(Guid id)
        {
            if (id == CustomerID1)
            {
                var term = new Term("001", "30 Hari", 30);
                var currency = new Currency("IDR");
                return new Customer(CustomerID1, term, currency, "Denny Wu", "denny@inforsys.co.id", "Laksamana Bintan", "Batam", "Indonesia");
            }
            return null;
        }
    }
}
