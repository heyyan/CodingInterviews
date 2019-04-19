using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviews.Cracking_the_Coding_Interview.Chaper_1_Arrays_and_Strings
{
    [TestClass]
    public class Zero_Matrix
    {

        //1.8 Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.

        [TestMethod]
        public void Test_Zero_Matrix()
        {
            int[][] matrix = {
                new int[] {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
                new int[] {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
                new int[] {8, 9, 10, 11},   /*  initializers for row indexed by 2 */
                new int[] {12, 13, 14, 15 }
            };


            int[][] smallMatrix = { new int[] { 0, 1 }, new int[] { 2, 3 } };

            setzeros(matrix);
            Assert.AreEqual(true, true);
        }

        private void setZeros(int[][] matrix)
        {
            bool[] row = new bool[matrix.Length];
            bool[] column = new bool[matrix[0].Length];
            //Store the row and column index with value 0 
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }
            // Nullify rows 
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i])
                {
                    nullifyRow(matrix, i);
                }
            }
            // Nullify columns 
            for (int j = 0; j < column.Length; j++)
            {
                if (column[j])
                {
                    nullifyColumn(matrix, j);
                }
            }
        }
        private void nullifyRow(int[][] matrix, int row)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }

        private void nullifyColumn(int[][] matrix, int col)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][col] = 0;
            }
        }

        private void setzeros(int[][] matrix)
        {
            bool rowHasZero = false;
            bool colHasZero = false;
            // Check if first row has a zero 
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            // Check if first column has a zero 
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }

            // Check for zeros in the rest of the array 
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            // Nullify rows based on values in first column 
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    nullifyRow(matrix, i);
                }
            }

            // Nullify columns based on values in first row 
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    nullifyColumn(matrix, j);
                }
            }
            // 
            // Nullify first row 
            if (rowHasZero)
            {
                nullifyRow(matrix, 0);
            }
            // Nullify first column 
            if (colHasZero)
            {
                nullifyColumn(matrix, 0);
            }
        }
    }
}
