using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.LinkedList
{
    // Write code to partition a linked list around a value x, 
    // such that all nodes less than x come before all nodes greater than or equal to
    [TestClass]
    public class Partition
    {
        public ListNode PartitionList(ListNode node, int x)
        {
            ListNode head = node;
            ListNode tail = node;

            /* Partition list */
            while (node != null)
            {
                ListNode next = node.Next;
                if (node.Data < x)
                {
                    /* Insert node at head. */
                    node.Next = head;
                    head = node;
                }
                else
                {
                    /* Insert node at tail. */
                    tail.Next = node;
                    tail = node;
                }
                node = next;
            }
            tail.Next = null;

            return head;
        }

        [TestMethod]
        [TestCategory("LinkedList")]
        public void Partition_List()
        {
            ListNode head = new ListNode(5);
            head.Next = new ListNode(4);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(2);
            head.Next.Next.Next.Next = new ListNode(1);
            head.Next.Next.Next.Next.Next = new ListNode(0);

            ListNode result = PartitionList(head, 3);

            Assert.AreEqual(result.Data, 0);
            Assert.AreEqual(result.Next.Data, 1);
            Assert.AreEqual(result.Next.Next.Data, 2);
            Assert.AreEqual(result.Next.Next.Next.Data, 5);
            Assert.AreEqual(result.Next.Next.Next.Next.Data, 4);
            Assert.AreEqual(result.Next.Next.Next.Next.Next.Data, 3);

        }
    }
}
