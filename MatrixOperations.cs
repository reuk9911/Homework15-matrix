using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Homework15_matrix
{
    public class MatrixOperations
    {
        public Matrix m1 { get; }
        public Matrix m2 { get; }



        public MatrixOperations(Matrix m1, Matrix m2)
        {
            this.m1 = m1;
            this.m2 = m2;
        }
    
        /// <summary>
        /// Сумма m1[i,j]*m2[j,i]
        /// </summary>
        /// <param name="ind1">индекс строки результирующей матрицы</param>
        /// <param name="ind2">индекс столбца результирующей матрицы</param>
        /// <returns>Возвращает элемент результирующей матрицы с индексом [ind1, ind2]</returns>
        private long SumMult(int ind1, int ind2)
        {
            long sum = 0;
            
            for (int i=0; i<m1.dim2; i++)
            {
                sum += m1[ind1, i] * m2[i, ind2];
            }

            return sum;
        }
        public Matrix Multiply()
        {

            Matrix resMatrix = new Matrix(m1.dim2, m2.dim1);
            for (int i=0; i<m1.dim1; i++)
            {
                for (int j=0; j<m2.dim2; j++)
                {
                    Task<long> SumMultTask = new Task<long>(() => SumMult(i, j));
                    SumMultTask.Start();
                    resMatrix[i, j] = SumMultTask.Result;
                }
            }
            return resMatrix;
        }



    }
}
