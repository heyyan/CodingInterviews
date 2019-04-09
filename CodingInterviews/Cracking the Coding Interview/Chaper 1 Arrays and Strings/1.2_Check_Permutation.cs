using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class Check_Permutation
    {
        //Given two strings, write a method to decide if one is a permutation of the other. Hints

        [TestMethod]
        public void Test_Check_Permutation()
        {
            string str0 = "string";
            string str1 = "rtings";
            //bool isUnique = isPermutaion(str0, str1);
            //Assert.AreEqual(isUnique, true);

            // solution 1
            bool isUnique = permutation_Sort(str0, str1);
            Assert.AreEqual(isUnique, true);

            // solution 2
            isUnique = permutation_Char_Count(str0, str1);
            Assert.AreEqual(isUnique, true);

        }

        // my soultion is incorrect because i assumed that two string with different lenght can be permutations
        // i that that it ment that one string is contained in an other
        public bool isPermutaion(string str1, string str2)
        {
            string larger, small = "";
            if (str1.Length > str2.Length)
            {
                larger = str1;
                small = str2;
            }
            else
            {
                larger = str2;
                small = str1;
            }

            char first = small[0];
            bool match = true;
            for (int i = 0; i < larger.Length; i++)
            {
                char c = larger[i];
                if (c != first)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < small.Length; j++)
                    {
                        if (small[j] != larger[j + i])
                        {
                            match = false;
                            break;
                        }
                    }
                }
                if (match)
                {
                    return true;
                }
            }

            return false;
        }

        // books solutions
        //Solution #1: Sort the strings. 

        private string sort(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        private bool permutation_Sort(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            return sort(s).Equals(sort(t));
        }

        //Solution #2: Check if the two strings have identical character counts. 
        private bool permutation_Char_Count(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] letters = new int[128]; // Assumption ASCII has 128 unique character, UNICODE 256
            char[] s_array = s.ToCharArray();
            foreach (char c in s_array)// count number of each char in s.
            {
                letters[c]++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                int c = t[i];
                letters[c]--;
                if (letters[c] < 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
