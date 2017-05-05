using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.DynamicProgramming
{
    [TestClass]
    public class Fibonacci
    {

        public int GetFibonacci(int n)
        {
            int a = 0, b = 1;

            if (n <= 0)
                return a;

            for (int i = 2; i <= n; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        public int GetFibonacciRecursive(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }

            return GetFibonacciRecursive(n - 1) + GetFibonacciRecursive(n - 2);
        }

        [TestMethod]
        [TestCategory("DynamicProgramming")]
        public void Fibonacci_Test()
        {
            Assert.AreEqual(GetFibonacci(4), 3);
            Assert.AreEqual(GetFibonacciRecursive(4), 3);
        }
    }
}
