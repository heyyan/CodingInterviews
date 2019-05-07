using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Sum_Lists
    {
        // 2.5 Sum Lists: You have two numbers represented by a linked list, where each node contains a single digit. The digits are stored 
        // in reverse order, such that the 1 's digit is at the head of the list. Write a function that adds the two numbers and returns 
        // the sum as a linked list. 
        // EXAMPLE
        // Input: (7-> 1 -> 6) + (5 -> 9 -> 2). That is,617 + 295. 
        // Output: 2 -> 1 -> 9. That is, 912. 
        // FOLLOW UP
        // Suppose the digits are stored in forward order.Repeat the above problem.
        // Input: (6 -> 1 -> 7) + (2 -> 9 -> 5). That is,617 + 295. 
        // Output: 9 -> 1 -> 2. That is, 912.

        [TestMethod]
        public void Test_Sum_List()
        {
            LinkedListNode linkedList1 = new LinkedListNode(7);
            linkedList1.setNext(new LinkedListNode(1));
            linkedList1.setNext(new LinkedListNode(6));

            LinkedListNode linkedList2 = new LinkedListNode(5);
            linkedList2.setNext(new LinkedListNode(9));
            linkedList2.setNext(new LinkedListNode(2));


            LinkedListNode node = addLists(linkedList1, linkedList2);
            Assert.AreEqual(node.data, 912);
        }

        private int SunList(LinkedListNode linkedList1, LinkedListNode linkedList2)
        {
            while (true)
            {

            }
        }

        private LinkedListNode addLists(LinkedListNode l1, LinkedListNode l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return null;
            }

            LinkedListNode result = new LinkedListNode();
            int value = carry;
            if (l1 != null)
            {
                value += l1.data;
            }

            if (l2 != null)
            {
                value += l2.data;
            }

            result.data = value % 10; /* Second digit of number */

            /* Recurse */
            if (l1 != null || l2 != null)
            {
                LinkedListNode more = addLists(l1 == null ? null : l1.next,
                                               l2 == null ? null : l2.next,
                                               value >= 10 ? 1 : 0);
                result.setNext(more);
            }


            if (l1 != null || l2 != null)
            {
                LinkedListNode more = addLists(l1 == null ? null : l1.next,
                                    l2 == null ? null : l2.next,
                                    value >= 10 ? 1 : 0);
                result.setNext(more);
            }
            return result;
        }

        private class PartialSum
        {
            public LinkedListNode sum = null;
            public int carry = 0;
        }

        private LinkedListNode addLists(LinkedListNode l1, LinkedListNode l2)
        {
            int len1 = length(l1);
            int len2 = length(l2);
            /* Pad the shorter list with zeros - see note (1) */
            if (len1 < len2)
            {
                l1 = padList(l1, len2 - len1);
            }
            else
            {
                l2 = padList(l2, len1 - len2);
            }

            /* Add lists */
            PartialSum sum = addListsHelper(l1, l2);
            /* If there was a carry value left over, insert this at the front of the list. 
             * * Otherwise, just return the linked list. */
            if (sum.carry == 0)
            {
                return sum.sum;
            }
            else
            {
                LinkedListNode result = insertBefore(sum.sum, sum.carry);
                return result;
            }
        }

        private PartialSum addListsHelper(LinkedListNode l1, LinkedListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                PartialSum sum1 = new PartialSum();
                return sum1;
            }
            /* Add smaller digits recursively*/
            PartialSum sum = addListsHelper(l1.next, l2.next);
            /* Add carry to current data*/
            int val = sum.carry + l1.data + l2.data;
            /* Insert sum of current digits*/
            LinkedListNode full_result = insertBefore(sum.sum, val % 10);
            /* Return sum so far, and the carry value*/
            sum.sum = full_result;
            sum.carry = val / 10;
            return sum;
        }

        /* Pad the list with zeros*/
        private LinkedListNode padList(LinkedListNode l, int padding)
        {
            LinkedListNode head = l;
            for (int i = 0; i < padding; i++)
            {
                head = insertBefore(head, 0);
            }
            return head;
        }

        /* Helper function to insert node in the front of a linked list*/
        private LinkedListNode insertBefore(LinkedListNode list, int data)
        {
            LinkedListNode node = new LinkedListNode(data);
            if (list != null)
            {
                node.next = list;
            }
            return node;
        }

        public int length(LinkedListNode l1)
        {
            LinkedListNode temp = l1;
            int cnt = 0;
            while (temp != null)
            {
                cnt++;
                temp = temp.next;
            }
            return cnt;

        }
    }
}
