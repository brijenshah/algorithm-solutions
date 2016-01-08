using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    // Determine whether an integer is a palindrome. Do this without extra space.
    [TestClass]
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            bool ng = false;
            if (x < 0)
            {
                ng = true;
                x = -x;
            }


            int temp = x;
            int sum = 0;

            while (temp > 0)
            {
                sum = 10*sum + temp%10;
                temp = temp/10;
            }

            if (ng)
            {
                sum = -sum;
            }

            return (sum == x) ? true : false;
        }


        [TestMethod]
        [TestCategory("Math")]
        public void Palindrome_Number()
        {
            Assert.IsTrue(IsPalindrome(12321));
        }
    }
}
