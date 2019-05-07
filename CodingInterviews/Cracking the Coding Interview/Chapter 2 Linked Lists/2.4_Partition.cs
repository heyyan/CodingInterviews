using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Partition
    {
        // 2.4 Partition: Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes 
        // greater than or equal to x. If x is contained within the list the values of x only need to be after the elements less than 
        // x(see below). The partition element x can appear anywhere in the "right partition"; it does not need to appear between the 
        // left and right partitions.
        // EXAMPLE
        // Input: 3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5]
        // Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8 [WRONG AND CONFUSING]
        // CORRECT OUTPUT: 1 -> 2 -> 5 -> 8 -> 5 -> 10



        [TestMethod]
        public void Test_Partition()
        {
            Node linkedList = new Node(3);
            linkedList.appendToTail(5);
            linkedList.appendToTail(8);
            linkedList.appendToTail(5);
            linkedList.appendToTail(10);
            linkedList.appendToTail(2);
            linkedList.appendToTail(1);

            Node node = partitionN(linkedList, 5);
            Assert.AreEqual(node, 1);
        }

        #region MY8
        private Node PartitionNodes(Node linkedList, int index)
        {
            int indexValue = 0;
            Node head = linkedList;
            Node Left = null;
            Node Right = null;
            int counter = 1;
            while (head.next != null)
            {
                if (counter == index)
                {
                    indexValue = head.data;
                    break;
                }
                counter++;
                head = head.next;
            }

            head = linkedList;

            while (head.next != null)
            {
                if (head.data > indexValue)
                {
                    if (Right == null)
                    {
                        Right = head;
                    }
                    else
                    {
                        Right.next = head;
                    }
                }
                else
                {
                    if (Left == null)
                    {
                        Left = head;
                    }
                    else
                    {
                        Left.next = head;
                    }
                }
                head = head.next;
            }

            Node returnNode = null;
            while (Left.next != null)
            {
                if (returnNode == null)
                {
                    returnNode = Left;
                }
                else
                {
                    returnNode.next = Left;
                }
                Left = Left.next;
            }

            while (Right.next != null)
            {
                if (returnNode == null)
                {
                    returnNode = Right;
                }
                else
                {
                    returnNode.next = Right;
                }
                Right = Right.next;
            }
            return returnNode;
        }
        #endregion

        /* Pass in the head of the linked list and the value to partition around*/
        private Node partitionNode(Node node, int x)
        {
            Node beforeStart = null;
            Node beforeEnd = null;
            Node afterStart = null;
            Node afterEnd = null;
            /* Partition list*/
            while (node != null)
            {
                Node next = node.next;
                node.next = null;
                if (node.data < x)
                {
                    /* Insert node into end of before list*/
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.next = node;
                        beforeEnd = node;
                    }

                }
                else
                {
                    /* Insert node into end of after list */
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.next = node;
                        afterEnd = node;
                    }
                }
                node = next;
            }
            if (beforeStart == null)
            {
                return afterStart;
            }

            /* Merge before list and after list */
            beforeEnd.next = afterStart;
            return beforeStart;

        }

        private Node partitionN(Node node, int x)
        {
            Node head = node;
            Node tail = node;
            while (node != null)
            {
                Node next = node.next;
                if (node.data < x)
                {
                    /* Insert node at head. */
                    node.next = head;
                    head = node;
                }
                else
                {
                    /* Insert node at tail. */
                    tail.next = node;
                    tail = node;
                }
                node = next;
            }
            tail.next = null;
            // The head has changed, so we need to return it to the user. 
            return head;
        }
    }
}
