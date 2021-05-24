using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.Helpers
{
    class Random
    {
        public static string RandomPassword(int length)
        {
            string allowed = "0123456789";
            return new string(allowed
                .OrderBy(o => Guid.NewGuid())
                .Take(length)
                .ToArray());
        }
    }
}
