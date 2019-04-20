using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class One_Away
    {

        // 1.5 One Away: There are three types of edits that can be performed on strings: 
        // insert a character, 
        // remove a character, 
        // or replace a character.
        // Given two strings, write a function to check if they are one edit (or zero edits) away.
        //EXAMPLE
        //pale, ple -> true 
        //pales, pale -> true 
        //pale, bale -> true 
        //pale, bae -> false

        [TestMethod]
        public void Test_One_Away()
        {
            string input = "pale";
            string output = "ple";
            bool val = oneEditAway2(input, output);
            Assert.AreEqual(val, true);

            input = "pales";
            output = "pale";
            val = oneEditAway2(input, output);
            Assert.AreEqual(val, true);

            input = "pale";
            output = "bale";
            val = oneEditAway2(input, output);
            Assert.AreEqual(val, true);

            input = "pale";
            output = "bae";
            val = oneEditAway2(input, output);
            Assert.AreEqual(val, false);
        }

        #region MySolution
        // MY SOLUTION IS SOOO INCORRECT
        // my solution. when it dought use a hashtable
        private bool isOneWay(string input, string output)
        {
            if (input == output) // are identical.
            {
                return false;
            }
            if (Math.Abs(input.Length - output.Length) > 1)
            {
                return false;
            }

            if (input.Length == output.Length)
            {
                return sameLenght(input, output);
            }
            else
            {
                return notSameLength(input, output);
            }



        }

        private bool notSameLength(string input, string output)
        {

            int diff = 0;
            for (int i = 0, j = 0; i < input.Length && j < output.Length; i++)
            {
                if (input[i] == output[j])
                {
                    j++;
                    continue;
                }
                else
                {
                    diff++;
                }
                if (diff > 1)
                {
                    return false;
                }

            }
            if (diff > 1)
            {
                return false;
            }
            return true;
        }

        private bool sameLenght(string input, string output)
        {
            int diff = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == output[i])
                {
                    continue;
                }
                else
                {
                    diff++;
                }
                if (diff > 1)
                {
                    return false;
                }

            }
            if (diff > 1)
            {
                return false;
            }
            return true;
        }

        #endregion

        // book solution
        private bool oneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return oneEditReplace(first, second);
            }
            else if (first.Length + 1 == second.Length)
            {
                return oneEditinsert(first, second);
            }
            else if (first.Length - 1 == second.Length)
            {
                return oneEditinsert(second, first);
            }
            return false;
        }

        private bool oneEditReplace(string sl, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < sl.Length; i++)
            {
                if (sl[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        return false;
                    }
                    foundDifference = true;
                }
            }
            return true;
        }

        /* Check if you can insert a character into sl to make s2. */
        private bool oneEditinsert(string sl, string s2)
        {
            int indexl = 0;
            int index2 = 0;
            while (index2 < s2.Length && indexl < sl.Length)
            {
                if (sl[indexl] != s2[index2])
                {
                    if (indexl != index2)
                    {
                        return false;
                    }
                    index2++;
                }
                else
                {
                    indexl++;
                    index2++;
                }
            }
            return true;
        }



        /* Second solution */
        private bool oneEditAway2(string first, string second)
        {
            /* Length checks. */
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            /* Get shorter and longer string.*/
            string sl = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;
            int indexl = 0;
            int index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && indexl < sl.Length)
            {
                if (sl[indexl] != s2[index2])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference)
                    {
                        return false;
                    }

                    foundDifference = true;
                    if (sl.Length == s2.Length)
                    {
                        //On replace, move shorter pointer 
                        indexl++;
                    }
                }
                else
                {
                    indexl++; // If matching, move shorter pointer 
                }
                index2++; // Always move pointer for longer string 
            }
            return true;
        }
    }
}