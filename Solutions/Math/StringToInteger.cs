using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    // Implement atoi to convert a string to an integer.
    [TestClass]
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            // trim white spaces
            str = str.Trim();

            if (str == null || str.Length < 1)
                return 0;

            char flag = '+';

            // check negative or positive
            int i = 0;
            if (str[0] == '-')
            {
                flag = '-';
                i++;
            }
            else if (str[0] == '+')
            {
                i++;
            }
            // use double to store result
            double result = 0;

            // calculate value
            while (str.Length > i && str[i] >= '0' && str[i] <= '9')
            {
                result = result * 10 + (str[i] - '0');
                i++;
            }

            if (flag == '-')
                result = -result;

            // handle max and min
            if (result > Int32.MaxValue)
                return Int32.MaxValue;

            if (result < Int32.MinValue)
                return Int32.MinValue;

            return (int)result;
        }

        [TestMethod]
        [TestCategory("Math")]
        public void String_To_Integer()
        {
            Assert.AreEqual(MyAtoi("123"), 123);
        }
    }
}
