using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class String_Compression
    {
        // 1.6 String Compression: Implement a method to perform basic string compression using the counts of repeated characters.
        // For example, the string aabcccccaaa would become a2b1c5a3.If the "compressed" string would not become smaller than the 
        // original string, your method should return the original string. You can assume the string has only 
        // uppercase and lowercase letters (a -z).

        [TestMethod]
        public void Test_One_Away()
        {
            string input = "aabcccccaaa";
            string output = compress2(input);
            Assert.AreEqual(output, "a2b1c5a3");
        }

        #region MYSolution

        private string stringCompression(string input)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                int count = 1;
                for (int j = i + 1; j < input.Length; j++)
                {
                    char d = input[j];
                    if (c != d)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                i = i + count - 1;
                if (count >= 1)
                {
                    builder.Append($"{c}{count}");
                }
                else
                {
                    builder.Append($"{c}");
                }

            }

            return builder.ToString();
        }

        #endregion


        // book 
        private string compressBad(string str)
        {
            string compressedString = "";
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedString += "" + str[i] + countConsecutive;
                    countConsecutive = 0;
                }
            }
            return compressedString.Length < str.Length ? compressedString : str;
        }

        private string compress(string str)
        {
            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return compressed.Length < str.Length ? compressed.ToString() : str;
        }

        private string compress2(string str)
        {
            /* Check final length and return input string if it would be longer. */
            int finalLength = countCompression(str);
            if (finalLength >= str.Length)
            {
                return str;
            }

            StringBuilder compressed = new StringBuilder(finalLength);
            // initial capacity 
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                /* If next character is different than current, append this char to result.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return compressed.ToString();
        }

        private int countCompression(string str)
        {
            int compressedlength = 0;
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                /* If next character is different than current, increase the length.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedlength += 1 + Convert.ToString(countConsecutive).Length;
                    countConsecutive = 0;
                }
            }
            return compressedlength;
        }
    }
}
