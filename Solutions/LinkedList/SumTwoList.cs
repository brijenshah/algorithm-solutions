using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Definition;

namespace Solutions.LinkedList
{
    // You are given two linked lists representing two non-negative numbers.The digits are stored in reverse order 
    // and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
    // Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    // Output: 7 -> 0 -> 8
    [TestClass]
    public class SumTwoList
    {
        public ListNode AddTwoList(ListNode l1, ListNode l2)
        {
            return AddTwoList(l1, l2, 0);
        }

        private ListNode AddTwoList(ListNode l1, ListNode l2, int carry)
        {
            if(l1 == null && l2 == null && carry == 0)
            {
                return null;
            }

            ListNode result = new ListNode(carry);
            int value = carry;

            if (l1 != null) value += l1.Data;
            if (l2 != null) value += l2.Data;

            result.Data = value % 10;

            if (l1 != null || l2 != null)
            {
                ListNode more = AddTwoList(l1?.Next, l2?.Next, value >= 10 ? 1 : 0);
                result.Next = more;
            }

            return result;
        }

        private ListNode AddTwoList2(ListNode l1, ListNode l2)
        {
            int carry = 0;

            ListNode l3 = null, head = null;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    carry += l1.Data;
                    l1 = l1.Next;
                }

                if (l2 != null)
                {
                    carry += l2.Data;
                    l2 = l2.Next;
                }

                if (head == null)
                {
                    head = new ListNode(carry%10);
                    l3 = head;
                }
                else
                {
                    l3.Next = new ListNode(carry%10);
                    l3 = l3.Next;
                }
                carry /= 10;
            }

            if (carry == 1)
                if (l3 != null) l3.Next = new ListNode(1);

            return head;
        }

        [TestCategory("LinkedList")]
        [TestMethod]
        public void Sum_Two_List()
        {
            ListNode l1 = new ListNode(2);
            l1.Next = new ListNode(4);
            l1.Next.Next = new ListNode(3);

            ListNode l2 = new ListNode(5);
            l2.Next = new ListNode(6);
            l2.Next.Next = new ListNode(4);

            // for 1st method
            ListNode result = AddTwoList(l1, l2);

            Assert.AreEqual(7, result.Data);
            Assert.AreEqual(0, result.Next.Data);
            Assert.AreEqual(8, result.Next.Next.Data);

            // for 2nd method
            ListNode result2 = AddTwoList2(l1, l2);

            Assert.AreEqual(7, result2.Data);
            Assert.AreEqual(0, result2.Next.Data);
            Assert.AreEqual(8, result2.Next.Next.Data);
        }
    }
}
