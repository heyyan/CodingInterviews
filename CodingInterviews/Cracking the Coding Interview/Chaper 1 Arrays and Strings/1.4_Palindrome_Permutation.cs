using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class Palindrome_Permutation
    {
        // Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
        // A palindrome is a word or phrase that is the same forwards and backwards.A permutation is a rearrangement of letters.
        // The palindrome does not need to be limited to just dictionary words.
        // EXAMPLE 
        // Input: Tact Coa 
        // Output: True (permutations: "taco cat", "atco eta", etc.)
        [TestMethod]
        public void Test_Palindrome_Permutation()
        {
            string input = "taco cat";
            string output = "atco cta";
            bool val = isPermutation(input, output);
            Assert.AreEqual(val, true);

            val = isPermutationOfPalindrome3(output);
            Assert.AreEqual(val, true);

        }

        // my approch
        public bool isPermutation(string input, string output)
        {
            // Histogram approch
            Dictionary<char, int> dict = new Dictionary<char, int>();

            // setup defaults
            foreach (char c in input)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            foreach (char c in output)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]--;
                }
                else
                {
                    return false;
                }
            }
            foreach (KeyValuePair<char, int> item in dict)
            {
                if (item.Value > 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Book Solution
        // Solution 1
        private bool isPermutationOfPalindrome(string phrase)
        {
            int[] table = buildCharFrequencyTable(phrase);
            return checkMaxOneOdd(table);
        }

        /* Check that no more than one character has an odd count. */
        private bool checkMaxOneOdd(int[] table)
        {
            bool foundOdd = false;
            foreach (int count in table)
            {
                if (count % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }
                    foundOdd = true;
                }
            }
            return true;
        }

        /* Map each character to a number. a -> 0, b -> 1, c -> 2, etc.
        * This is case insensitive. Non-letter characters map to -1. */
        private int getCharNumber(char c)
        {
            int a = (int)('a');
            int z = (int)('z');
            int val = (int)(c);
            if (a <= val && val <= z)
            {
                return val - a;
            }
            return -1;
        }

        /* Count how many times each character appears. */
        private int[] buildCharFrequencyTable(string phrase)
        {
            int[] table = new int[(int)('z') - (int)('a') + 1];
            foreach (char c in phrase.ToCharArray())
            {
                int x = getCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                }
            }
            return table;
        }


        // Solution 2
        private bool isPermutationOfPalindrome2(string phrase)
        {
            int countOdd = 0;
            int[] table = new int[(int)('z') - (int)('a') + 1];
            foreach (char c in phrase.ToCharArray())
            {
                int x = getCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }
            return countOdd <= 1;
        }

        // Solution 3
        private bool isPermutationOfPalindrome3(string phrase)
        {
            int bitVector = createBitVector(phrase);
            return bitVector == 0 || checkExactlyOneBitSet(bitVector);
        }

        /* Create a bit vector for the string. For each letter with value i, toggle the
        * ith bit. */
        private int createBitVector(string phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase.ToCharArray())
            {
                int x = getCharNumber(c);
                bitVector = toggle(bitVector, x);
            }
            return bitVector;
        }

        /* Toggle the ith bit in the integer. */
        private int toggle(int bitVector, int index)
        {
            if (index < 0)
            {
                return bitVector;
            }

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }
            return bitVector;
        }

        /* Check that exactly one bit is set by subtracting one from the integer and
        * ANDing it with the original integer. */
        private bool checkExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }
    }
}
