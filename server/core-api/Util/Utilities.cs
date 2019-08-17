using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Util
{
    public static class Utilities
    {
        public static int EnsureMinValue(this int value)
        {
            return value < 0 ? 1 : value;
        }
    }
}
