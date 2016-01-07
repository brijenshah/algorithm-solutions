using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.String
{
    // Given a string, find the length of the longest substring without repeating characters. 
    // For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
    // which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
    [TestClass]
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null)
                return 0;

            bool[] flag = new bool[256];

            int result = 0;
            int start = 0;
            char[] arr = s.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                char current = arr[i];
                if (flag[current])
                {
                    result = Math.Max(result, i - start);
                    // the loop update the new start point
                    // and reset flag array
                    // for example, abccab, when it comes to 2nd c,
                    // it update start from 0 to 3, reset flag for a,b
                    for (int k = start; k < i; k++)
                    {
                        if (arr[k] == current)
                        {
                            start = k + 1;
                            break;
                        }
                        flag[arr[k]] = false;
                    }
                }
                else {
                    flag[current] = true;
                }
            }

            result = Math.Max(arr.Length - start, result);

            return result;
        }

        [TestMethod]
        [TestCategory("String")]
        public void Longest_Substring_Without_Repeating_Characters()
        {
            int result = 0;
            result = LengthOfLongestSubstring("abcabcbb");
            Assert.AreEqual(3, result);

            result = LengthOfLongestSubstring("bbbb");
            Assert.AreEqual(1, result);
        }
    }
}
