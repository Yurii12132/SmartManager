using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Infrastructure.Comparers
{
    public class StringIgnoreCaseEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Trim().Equals(y.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
