using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Tree
{
    // Given two binary trees, write a function to check if they are equal or not.
    // Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
    [TestClass]
    public class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == q)
                return true;

            if ((p == null) || (q == null))
                return false;

            return ((p.Data == q.Data) && IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right));
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void Same_Tree()
        {
            TreeNode t1 = new TreeNode(5);
            t1.Left = new TreeNode(4);
            t1.Right = new TreeNode(6);

            TreeNode t2 = new TreeNode(5);
            t2.Left = new TreeNode(4);
            t2.Right = new TreeNode(6);

            Assert.IsTrue(IsSameTree(t1, t2));
        }

    }
}
