using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.String
{
    // Given a string S, find the longest palindromic substring in S. 
    // You may assume that the maximum length of S is 1000, 
    // and there exists one unique longest palindromic substring.
    [TestClass]
    public class LongestPalindromicString
    {
        public string GetLongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            if (s.Length == 1)
            {
                return s;
            }

            string longest = s.Substring(0, 1);
            for (int i = 0; i < s.Length; i++)
            {
                // get longest palindrome with center of i
                string tmp = Helper(s, i, i);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }

                // get longest palindrome with center of i, i+1
                tmp = Helper(s, i, i + 1);
                if (tmp.Length > longest.Length)
                {
                    longest = tmp;
                }
            }

            return longest;
        }

        // Given a center, either one letter or two letter, 
        // Find longest palindrome
        private string Helper(string s, int begin, int end)
        {
            while (begin >= 0 && end <= s.Length - 1 && s[begin] == s[end])
            {
                begin--;
                end++;
            }
            return s.Substring(begin + 1, end - begin - 1);
        }

        [TestMethod]
        [TestCategory("String")]
        public void Longest_Palindromic_String()
        {
            Assert.AreEqual(GetLongestPalindrome("abcbab"), "abcba");
        }
    }
}
