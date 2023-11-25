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
        private long SumMult(Object o)
        {
            var coord = ((Coord)o);
            int ind1 = coord.X;
            int ind2 = coord.Y;
            long sum = 0;
            for (int i=0; i<m1.dim2; i++)
            {
                sum += m1[ind1, i] * m2[i, ind2];
            }

            return sum;
        }
        //PutMatrixElement
        public Matrix Multiply()
        {
            int rstr = m1.dim1;
            int rrow = m2.dim2;
            Matrix resMatrix = new Matrix(rstr, rrow);

            Task<long>[] SumMultTasks = new Task<long>[rstr * rrow];
            int k = 0;
            for (int i = 0; i < rstr; i++)
            {
                for (int j = 0; j < rrow; j++)
                {
                    //SumMultTasks[k] = new Task<long>(SumMult, new Coord(i,j));
                    //SumMultTasks[k].Start();
                    Task<long> taskSumMultThenF = Task.Factory
                        .StartNew(SumMult, new Coord(i,j)) // returns Task<decimal>
                        .ContinueWith(
                        previousTask => // returns Task<string>
                        CallStoredProcedure(previousTask.Result));
                    k++;
                }
            }
            
            Task.WaitAll();
            k = 0;
            for (int i = 0; i < rstr; i++)
            {
                for (int j = 0; j < rrow; j++)
                {
                    resMatrix[i,j] = SumMultTasks[k].Result;
                    k++;
                }
            }
            return resMatrix;
        }



    }
}
