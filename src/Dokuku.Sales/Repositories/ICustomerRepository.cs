using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dokuku.Sales.Entities;

namespace Dokuku.Sales.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
    }
}
