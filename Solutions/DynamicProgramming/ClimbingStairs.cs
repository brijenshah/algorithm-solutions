using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.DynamicProgramming
{
    // You are climbing a stair case. It takes n steps to reach to the top.
    // Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    [TestClass]
    public class ClimbingStairs
    {

        public int GetClimbStairs(int n)
        {
            return Fib(n + 1);
        }

        private int Fib(int n)
        {
            int a = 0, b = 1;

            if (n <= 0)
                return a;

            for (int i = 2; i <= n; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        [TestMethod]
        [TestCategory("DynamicProgramming")]
        public void Climbing_Stairs()
        {
            Assert.AreEqual(GetClimbStairs(4), 5);
        }

    }
}
