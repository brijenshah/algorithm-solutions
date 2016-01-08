using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Array
{
    //Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
    // Note:
    //      Elements in a triplet(a, b, c) must be in non-descending order. (ie, a ≤ b ≤ c)
    //      The solution set must not contain duplicate triplets.
    // For example, given array S = { -1 0 1 2 - 1 - 4},
    // A solution set is:
    //      (-1, 0, 1)
    //      (-1, -1, 2)
    [TestClass]
    public class ThreeSum
    {
        public IList<IList<int>> GetThreeSum(int[] num)
        {
            //sort array
            System.Array.Sort(num);

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> each = new List<int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] > 0) break;

                for (int j = i + 1; j < num.Length; j++)
                {
                    if (num[i] + num[j] > 0 && num[j] > 0) break;

                    for (int k = j + 1; k < num.Length; k++)
                    {
                        if (num[i] + num[j] + num[k] == 0)
                        {

                            each.Add(num[i]);
                            each.Add(num[j]);
                            each.Add(num[k]);
                            result.Add(each);
                            each.Clear();
                        }
                    }
                }
            }

            return result;
        }

        [TestMethod]
        [TestCategory("Array")]
        public void Three_Sum()
        {
            IList<IList<int>> result = GetThreeSum(new[] {-1, 0, 1, 2, - 1, -4});

            Assert.AreEqual(result[0][0], -1);
            Assert.AreEqual(result[0][1], 0);
            Assert.AreEqual(result[0][2], 1);

            Assert.AreEqual(result[1][0], -1);
            Assert.AreEqual(result[1][1], -1);
            Assert.AreEqual(result[1][2], -2);
        }
    }
}
