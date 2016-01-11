using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Tree
{
    // Given a binary tree, find its maximum depth.
    // The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    [TestClass]
    public class MaximumDepth
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.Left == null)
                return 1 + MaxDepth(root.Right);

            if (root.Right == null)
                return 1 + MaxDepth(root.Left);

            return 1 + System.Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
        }

        [TestCategory("Tree")]
        [TestMethod]
        public void Maximum_Depth()
        {
            TreeNode t1 = new TreeNode(5);

            t1.Left = new TreeNode(4);
            t1.Left.Left = new TreeNode(3);
            t1.Left.Left.Left = new TreeNode(2);

            t1.Right = new TreeNode(6);

            Assert.AreEqual(MaxDepth(t1), 4);
        }
    }
}
