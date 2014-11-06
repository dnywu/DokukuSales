using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales.ValueObjects
{
    public class Term
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Term(string code, string name, int value)
        {
            this.Code = code;
            this.Name = name;
            this.Value = value;
        }
    }
}
