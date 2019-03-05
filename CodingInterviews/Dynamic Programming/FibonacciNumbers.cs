using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviews.Dynamic_Programming
{
    [TestClass]
    public class FibonacciNumbers
    {
        [TestMethod]
        public void Test_Recursive_Fibonacci()
        {
            int fibOf10 = fib(10);
            Assert.AreEqual(fibOf10, 55);
        }

        public int fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return fib(n - 1) + fib(n - 2);
        }

        [TestMethod]
        public void Test_Recursive_Fibonacci_Cache()
        {
            int fibOf10 = fib_Cache(10);
            Assert.AreEqual(fibOf10, 55);
        }

        public int fib_Cache(int n)
        {
            if (n < 2) return n;

            // Create cache and initalize to -1
            int[] cache = new int[n + 1];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }
            // Fill inital value in cache
            cache[0] = 0;
            cache[1] = 1;
            return fib(n, cache);
        }

        private int fib(int n, int[] cache)
        {
            //if value is set in cache, return
            if (cache[n] >= 0) return cache[n];
            // Compute and add to cache before returning
            cache[n] = fib(n - 1, cache) + fib(n - 2, cache);
            return cache[n];
            
        }


        [TestMethod]
        public void Test_Recursive_Fibonacci_Iterative()
        {
            int fibOf10 = fib_Interative(10);
            Assert.AreEqual(fibOf10, 55);
        }

        private int fib_Interative(int n)
        {
            if(n == 0)
            {
                return 0;
            }
            // initialize cache
            int[] cache = new int[n + 1];
            cache[1] = 1;

            // fill cache interatively
            for (int i = 2; i <= n; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
            }
            return cache[n];
        }

        [TestMethod]
        public void Test_Recursive_Fibonacci_Iterative_No_Cache()
        {
            int fibOf10 = fib_Interative_No_Cache(10);
            Assert.AreEqual(fibOf10, 55);
        }

        private int fib_Interative_No_Cache(int n)
        {
            if(n < 2 )
            {
                return n;
            }
            int n1 = 1, n2 = 0;
            for (int i = 2; i < n; i++)
            {
                int n0 = n1 + n2;
                n2 = n1;
                n1 = n0;
            }
            return n1 + n2;
        }
    }
}
