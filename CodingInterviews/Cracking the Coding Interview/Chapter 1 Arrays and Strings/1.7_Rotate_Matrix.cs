using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class Rotate_Matrix
    {
        // 1.7 Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
        // write a method to rotate the image by 90 degrees.Can you do this in place?


        [TestMethod]
        public void Test_One_Away()
        {
            int[][] matrix = {
                new int[] {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
                new int[] {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
                new int[] {8, 9, 10, 11},   /*  initializers for row indexed by 2 */
                new int[] {12, 13, 14, 15 }
            };


            int[][] smallMatrix = { new int[] { 0, 1 }, new int[] { 2, 3 } };

            bool output = rotate(matrix);
            Assert.AreEqual(output, true);
        }

        private int[,] Rotate(int[,] matrix)
        {
            throw new NotImplementedException();
        }

        //book solution
        private bool rotate(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
            {
                return false;
            }

            int n = matrix.Length;
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    int top = matrix[first][i]; //save top 

                    // left->top 
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom -> left 
                    matrix[last - offset][first] = matrix[last][last - offset];

                    //right -> bottom 
                    matrix[last][last - offset] = matrix[i][last];

                    //top -> right 
                    matrix[i][last] = top; //right<- saved top
                }
            }
            return true;
        }

    }
}
