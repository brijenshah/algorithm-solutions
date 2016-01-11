using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Math
{
    // Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
    // For example:
    //      Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
    // Follow up:
    //      Could you do it without any loop/recursion in O(1) runtime?
    [TestClass]
    public class AddDigits
    {
        public int AddDigitNumbers(int num)
        {
            if (num < 10)
                return num;

            if (num % 9 == 0)
                return 9;

            return num % 9;
        }

        [TestMethod]
        [TestCategory("Math")]
        public void Add_Digits()
        {
            Assert.AreEqual(AddDigitNumbers(38), 2);
        }
    }
}
