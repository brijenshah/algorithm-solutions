using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    // Given an integer, convert it to a roman numeral.
    // Input is guaranteed to be within the range from 1 to 3999
    [TestClass]
    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            int[] integer = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            if (num < 1)
                return null;

            string str = "";

            for (int i = 0; i < integer.Length; i++)
            {
                int q = num / integer[i];
                while (q > 0)
                {
                    str = str + roman[i];
                    q--;
                }
                num = num % integer[i];
            }

            return str;
        }

        [TestMethod]
        [TestCategory("Math")]
        public void Int_To_Roman()
        {
            Assert.IsTrue(IntToRoman(1) == "I");
            Assert.IsTrue(IntToRoman(11) == "XI");
        }
    }

}
