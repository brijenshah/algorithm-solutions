using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.LinkedList
{
    // Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
    // Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, 
    // the linked list should become 1 -> 2 -> 4 after calling your function.
    [TestClass]
    public class DeleteNode
    {
        public void DeleteListNode(ListNode node)
        {
            // tail node
            if (node.Next == null) return;

            ListNode temp = node.Next;
            node.Data = temp.Data;
            node.Next = temp.Next;
        }

        [TestMethod]
        [TestCategory("LinkedList")]
        public void Delete_Linked_List_Node()
        {
            ListNode l = new ListNode(1);
            l.Next = new ListNode(2);
            ListNode thirdNode = l.Next.Next = new ListNode(3);
            l.Next.Next.Next = new ListNode(4);

            DeleteListNode(thirdNode);

            Assert.AreEqual(l.Data, 1);
            Assert.AreEqual(l.Next.Data, 2);
            Assert.AreEqual(l.Next.Next.Data, 4);

        }
    }
}
