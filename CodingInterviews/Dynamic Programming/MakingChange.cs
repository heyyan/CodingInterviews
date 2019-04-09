using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CodingInterviews.Dynamic_Programming
{
    [TestClass]
    public class MakingChange
    {
        private readonly int[] coins = new int[] {25, 10, 5, 1 };
        [TestMethod]
        public void Test_MakingChange_BruteForce()
        {
            int change = MakingChangeBruteForce(1);
            Assert.AreEqual(change, 1);

            change = MakingChangeBruteForce(6);
            Assert.AreEqual(change, 2);

            change = MakingChangeBruteForce(49);
            Assert.AreEqual(change, 7);
        }

        // Brute Force solution. Go through every
        // combinition of coins that sum up to c to
        // find the minimum number
        public int MakingChangeBruteForce(int c)
        {
            if (c == 0)
            {
                return 0;
            }
            int minCoins = int.MaxValue;
            // Try removing each coin from the total and
            // see how many more coins are required
            foreach (int coin in coins)
            {
                // Skip a coin if it's value is greater
                // that the amount remaining
                int co = c - coin;
                if (co >= 0)
                {
                    int currentMinCoins = MakingChangeBruteForce(co);
                    if (currentMinCoins < minCoins)
                    {
                        minCoins = currentMinCoins;
                    }
                }
            }
            // Add back the coin removed recursively
            return minCoins + 1;
        }

        [TestMethod]
        public void Test_MakingChange_Dynamic()
        {
            int change = makeChangeDynamic(1);
            Assert.AreEqual(change, 1);

            change = makeChangeDynamic(6);
            Assert.AreEqual(change, 2);

            change = makeChangeDynamic(49);
            Assert.AreEqual(change, 7);
        }

        // top down dynamic solution. Cache the value 
        // as we compute them
        public int makeChangeDynamic(int c)
        {
            // initialize cacue value as -1
            int[] cache = new int[c + 1];
            for (int i = 1; i < c + 1; i++)
            {
                cache[i] = -1;                
            }
            return makeChangeDynamic(c, cache);
        }

        private int makeChangeDynamic(int c, int[] cache)
        {
            if(cache[c] >= 0)
            {
                return cache[c];
            }
            int minCoins = int.MaxValue;
            foreach (int coin in coins)
            {
                int co = c - coin;
                if (c - coin >= 0)
                {
                    int currentCoins = makeChangeDynamic(c - coin, cache);
                    if(currentCoins < minCoins)
                    {
                        minCoins = currentCoins;
                    }
                }
            }
            // Save the value into the cache
            cache[c] = minCoins + 1;
            return cache[c];
        }


        [TestMethod]
        public void Test_MakingChange_Dynamic_Bottom_Up()
        {
            //int change = makeChangeDynamicBottomUP(1);
            //Assert.AreEqual(change, 1);

            int change = makeChangeDynamicBottomUP(6);
            Assert.AreEqual(change, 2);

            change = makeChangeDynamicBottomUP(49);
            Assert.AreEqual(change, 7);
        }

        // Bottom up dynamic programming solution
        // Iteratively compute number of coins for
        // larget and larger amounts of change
        private int makeChangeDynamicBottomUP(int c)
        {
            int[] cache = new int[c + 1];
            for (int i = 1; i <=c; i++)
            {
                int minCoins = int.MaxValue;
                foreach (int coin in coins)
                {
                    int co = i - coin;
                    if(i-coin >= 0)
                    {
                        int currCoins = cache[i - coin] + 1;
                        if(currCoins < minCoins)
                        {
                            minCoins = currCoins;
                        }
                    }
                }
                cache[i] = minCoins;
            }
            return cache[c];
        }

        //[TestMethod]
        //public void doubleTest()
        //{
        //    double das = GetDistance(2, 2, 4, 4, 8, 8);
        //    Assert.AreEqual(das, 3);
        //}

        //private double GetDistance(double x1, double y1, double x2, double y2, double x3, double y3)
        //{
        //    double xy = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        //    double yz = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
        //    return (xy + yz) / 2;
        //}

        //[TestMethod]
        //public void MostPopularNumber_Test()
        //{
        //    int[] arr = { 2, 3, 3, 5, 3, 4, 1, 7 };
        //    int n = arr.Length;
        //    int k = 8;

        //  var most =  MostPopularNumber(arr, n);
        //    Assert.AreEqual(most, 3);
        //}


        //[TestMethod]
        //public void NumberOccuranca_Test()
        //{
        //    int[] arr = { 2,3,4,3,2,1 };
        //    int n = 3;
        //    var most = Occurences(arr, n);
        //    Assert.AreEqual(most, 2);
        //}

        //public int Occurences(int[] arr, int n)
        //{
        //    int counter = 0;
        //    foreach (int number in arr)
        //    {
        //        if(number == n)
        //        {
        //            counter++;
        //        }
        //    }
        //    return counter;
        //}

        //public int MostPopularNumber(int[] arr, int n)
        //{
        //    var counts = new Dictionary<int, int>();
        //    foreach (int number in arr)
        //    {
        //        int count;
        //        counts.TryGetValue(number, out count);
        //        count++;
        //        //Automatically replaces the entry if it exists;
        //        //no need to use 'Contains'
        //        counts[number] = count;
        //    }
        //    int mostCommonNumber = 0, occurrences = 0;
        //    foreach (var pair in counts)
        //    {
        //        if (pair.Value > occurrences)
        //        {
        //            occurrences = pair.Value;
        //            mostCommonNumber = pair.Key;
        //        }
        //    }

        //    return mostCommonNumber;
        //}
    }
}
