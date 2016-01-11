using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    // Given an array of integers, find if the array contains any duplicates. 
    // Your function should return true if any value appears at least twice in the array, 
    // and it should return false if every element is distinct.
    [TestClass]
    public class ContainsDuplicate
    {
        public bool IsDuplicate(int[] nums)
        {

            if (nums == null || nums.Length == 0) return false;

            HashSet<int> map = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!map.Add(num))
                    return true;
            }

            return false;
        }

        [TestCategory("Array")]
        [TestMethod]
        public void Contains_Duplicate()
        {
            Assert.IsFalse(IsDuplicate(new[] { 1, 2, 3 }));
            Assert.IsTrue(IsDuplicate(new[] { 1, 2, 3, 1 }));
        }
    }
}
