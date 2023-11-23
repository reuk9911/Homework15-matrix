using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15_matrix
{
    public class Matrix
    {
        public long[,] matr { get; set; }
        public int dim1
        {
            get { return matr.GetLength(0); }
        }
        public int dim2
        {
            get { return matr.GetLength(1); }
        }

        public Matrix(int dim1, int dim2)
        {
            this.matr = new long[dim1, dim2];
        }

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
        public long this[int index1, int index2]
        {
            get { return matr[index1, index2]; }
            set { matr[index1, index2] = value; }


        }
    }
}
