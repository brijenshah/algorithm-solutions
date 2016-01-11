using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    //Given a column title as appear in an Excel sheet, return its corresponding column number.
    // For example:
    //      A -> 1
    //      B -> 2
    //      C -> 3
    //      ...
    //      Z -> 26
    //      AA -> 27
    //      AB -> 28 
    [TestClass]
    public class ExcelColumnNumber
    {
        public int TitleToNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");

            int result = 0;
            int t = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                result = result + (int)System.Math.Pow(26, t) * (c - 'A' + 1);
                t++;
            }
            return result;
        }

        [TestMethod]
        [TestCategory("Math")]
        public void TitleToNumber()
        {
            Assert.AreEqual(TitleToNumber("A"), 1);
            Assert.AreEqual(TitleToNumber("AB"), 28);
        }
    }
}
