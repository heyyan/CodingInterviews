using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Delete_Middle_Node
    {

        //    2.3 Delete Middle Node: Implement an algorithm to delete a node in the middle(i.e., any node but the first and last node, 
        // not necessarily the exact middle) of a singly linked list, given only access to that node.
        //EXAMPLE
        //input: the node c from the linked list a->b->c->d->e->f
        //Result: nothing is returned, but the new linked list looks like a ->b->d->e->f

        [TestMethod]
        public void Test_Delete_Middle_Node()
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

            bool node = deleteNode(linkedList);
            Assert.AreEqual(node, 1);
        }

        private Node deleteMiddle(Node linkedList)
        {
            Node first = linkedList;
            Node second = linkedList;
            Node head = null;
            int counter = 0;
            while (first.next != null)
            {
                counter++;
                first = first.next;
            }

            int mid = counter / 2;
            counter = 0;
            while (second.next != null)
            {
                if (counter == 0)
                {
                    head = second;
                    second = second.next;
                }
                else if (counter == mid)
                {
                    head.next = second.next;
                    second = second.next.next;
                }
                else
                {
                    head.next = second;
                    second = second.next;
                }
                counter++;
            }
            return head;
        }

        private bool deleteNode(Node n)
        {
            if (n == null || n.next == null)
            {
                return false; // Failure 
            }
            Node next = n.next;
            n.data = next.data;
            n.next = next.next;
            return true;
        }
    }
}
