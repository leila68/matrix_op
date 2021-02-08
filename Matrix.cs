using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixSum
{
    class Matrix
    {
        double[,] array;
        int rowNo;
        int colNo;
        string name;
        public Matrix(int row, int col, string str)
        {
            rowNo = row;
            colNo = col;
            name = str;
            array = new double[rowNo, colNo];
        }
        public double getArray(int r, int c)
        {
            return array[r, c];
        }
        public void setArray(int r, int c, double val)
        {
            array[r, c] = val;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return a.add(b);
        }
        public void Random()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF); 
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    array[i, j] = rnd.Next(1, 10);
                }
            }
        }
        public void Random(int z)
        {
            int count = 0;
            int row;
            int col;
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            do
            {
                row = rnd.Next(0, rowNo);
                col = rnd.Next(0, colNo);

                if (array[row, col] == 0)
                {
                    array[row, col] = rnd.Next(1, 10);
                    count++;
                }
            } while (count<z);
        }

        public int getNonzero()
        {
            int zero = 0;
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    if (array[i, j] != 0)
                    {
                        zero++;
                    }
                }
            }
            return zero;
        }
        public int getRow()
        {
            return rowNo;
        }
        public int getCol()
        {
            return colNo;
        }
        public Matrix add(Matrix m)
        {
            if (m.rowNo == rowNo & m.colNo == colNo)
            {
                Matrix s = new Matrix(rowNo, colNo, "sum of mtx1 and mtx2:");
                for (int i = 0; i < rowNo; i++)
                {
                    for (int j = 0; j < colNo; j++)
                    {
                        s.array[i, j] = m.array[i, j] + array[i, j];
                    }
                }
                return s;
            }
            
            else
            {
                return m;
            }       
        }

        
        public Matrix mult( int a)
        {
            Matrix m = new Matrix(rowNo,colNo, "mtx5 * mtx1");
            
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    m.array[i, j] = a * array[i,j];
                }
            }
          
            return m;
            
        }

        public Matrix mult(Matrix m)
        {
           
            Matrix n = new Matrix(rowNo, m.colNo, "mtx5 * mtx1");
           
            if (colNo == m.rowNo)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                for (int i = 0; i < colNo; i++)
                {
                    for (int j = 0; j < m.colNo; j++)
                    {
                        for (int k=0; k < rowNo; k++) 
                        {
                            n.array[k,j] = array[k,i] * m.array[i,j] + n.array[k,j];
                        }
                        
                    }
                }
                watch.Stop();
                Console.WriteLine($"Execution Time1: {watch.ElapsedMilliseconds} ms");
            }

            else {
                return null;

            }
           
            return n;
        }
        public Matrix mult2(Matrix m)
        {

            Matrix n = new Matrix(rowNo, m.colNo, "mtx5 * mtx1");
            if (colNo == m.rowNo)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                for (int i = 0; i < rowNo; i++)
                {
                    for (int j = 0; j < m.colNo; j++)
                    {
                        for (int k = 0; k < colNo; k++)
                        {
                            n.array[i, j] = array[i,k] * m.array[k, j] + n.array[i, j];
                        }
                    }
                }
                watch.Stop();
                Console.WriteLine($"Execution Time2: {watch.ElapsedMilliseconds} ms");
            }

            else
            {
                return null;

            }
            return n;
        }

        public Matrix mult3(Matrix m)
        {

            Matrix n = new Matrix(rowNo, m.colNo, "mtx5 * mtx1");
            if (colNo == m.rowNo)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                for (int i = 0; i < rowNo; i++)
                {
                    for (int j = 0; j < m.colNo; j++)
                    {
                        for (int k = 0; k < colNo; k++)
                        {
                            n.array[j, i] = array[j, k] * m.array[k, i] + n.array[j, i];
                        }
                    }
                }
                watch.Stop();
                Console.WriteLine($"Execution Time3: {watch.ElapsedMilliseconds} ms");
            }

            else
            {
                return null;

            }
            return n;
        }
        public Matrix mult4(Matrix m)
        {

            Matrix n = new Matrix(rowNo, m.colNo, "mtx5 * mtx1");
            if (colNo == m.rowNo)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                for (int i = 0; i < rowNo; i++)
                {
                    for (int j = 0; j < m.rowNo; j++)
                    {
                        for (int k = 0; k < rowNo; k++)
                        {
                            n.array[i, k] = array[i, j] * m.array[j, k] + n.array[i, k];
                        }

                    }
                }
                watch.Stop();
                Console.WriteLine($"Execution Time4: {watch.ElapsedMilliseconds} ms");
            }

            else
            {
                return null;

            }
            return n;
        }
        public void print()
        {
            Console.WriteLine(name);
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    Console.Write("{0}", array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
       
        public bool isequal(Matrix a)//TOODO
        {
            if (a.rowNo == rowNo & a.colNo == colNo)
            {
                for (int i = 0; i < rowNo; i++)
                {
                    for (int j = 0; j < colNo; j++)
                    {
                        if (a.array[i,j] - array[i,j] != 0)//TODO
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }    
            
            return true;
        }
        public Matrix averageRow()
        {
            Matrix rowsum = new Matrix(rowNo,1, "RowAve");
                                  
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                   
                    rowsum.array[i,0] = array[i,j] + rowsum.array[i,0];
                }   
            }

            for (int i = 0; i<rowNo; i++)
            {
                rowsum.array[i,0] = rowsum.array[i,0] / colNo;
            }
            return rowsum;        
        }

        public Matrix averageCol()
        {
            Matrix colsum = new Matrix(1,colNo, "ColAve");

            for (int i = 0; i < colNo; i++)
            {
                for (int j = 0; j < rowNo; j++)
                {

                    colsum.array[0, i] = array[j, i] + colsum.array[0, i];
                }
            }

            for (int i = 0; i < colNo; i++)
            {
                colsum.array[0,i] = colsum.array[0, i] / rowNo;
            }
            return colsum;
        }

        public void LowerTriangular()
        {
            for (int i = 0; i < rowNo; i++)
            {
                for (int j = 0; j < colNo; j++)
                {
                    if (i < j)
                    {
                        array[i,j] = 0;
                    }
                }
            }
          
        }
    }
}
