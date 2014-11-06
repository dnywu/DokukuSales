using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.ValueObjects
{
    public class Currency
    {
        public string Code { get; private set; }

        public Currency(string code)
        {
            this.Code = code;
        }
    }
}
