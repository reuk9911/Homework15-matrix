using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15_matrix
{
    public class Matrix
    {
        #region Поля и свойства
        /// <summary>
        /// Матрица
        /// </summary>
        private long[,] matr;
        
        /// <summary>
        /// 
        /// </summary>
        public int dim1
        {
            get { return matr.GetLength(0); }
        }
        public int dim2
        {
            get { return matr.GetLength(1); }
        }

        #endregion

        #region Конструкторы

        public Matrix(int dim1, int dim2)
        {
            this.matr = new long[dim1, dim2];
        }

        #endregion
        #region Методы
        
        public override string ToString()
        {
            string s = "\n";
            for (int i = 0; i < dim1; i++)
            {

                for (int j = 0; j < dim2; j++)
                {
                    s = s + " " + matr[i, j];
                    if (j == dim2 - 1)
                        s += "\n";
                }
            }
            return s;
        }

        #endregion
        
        #region Индексаторы
        
        public long this[int index1, int index2]
        {
            get { return matr[index1, index2]; }
            set { matr[index1, index2] = value; }
        }

        #endregion
    }
}
