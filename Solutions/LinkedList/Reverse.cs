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
            ListNode curr = head;

            while (curr != null)
            {
                ListNode nextTemp = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.Next == null) return head;
            ListNode p = ReverseList2(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return p;
        }

        [TestMethod]
        [TestCategory("LinkedList")]
        public void Reverse_Linked_List()
        {
            ListNode list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);

            ListNode result = ReverseList2(list);

            Assert.AreEqual(result.Data, 3 );
            Assert.AreEqual(result.Next.Data, 2);
            Assert.AreEqual(result.Next.Next.Data, 1);
        }
    }
}
