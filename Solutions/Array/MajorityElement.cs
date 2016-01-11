using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Given an array of size n, find the majority element. The majority element is the element that appears more than n/2 times.
    // You may assume that the array is non-empty and the majority element always exist in the array
    [TestClass]
    public class MajorityElement
    {
        public int GetMajorityElement(int[] num)
        {
            if (num.Length == 1)
            {
                return num[0];
            }

            System.Array.Sort(num);
            return num[num.Length / 2];
        }

        public int GetMajorityElement2(int[] nums)
        {
            int result = 0, count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    result = nums[i];
                    count = 1;
                }
                else if (result == nums[i])
                {
                    count++;
                }
                else {
                    count--;
                }
            }

            return result;
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Majority_Element()
        {
            int[] nums = {1, 1, 3, 3, 3, 3, 3, 2, 2, 2};

            Assert.AreEqual(GetMajorityElement(nums), 3);
            Assert.AreEqual(GetMajorityElement2(nums), 3);
        }
    }
}
