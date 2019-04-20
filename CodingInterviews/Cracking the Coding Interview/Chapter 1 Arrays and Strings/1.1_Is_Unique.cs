using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodingInterviews.Cracking_the_Coding_Interview
{
    [TestClass]
    public class Is_Unique
    {
        // 1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters. 
        // What if you cannot use additional data structures?
        [TestMethod]
        public void Test_1_1_Is_Unique()
        {
            string str = "string";
            // with additional data structure
            bool isUnique = MySolution(str);

            Assert.AreEqual(isUnique, true);

            isUnique = isUniqueChars(str);

            Assert.AreEqual(isUnique, true);

            isUnique = isUniqueChars_Bitwise("strings");

            Assert.AreEqual(isUnique, false);

            // What if you cannot use additional data structures?
        }

        // My Solution
        private static bool MySolution(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                    break;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            bool isUnique = true;

            foreach (KeyValuePair<char, int> item in dict)
            {
                if (item.Value > 1)
                {
                    isUnique = false;
                    break;
                }
            }

            return isUnique;
        }

        //book solution 1
        public bool isUniqueChars(string str)
        {
            // you can safely assume that the characters are unique 
            if (str.Length > 128) //ASCII has 128 unique character, UNICODE 256
            {
                return false;
            }

            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (char_set[val])//Already found this char in string
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
        }

        // book solution 2
        public bool isUniqueChars_Bitwise(string str)
        {
            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }
            return true;
        }

    }



}
