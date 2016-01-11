using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.LinkedList
{
    // Given a sorted linked list, delete all duplicates such that each element appear only once.
    // For example,
    //      Given 1->1->2, return 1->2.
    //      Given 1->1->2->3->3, return 1->2->3.
    [TestClass]
    public class RemoveDuplicates
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode p = head;

            while (p != null && p.Next != null)
            {
                if (p.Data == p.Next.Data)
                    p.Next = p.Next.Next;
                else
                    p = p.Next;
            }

            return head;
        }

        [TestMethod]
        [TestCategory("LinkedList")]
        public void Delete_Duplicates()
        {
            ListNode l1 = new ListNode(1);
            l1.Next = new ListNode(1);
            l1.Next.Next = new ListNode(2);

            ListNode r1 = DeleteDuplicates(l1);
            Assert.AreEqual(r1.Data, 1);
            Assert.AreEqual(r1.Next.Data, 2);
        }
    }
}
