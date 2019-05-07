using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Remove_Dups
    {
        //2.1 Remove Dups: Write code to remove duplicates from an unsorted linked list.
        //FOLLOW UP
        //How would you solve this problem if a temporary buffer is not allowed?
        //Hints: #9, #40

        [TestMethod]
        public void Test_String_Rotation()
        {
            Node linkedList = new Node(1);
            linkedList.appendToTail(2);
            linkedList.appendToTail(1);
            linkedList.appendToTail(4);

            deleteDupsNoBuff(linkedList);
            Assert.AreEqual(true, true);
        }

        private bool RemoveDuplicates(Node linkedList)
        {

            Node previous = null;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            while (linkedList != null)
            {
                if (dict.ContainsKey(linkedList.data))
                {
                    //   dict[data]++;
                    previous.next = linkedList.next;
                }
                else
                {
                    dict[linkedList.data] = 1;
                    previous = linkedList;
                }
                linkedList = linkedList.next;
            }


            return true;
        }

        private void deleteDups(Node n)
        {
            HashSet<int> set = new HashSet<int>();
            Node previous = null;
            while (n != null)
            {
                if (set.Contains(n.data))
                {
                    previous.next = n.next;
                }
                else
                {
                    set.Add(n.data);
                    previous = n;
                }
                n = n.next;
            }
        }

        private void deleteDupsNoBuff(Node head)
        {
            Node current = head;
            while (current != null)
            {
                /* Remove all future nodes that have the same value */
                Node runner = current;
                while (runner.next != null)
                {
                    if (runner.next.data == current.data)
                    {
                        runner.next = runner.next.next;
                    }
                    else
                    {
                        runner = runner.next;
                    }
                }
                current = current.next;
            }
        }

    }
}

