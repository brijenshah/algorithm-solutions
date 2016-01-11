using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.String
{
    // Given two strings s and t, write a function to determine if t is an anagram of s.
    // For example,
    //      s = "anagram", t = "nagaram", return true.
    //      s = "rat", t = "car", return false.
    [TestClass]
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] letters = new int[256];

            foreach (var c in s)
            {
                letters[(int)c]++;
            }

            foreach (var c in t)
            {
                letters[(int)c]--;

                if (letters[(int)c] < 0)
                    return false;
            }

            return true;
        }

        [TestCategory("String")]
        [TestMethod]
        public void Valid_Anagram()
        {
            Assert.IsTrue(IsAnagram("anagram", "nagaram"));
            Assert.IsFalse(IsAnagram("rat", "car"));
        }
        
    }
}
