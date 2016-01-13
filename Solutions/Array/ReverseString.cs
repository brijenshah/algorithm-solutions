using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Implement a function to reverses a null-terminated string.
    [TestClass]
    public class ReverseString
    {
        public string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            char[] chars = str.ToCharArray();
            Swap(chars, 0, str.Length - 1);

            return new string(chars);
        }

        private void Swap(char[] str, int start, int end)
        {
            while (end > start)
            {
                char t = str[start];
                str[start] = str[end];
                str[end] = t;
                end--;
                start++;
            }
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Reverse_String()
        {
            Assert.AreEqual(Reverse("vxyz"), "zyxv");
            Assert.AreEqual(Reverse("abcde"), "edcba");
        }
    }
}
