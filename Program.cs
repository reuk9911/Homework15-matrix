using System.ComponentModel;
using System.Data;

namespace Homework15_matrix
{
    public class Program
    {
        static Matrix Fill(object arg)
        {
            Matrix o = (Matrix)arg;

            Random rand = new Random();
            for (int i = 0; i < o.dim1; i++)
            {
                for (int j = 0; j < o.dim2; j++)
                {
                    o.matr[i, j] = rand.Next(0, 3);
                }
            }
            Console.WriteLine("end");
            return o;
            
        }


        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(200,300);
            Matrix m2 = new Matrix(300,200);
            DateTime t1 = DateTime.Now;
            Task<Matrix> task1 = Task<Matrix>.Factory.StartNew(Fill, m1);
            Task<Matrix> task2 = Task<Matrix>.Factory.StartNew(Fill, m2);

            Task.WaitAll(task1, task2);
            m1 = task1.Result;
            m2 = task2.Result;
            task1.Dispose();
            task2.Dispose();

            MatrixOperations mop = new MatrixOperations(m1, m2);
            Matrix res = mop.Multiply();

            
            DateTime t2 = DateTime.Now;


            Console.WriteLine(t2-t1);

            //Console.WriteLine($@"m1 = {m1.ToString()}");
            //Console.WriteLine($@"m2 = {m2.ToString()}");
            //Console.WriteLine($@"res = {res.ToString()}");






            Console.WriteLine("Main Thread end");
        }
    }
}
    
