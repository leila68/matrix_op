using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixSum
{
    class CSR
    {
        int row = 0;
        int col = 0;
        double[] val;
        int[] ptr;
        int[] idx;
        int nonzero;

        public CSR(int r, int c, int n)
        {
            row = r;
            col = c;
            nonzero = n;
            ptr = new int[r+1];
            idx = new int[n];
            val = new double[n];
        }
        public CSR(Matrix m)
        {
            initializeWithMatirx1(m);
        }
             
        public void triplet()
        {
            for(int i=0; i<row; i++)
            {
                for (int j = ptr[i]; j < ptr[i + 1]; j++)
                {
                    Console.Write(i);
                    Console.Write(idx[j]);
                    Console.WriteLine(val[j]);
                }
            }
        }
        public void printArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}", arr[i] + " ");
                Console.WriteLine(0);
            }
        }
        public void initializeWithMatirx(Matrix m)
        {
            int v = 0;
            int c = 0;
            int x = 0;
            ptr = new int[row + 1];
            idx = new int[row * col];
            val = new double[row * col];


            for (int i = 0; i < row; i++)
            {
                ptr[x] = v;
                x++;
                for (int j = 0; j < col; j++)
                {
                    val[v] = m.getArray(i, j);
                    v++;
                    idx[c] = j;
                    c++;
                }
            }
            ptr[x] = v;
        }
        private void initializeWithMatirx1(Matrix m)
        {
            int c = 0;
            int s;
            row = m.getRow();
            col = m.getCol();
            nonzero = m.getNonzero();
           ptr = new int[row + 1];
           idx = new int[nonzero];
           val = new double[nonzero];
            int[] nzRow = new int[row];
            ptr[0] = 0;
            int[] first = new int[row];

            for (int i = 0; i < row; i++)
            {
                s = 0;
               
                for (int j = 0; j < col; j++)
                {
                    if (m.getArray(i, j) != 0)
                    {
                        val[c] = m.getArray(i, j);
                        idx[c] = j;
                        c++;
                        s++;
                    }
                }
                nzRow[i] = s;
            }
              for (int i = 1; i <= row; i++)
               {
                ptr[i] = ptr[i - 1] + nzRow[i - 1];
               }
        }
  
        public Matrix turnToRegular()
        {
           
            Matrix y = new Matrix(row, col, "turn");
            
            for (int i = 0; i < row; i++)
            {
                for (int j = ptr[i]; j < ptr[i + 1]; j++)
                {
                    y.setArray(i, idx[j], val[j]);
                    
                }
            }

            return y; 
        }

        public Matrix csrMult()
        {
            Matrix result = new Matrix(row, 1, "resultVector");
            Matrix v = new Matrix(row, 1, "vector");
            v.Random();
            v.print();
            double s = 0;
            for (int i=0; i<row; i++)
            {
                for (int j=ptr[i]; j<ptr[i+1]; j++ )
                {
                    s = val[j] * v.getArray(idx[j],0) + s;
                    result.setArray(i, 0, s);

                }
                s = 0;
            }
            return result;
        }
        
    }
}
