using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.String
{
    // Write a function to find the longest common prefix string amongst an array of strings.
    [TestClass]
    public class LongestCommonPrefix
    {
        public string GetLongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            int minLen = Int32.MaxValue;
            foreach (string str in strs)
            {
                if (minLen > str.Length)
                    minLen = str.Length;
            }
            if (minLen == 0) return "";

            for (int j = 0; j < minLen; j++)
            {
                char prev = '0';
                for (int i = 0; i < strs.Length; i++)
                {
                    if (i == 0)
                    {
                        prev = strs[i][j];
                        continue;
                    }

                    if (strs[i][j] != prev)
                    {
                        return strs[i].Substring(0, j);
                    }
                }
            }

            return strs[0].Substring(0, minLen);
        }

        [TestMethod]
        [TestCategory("String")]
        public void Longest_Common_Prefix()
        {
            Assert.AreEqual(GetLongestCommonPrefix( new[] {"flight", "fleet", "fly"}),"fl");
        }
    }
}
