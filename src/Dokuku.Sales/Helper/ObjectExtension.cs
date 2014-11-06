using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokuku.Sales
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object obj)
        {
            return Object.ReferenceEquals(obj, null);
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }
    }
}
