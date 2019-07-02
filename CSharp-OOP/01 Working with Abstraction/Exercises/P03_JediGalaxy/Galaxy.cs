using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Galaxy
    {
        private int[,] matrix;
        private int row;
        private int col;

        public Galaxy(int row, int col)
        {
            this.row = row;
            this.col = col; 
            this.matrix = new int[this.row, this.col];
        }

        public void CreateStars()
        {
            int value = 0;

            for (int row = 0; row < this.row; row++)
            {
                for (int j = 0; j < this.col; j++)
                {
                   this.matrix[row, j] = value++;
                }
            }
        }

        public void ClearStars(int[] coordinates)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            while (row >= 0 && col >= 0)
            {
                if (row >= 0 && row < this.matrix.GetLength(0)
                    && col >= 0 && col < this.matrix.GetLength(1))
                {
                    this.matrix[row, col] = 0;
                }
                row--;
                col--;
            }
        }

        public long SelectStars(int[] coordinates)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            long sum = 0; 

            while (row >= 0 && col < this.matrix.GetLength(1))
            {
                if (row >= 0 && row < this.matrix.GetLength(0) 
                    && col >= 0 && col < this.matrix.GetLength(1))
                {
                    sum += this.matrix[row, col];
                }

                col++;
                row--;
            }

            return sum;
        }
    }
}
