using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.Tree
{
    [TestClass]
    public class Traversals
    {
        /** Traverses the tree in a pre-order approach, starting from the specified node. */
        public void Preorder(TreeNode node)
        {
            if (node != null)
            {
                Debug.Write(node.Data + " ");
                Preorder(node.Left);
                Preorder(node.Right);
            }
        }

        /** Iteratively traverses the binary tree in pre-order */
        public void IterativePreOrder(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                TreeNode current = stack.Pop();
                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
                Debug.Write(current.Data + " ");
            }
        }

        /** Traverses the tree in a in-order approach, starting from the specified node. */
        private void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Debug.Write(node.Data + " ");
                InOrder(node.Right);
            }
        }

        /** Iteratively traverses the binary tree in in-order */
        public void IterativeInOrder(TreeNode root)
        {
            TreeNode node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (stack.Any() || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    Debug.Write(node.Data + " ");
                    node = node.Right;
                }
            }
        }

        /** Traverses the tree in a post-order approach, starting from the specified node. */
        public void PostOrder(TreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Debug.Write(node.Data + " ");
            }
        }

        /** Iteratively traverses the binary tree in post-order */
        public void IterativePostOrder(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (true)
            {

                if (current != null)
                {
                    if (current.Right != null) stack.Push(current.Right);
                    stack.Push(current);
                    current = current.Left;
                    continue;
                }

                if (!stack.Any()) return;
                current = stack.Pop();

                if (current.Right != null && stack.Any() && current.Right == stack.Peek())
                {
                    stack.Pop();
                    stack.Push(current);
                    current = current.Right;
                }
                else
                {
                    Debug.Write(current.Data + " ");
                    current = null;
                }
            }
        }


    }
}
