using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
            : base("Customer tidak ditemukan")
        {
        }
    }
}
