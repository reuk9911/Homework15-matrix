using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15_matrix
{
    internal class MatrixElement
    {
        public long Value;
        public int CoordX;
        public int CoordY;

        public MatrixElement(int coordX, int coordY, long Value)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.Value = Value;
        }



    }
}
