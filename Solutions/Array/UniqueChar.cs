using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Implement an algorithm to determine if a string has all unique characters. What if
    // you cannot use additional data structures?
    [TestClass]
    public class UniqueChar
    {
        public bool IsUniqueChars(string str)
        {
            if (str.Length > 128)
            {
                return false;
            }
            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val]) return false;
                charSet[val] = true;
            }
            return true;
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Unique_Char()
        {
            Assert.IsTrue(IsUniqueChars("abcde"));
            Assert.IsFalse(IsUniqueChars("hello"));
        }

    }
}
