using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class URLify
    {
        // URLify: Write a method to replace all spaces in a string with '%20'.You may assume that the string
        // has sufficient space at the end to hold the additional characters, and that you are given the "true"
        // length of the string. (Note: if implementing in Java, please use a character array so that you can
        // perform this operation in place.)
        // EXAMPLE
        // Input: "Mr John Smith ", 13
        // Output: "Mr%20John%20Smith"
        [TestMethod]
        public void Test_URLify()
        {
            string input = "Mr John Smith ";
            string output = URLify_Str(input);
            Assert.AreEqual(output, "Mr%20John%20Smith");
            char[] inp = input.ToCharArray();
            replaceSpaces(inp, input.Length);
            Assert.AreEqual(inp.ToString(), "Mr%20John%20Smith");
        }

        // MY SOLUTION
        public string URLify_Str(string str)
        {
            string newS = str.Trim();
            StringBuilder strB = new StringBuilder();
            foreach (char c in newS)
            {
                if (c == ' ')
                {
                    strB.Append("%20");
                }
                else
                {
                    strB.Append(c);
                }
            }

            return strB.ToString();
        }

        //BOOK SOLUTION there seem to be a bug here
        public void replaceSpaces(char[] str, int trueLength)
        {
            int spaceCount = 0, index, i = 0;
            for (i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }
            index = trueLength + spaceCount * 2; // this should have been used to extend the array size
            if (trueLength < str.Length)
            {
                str[trueLength] = '\0'; // End array
            }
            for (i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }
    }
}
