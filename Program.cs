using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace matrixSum
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
          
            Matrix mtx1 = new Matrix(3,3, "Matrix1:");
            mtx1.Random(3);
            mtx1.print();
          // mtx1.setArray(0,0,1);
          // mtx1.setArray(0,1,2);

            Matrix mtx2 = new Matrix(3, 3, "Matrix2:");
            mtx2.Random();
            mtx2.print();
            // mtx2.setArray(0, 0, 3);
            // mtx2.setArray(0, 1, 4);
            

          //  Matrix mtx3 =  mtx2.add(mtx1);
            Matrix mtx3 = mtx1 + mtx2; 
            mtx3.print();

            Matrix mtx4 = new Matrix(3, 3, "Matrix4 for average");
            mtx4.Random();
            mtx4.print();
            Matrix mtx8 =  mtx4.averageRow();
            mtx8.print();
            Matrix mtx9 = mtx4.averageCol();
            mtx9.print();
            

            Matrix mtx5 = new Matrix(3, 3,"Matrix5");
            mtx5.Random();
            
          //  mtx5.print();
           
            
            Matrix mt1 = mtx5.mult(mtx2);
            

            Matrix mt2 = mtx5.mult2(mtx2);
            Matrix mt3 = mtx5.mult3(mtx2);
            Matrix mt4 = mtx5.mult4(mtx2);

          //  mt1.print();
          //  mt2.print();
          //  mt3.print();
          //  mt4.print();


            bool result1 = mt1.isequal(mt2);
            bool result2 = mt2.isequal(mt3);
            bool result3 = mt3.isequal(mt4);
            Console.WriteLine("{0}{1}{2}",result1, result2, result3);
            // print of result???
            // override??

            Matrix mtxL = new Matrix(5,5,"Lower Triangular");
            mtxL.Random();
            mtxL.LowerTriangular();
            mtxL.print();
            Matrix rhs = new Matrix(5, 1, "rhs");
            rhs.Random();
            rhs.print();

           // Matrix x = new Matrix(3, 1, "x");

           
            TriangularSolve ts1 = new TriangularSolve(5);
            Matrix y = ts1.solve(mtxL,rhs);
            y.print();
            Matrix mtx10 = mtxL.mult2(y);
            bool testResult = mtx10.isequal( rhs);

            //bool testResult = ts1.test(mtx10,rhs);
            Console.WriteLine(testResult);
            //print result
            CSR c1 = new CSR(mtx1);
            c1.triplet();

            Matrix reg =  c1.turnToRegular();
            reg.print();

            Matrix vector = c1.csrMult();
            vector.print();

            Console.ReadKey();
     
        }
    }
}
