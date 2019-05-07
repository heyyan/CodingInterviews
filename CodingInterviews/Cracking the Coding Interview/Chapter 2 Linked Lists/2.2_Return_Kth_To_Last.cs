using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Return_Kth_To_Last
    {
        //2.2 Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
        [TestMethod]
        public void Test_Kth_To_Last()
        {
            Node linkedList = new Node(1);
            linkedList.appendToTail(2);
            linkedList.appendToTail(3);
            linkedList.appendToTail(4);
            linkedList.appendToTail(5);
            linkedList.appendToTail(6);
            linkedList.appendToTail(7);
            linkedList.appendToTail(8);
            linkedList.appendToTail(9);
            linkedList.appendToTail(10);

            int node = printKthToLast(linkedList, 5);
            Assert.AreEqual(node, 5);
        }

        public Node GetKth(Node list, int kth)
        {
            Node kthNode = list;
            int counter = 0;
            while (list.next != null)
            {
                counter++;
                if (counter >= kth)
                {
                    kthNode = kthNode.next;
                }
                list = list.next;
            }

            return kthNode;
        }

        private int printKthToLast(Node head, int k)
        {
            if (head == null)
            {
                return 0;
            }
            int index = printKthToLast(head.next, k) + 1;
            if (index == k)
            {
                Debug.WriteLine(k + "th to last node is " + head.data);
            }
            return index;
        }

        //Approach B: Use C ++.
        //node* nthToLast(node* head, int k, int& i)
        //{
        //    if (head == NULL)
        //    {
        //        return NULL;
        //    }
        //    node* nd = nthToLast(head->next, k, i);
        //    i = i + 1;
        //    if (i == k)
        //    {
        //        return head;
        //    }
        //    return nd;
        //}

        //node* nthToLast(node* head, int k)
        //{
        //    int i = 0;
        //    return nthToLast(head, k, i);
        //}

        //Approach C: Create a Wrapper Class.
        private class Index
        {
            public int value;
        }
        private Node kthTolast(Node head, int k)
        {
            Index idx = new Index();
            return kthToLast(head, k, idx);
        }
        private Node kthToLast(Node head, int k, Index idx)
        {
            if (head == null)
            {
                return null;
            }
            Node node = kthToLast(head.next, k, idx);
            idx.value = idx.value + 1;
            if (idx.value == k)
            {
                return head;
            }
            return node;
        }

        //The code below implements this algorithm. 
        private Node nthTolast(Node head, int k)
        {
            Node p1 = head;
            Node p2 = head;
            /* Move pl k nodes into the list.*/
            for (int i = 0; i < k; i++)
            {
                if (p1 == null)
                {
                    return null;
                }
                // Out of bounds 
                p1 = p1.next;
            }

            /* Move them at the same pace. When pl hits the end, p2 will be at the right element. */
            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            return p2;
        }
    }
}
