using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Tree
{
    // Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST/
    // “The lowest common ancestor is defined between two nodes v and w as the lowest node in T 
    // that has both v and w as descendants(where we allow a node to be a descendant of itself).”
    //
    //        _______6______
    //       /              \
    //    ___2__          ___8__
    //   /      \        /      \
    //   0      _4       7       9
    //         /  \
    //         3   5
    //
    //  For example, the lowest common ancestor(LCA) of nodes 2 and 8 is 6. 
    // Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.
   [TestClass]
    public class LowestCommonAncestor
    {
        public TreeNode GetLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode m = root;

            if (m.Data > p.Data && m.Data < q.Data)
            {
                return m;
            }
            else if (m.Data > p.Data && m.Data > q.Data)
            {
                return GetLowestCommonAncestor(root.Left, p, q);
            }
            else if (m.Data < p.Data && m.Data < q.Data)
            {
                return GetLowestCommonAncestor(root.Right, p, q);
            }

            return root;
        }

       [TestMethod]
       [TestCategory("Tree")]
       public void Lowest_Common_Ancestor()
       {
            TreeNode root = new TreeNode(6);

            TreeNode twoNode = root.Left = new TreeNode(2);
            root.Left.Left = new TreeNode(0);
            TreeNode fourNode = root.Left.Right = new TreeNode(4);

            TreeNode eightNode = root.Right = new TreeNode(8);
            root.Right.Left = new TreeNode(7);
            root.Right.Right = new TreeNode(9);

            TreeNode result1 = GetLowestCommonAncestor(root, twoNode, eightNode);
            Assert.AreEqual(result1.Data, 6);

            TreeNode result2 = GetLowestCommonAncestor(root, twoNode, fourNode);
            Assert.AreEqual(result2.Data, 2);
        }

    }
}
