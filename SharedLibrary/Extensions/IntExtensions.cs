using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class IntExtensions
    {
        public static int GetRandom(this Random random)
        {
            Random r = new Random();
            return r.Next(10);
        }

        public static bool IsEven(this int num) => (num % 2) == 0 ? true : false;

        public static bool IsOdd(this int num) => !num.IsEven();
    }
}
