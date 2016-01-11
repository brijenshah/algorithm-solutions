using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Tree
{
    // Invert a binary tree.
    //       4
    //     /   \
    //    2     7
    //   / \   / \
    //  1   3 6   9
    //
    //      to
    //
    //       4
    //     /   \
    //    7     2
    //   / \   / \
    //  9   6 3   1
    [TestClass]
    public class Invert
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                Invert_Tree(root);
            }
            return root;
        }

        public void Invert_Tree(TreeNode root)
        {
            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            if (root.Left != null)
                Invert_Tree(root.Left);

            if (root.Right != null)
                Invert_Tree(root.Right);
        }

        [TestMethod]
        [TestCategory("Tree")]
        public void Invert_Tree()
        {
            TreeNode root = new TreeNode(4);

            root.Left = new TreeNode(2);
            root.Left.Left = new TreeNode(1);
            root.Left.Right = new TreeNode(3);

            root.Right = new TreeNode(7);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(9);

            TreeNode result = InvertTree(root);

            Assert.AreEqual(result.Data, 4);
            Assert.AreEqual(result.Left.Data , 7);
            Assert.AreEqual(result.Right.Data, 2);
            Assert.AreEqual(result.Left.Left.Data , 9);
            Assert.AreEqual(result.Right.Right.Data, 1);
        }
    }
}
