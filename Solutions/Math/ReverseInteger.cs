using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    //Reverse digits of an integer.
    // Example1: x = 123, return 321
    // Example2: x = -123, return -321
    [TestClass]
    public class ReverseInteger
    {
        public int Reverse(int x)
        {
            bool ng = false;

            if (x < 0)
            {
                ng = true;
                x = x * -1;
            }

            long val = 0;
            while (x != 0)
            {
                val = (val * 10) + (x % 10);
                x /= 10;
            }

            if (ng)
            {
                val = val * -1;
            }

            if (val > Int32.MaxValue || val < Int32.MinValue)
                return 0;

            return (int)val;
        }

        [TestMethod]
        [TestCategory("Math")]
        public void Reverse_Integer()
        {
            Assert.AreEqual(Reverse(123), 321);
            Assert.AreEqual(Reverse(-123), -321);
        }
    }
}
