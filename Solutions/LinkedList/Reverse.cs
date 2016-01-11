using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.LinkedList
{
    // Reverse a singly linked list.
    [TestClass]
    public class Reverse
    {
        public ListNode ReverseList(ListNode head)
        {

            ListNode prev = null;
            ListNode curr = null;
            ListNode next = head;

            while (next != null)
            {
                curr = next;
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
            }

            return curr;
        }

        [TestMethod]
        [TestCategory("LinkedList")]
        public void Reverse_Linked_List()
        {
            ListNode list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);

            ListNode result = ReverseList(list);

            Assert.AreEqual(result.Data, 3 );
            Assert.AreEqual(result.Next.Data, 2);
            Assert.AreEqual(result.Next.Next.Data, 1);
        }
    }
}
