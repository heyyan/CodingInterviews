using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chapter_2_Linked_Lists
{
    [TestClass]
    public class Intersection
    {
        // 2.7 Intersection: Given two(singly) linked lists, determine if the two lists intersect.Return the intersecting node.Note that 
        // the intersection is defined based on reference, not value. That is, if the kth node of the first linked list is the exact 
        // same node (by reference) as the jth node of the second linked list, then they are intersecting.

        [TestMethod]
        public void Test_Intersection()
        {
            LinkedListNode LL1 = new LinkedListNode(7);
            LinkedListNode N1 = new LinkedListNode(7);
            LinkedListNode N2 = new LinkedListNode(7);
            LinkedListNode N3 = new LinkedListNode(7);
            LL1.next = N1;
            N1.next = N2;
            N2.next = N3;

            LinkedListNode LL2 = new LinkedListNode(7);
            LinkedListNode M1 = new LinkedListNode(7);           
            LinkedListNode M3 = new LinkedListNode(7);
            LL2.next = M1;
            M1.next = M3;
            M3.next = N2;
            bool intersect = doIntersect(LL1, LL2);
            Assert.AreEqual(true,true);
        }

        private bool doIntersect(LinkedListNode lL1, LinkedListNode lL2)
        {
            throw new NotImplementedException();
        }
    }
}
