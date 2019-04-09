using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingInterviews.Dynamic_Programming
{
    [TestClass]
    internal class Class1
    {
        [TestMethod]
        public void Test_MakingChange_BruteForce()
        {
            double das = GetDistance(2, 2, 4, 4, 8, 8);
            Assert.AreEqual(das, 3);
        }

        private double GetDistance(double x1, double y1, double x2, double y2,  double x3, double y3)
        {
            double xy = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double yz = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            return (xy + yz) / 2;
        }
    }
}
