using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Palinedrome
    {
        // 2.6 Palindrome: Implement a function to check if a linked list is a palindrome.

        [TestMethod]
        public void Test_Sum_List()
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.AddFirst(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.AddLast(2);
            ll.AddLast(1);

            //bool ispara = Paline(ll);



            LinkedListNode linkedList1 = new LinkedListNode(7);
            linkedList1.setNext(new LinkedListNode(1));
            linkedList1.setNext(new LinkedListNode(6));
            linkedList1.setNext(new LinkedListNode(1));
            linkedList1.setNext(new LinkedListNode(7));
            bool ispara = isPalindrome1(linkedList1);
            Assert.AreEqual(ispara, true);
        }

        private bool Paline(LinkedList<int> ll)
        {
            StringBuilder sp = new StringBuilder();
            foreach (int item in ll)
            {
                sp.Append(item);
            }

            string forwa = sp.ToString();
            StringBuilder sp2 = new StringBuilder();
            for (int i = sp.Length - 1; i >= 0; i--)
            {
                sp2.Append(sp[i]);
            }

            return forwa == sp2.ToString();
        }

        private bool isPalindrome1(LinkedListNode head)
        {
            LinkedListNode reversed = reverseAndClone(head);
            return isEqual(head, reversed);
        }

        private LinkedListNode reverseAndClone(LinkedListNode node)
        {
            LinkedListNode head = null;
            while (node != null)
            {
                LinkedListNode n = new LinkedListNode(node.data);
                node = node.next;
            }
            return head;
        }

        private bool isEqual(LinkedListNode one, LinkedListNode two)
        {
            while (one != null && two != null)
            {
                if (one.data != two.data)
                {
                    return false;
                }
                one = one.next;
                two = two.next;
            }
            return one == null && two == null;
        }

        private bool isPalindrome2(LinkedListNode head)
        {
            LinkedListNode fast = head;
            LinkedListNode slow = head;
            Stack<int> stack = new Stack<int>();
            /* Push elements from first half of linked list onto stack. When fast runner 
             * (which is moving at 2x speed) reaches the end of the linked list, then we  *
             * know we're at the middle*/
            while (fast != null && fast.next != null)
            {
                stack.Push(slow.data);
                slow = slow.next;
                fast = fast.next.next;
            }
            /* Has odd number of elements, so skip the middle element*/
            if (fast != null)
            {
                slow = slow.next;
            }
            while (slow != null)
            {
                int top = stack.Pop();
                /* If values are different, then it's not a palindrome*/
                if (top != slow.data)
                {
                    return false;
                }
                slow = slow.next;
            }
            return true;
        }

        class Result
        {
            public LinkedListNode node;
            public bool result;
            public Result(LinkedListNode n, bool r)
            {
                node = n;
                result = r;
            }
        }

        bool isPalindrome3(LinkedListNode head)
        {
            int length = lengthOflist(head);
            Result p = isPalindromeRecurse(head, length);
            return p.result;
        }

        private int lengthOflist(LinkedListNode head)
        {
            throw new NotImplementedException();
        }

        Result isPalindromeRecurse(LinkedListNode head, int length)
        {
            if (head == null || length <= 0)
            {
                //Even number of nodes 
                return new Result(head, true);
            } else if (length == 1)
            {
                // Odd number of nodes 
                return new Result(head.next, true);
            }
            /* Recurse on sublist. */
            Result res = isPalindromeRecurse(head.next, length - 2);
            /* If child calls are not a palindrome, pass back up 
             * a failure. */
            if (!res.result || res.node == null)
            {
                return res;
            }
            /* Check if matches corresponding node on other side. */
             res.result = (head.data == res.node.data);
            /* Return corresponding node. */
            res.node = res.node.next;
            return res;
        }

        int lengthOfList(LinkedListNode n)
        {
            int size = 0;
            while (n != null) {
                size++;
                n = n.next;
            }
            return size;
        }

        //bool isPalindromeRecurse(Node head, int length, Node** next)
        //{
        //}

    }

}
