using System;
using System.Collections.Generic;
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
                    result = System.Math.Max(result, i - start);
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

            result = System.Math.Max(arr.Length - start, result);

            return result;
        }

        public static int LengthOfLongestSubstring2(string s)
        {
            if (s == null)
                return 0;
            char[] arr = s.ToCharArray();
            int pre = 0;

            IDictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], i);
                }
                else {
                    pre = System.Math.Max(pre, map.Count);
                    i = map[arr[i]];
                    map.Clear();
                }
            }

            return System.Math.Max(pre, map.Count);
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

            // Approach 2
            result = LengthOfLongestSubstring2("abcabcbb");
            Assert.AreEqual(3, result);

            result = LengthOfLongestSubstring2("bbbb");
            Assert.AreEqual(1, result);

        }
    }
}
