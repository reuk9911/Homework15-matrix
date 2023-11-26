using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Homework15_matrix
{
    public static class MatrixOperations
    {

        #region Поля и свойства

        private static Matrix resMatrix;

        private static Matrix m1;
        private static Matrix m2;

        #endregion

        #region Методы

        /// <summary>
        /// Сумма m1[i,j]*m2[j,i]
        /// </summary>
        /// <param name="ind1">индекс строки результирующей матрицы</param>
        /// <param name="ind2">индекс столбца результирующей матрицы</param>
        /// <returns>Возвращает элемент результирующей матрицы с индексом [ind1, ind2]</returns>
        private static void SumMult(Object o)
        {
            var coord = (Coord)o;
            int ind1 = coord.X;
            int ind2 = coord.Y;
            long sum = 0;
            for (int i = 0; i < m1.dim2; i++)
            {
                sum += m1[ind1, i] * m2[i, ind2];
            }
            resMatrix[ind1, ind2] = sum;
        }

        /// <summary>
        /// Метод перемножает матрицы
        /// </summary>
        /// <param name="matr1">Матрица 1</param>
        /// <param name="matr2">Матрица 2</param>
        /// <returns>Возвращает результат перемножения матриц</returns>
        public static Matrix Multiply(Matrix matr1, Matrix matr2)
        {
            m1 = matr1;
            m2 = matr2;
            int rstr = m1.dim1;
            int rrow = m2.dim2;
            resMatrix = new Matrix(rstr, rrow);

            Task[] SumMultTasks = new Task[rstr * rrow];
            int k = 0;
            for (int i = 0; i < rstr; i++)
            {
                for (int j = 0; j < rrow; j++)
                {
                    SumMultTasks[k] = new Task(SumMult, new Coord(i, j));
                    SumMultTasks[k].Start();
                    //Task<long> taskSumMultThenF = Task.Factory
                    //    .StartNew(SumMult, new Coord(i, j)) // returns Task<long>
                    //    .ContinueWith(
                    //    previousTask => // returns Task<string>
                    //    CallStoredProcedure(previousTask.Result));
                    k++;
                }
            }

            Task.WaitAll();
            return resMatrix;
        }
        #endregion

    }
}
