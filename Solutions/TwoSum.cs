using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions
{
    [TestClass]
    public class TwoSum
    {
        public int[] GetTwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new[] { 0, 0 };

            IDictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                int n = nums[i];
                if (map.ContainsKey(n))
                    return new[] { map[n], i + 1 };

                if (!map.ContainsKey(target - n))
                    map.Add(target - n, i + 1);
            }

            return new[] { 0, 0 };
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
