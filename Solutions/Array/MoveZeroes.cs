using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
    // For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be[1, 3, 12, 0, 0].
    [TestClass]
    public class MoveZeroes
    {
        public void MoveZeroesInArray(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j++] = nums[i];
                }
            }

            for (int i = j; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Move_Zeroes()
        {
            int[] nums = new[] {0, 1, 0, 3, 12};
            MoveZeroesInArray(nums);
            Assert.AreEqual(nums[0], 1);
            Assert.AreEqual(nums[1], 3);
            Assert.AreEqual(nums[2], 12);
            Assert.AreEqual(nums[3], 0);
            Assert.AreEqual(nums[4], 0);
        }
    }
}
