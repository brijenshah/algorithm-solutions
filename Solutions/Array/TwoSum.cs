using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Given an array of integers, find two numbers such that they add up to a specific target number.
    // The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are not zero-based.
    // You may assume that each input would have exactly one solution.
    // Input: numbers={2, 7, 11, 15}, target=9
    // Output: index1=1, index2=2
    [TestClass]
    public class TwoSum
    {
        public int[] GetTwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new[] { -1, -1 };

            IDictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                int n = nums[i];
                if (map.ContainsKey(n))
                    return new[] { map[n], i + 1 };

                if (!map.ContainsKey(target - n))
                    map.Add(target - n, i + 1);
            }

            return new[] { -1, -1 };
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Two_Sum()
        {
            int[] nums = {2, 7, 11, 15};
            int target = 9;

            int[] result = GetTwoSum(nums, target);
            
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 2);
        }
    }
}
