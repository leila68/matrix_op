using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixSum
{
    class TriangularSolve
    {
        int rowNo;
        public TriangularSolve(int n)
        {
            rowNo = n;

        }

        public Matrix solve(Matrix L, Matrix d)
        {
            Matrix y = new Matrix(rowNo, 1, "y");
            double s = 0;
            y.setArray(0, 0, d.getArray(0, 0)/L.getArray(0,0))  ;

            for (int i=1; i<rowNo;i++ )
            {
                for (int j = 0; j < i ; j++)
                {
                    s = L.getArray(i, j) * y.getArray(j, 0) + s;
                }
                y.setArray(i, 0, (d.getArray(i, 0) - s));
                y.setArray(i, 0, y.getArray(i, 0) / L.getArray(i, i));
                s = 0;
                   
            }

            return y;
        }

       
    }
}
