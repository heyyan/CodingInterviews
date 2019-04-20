using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class String_Rotation
    {
        [TestMethod]
        public void Test_String_Rotation()
        {
          
            var isrotate = isRotation("waterbottle", "erbottlewat");
            Assert.AreEqual(isrotate, true);
        }
        bool isRotation(String s1, String s2)
        {
            int len = s1.Length;
            /* Check that sl and s2 are equal length and not empty*/
            if (len == s2.Length && len > 0)
            {
                /* Concatenate s1 and s1 within new buffer */
                string s1s1 = s1 + s1;
                return s1s1.Contains(s2);
            }
            return false;
        }
    }
}
