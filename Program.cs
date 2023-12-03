using System.ComponentModel;
using System.Data;

namespace Homework15_matrix
{
    public class Program
    {

        /// <summary>
        /// Заполняет матрицу случайными числами от 0 до 2
        /// </summary>
        /// <param name="arg">Матрица для заполнения</param>
        /// <returns>Возвращает заполненную матрицу</returns>
        static Matrix Fill(object arg)
        {
            Matrix o = (Matrix)arg;

            Random rand = new Random();
            for (int i = 0; i < o.dim1; i++)
            {
                for (int j = 0; j < o.dim2; j++)
                {
                    o[i, j] = rand.Next(0, 3);
                }
            }
            return o;
        }

        static void Main(string[] args)
        {
            int d11 = 0, d12 = 0, d21 = 0, d22 = 0;
            bool b = false;
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            while (!b)
            {
                Console.WriteLine("Введите количество строк матрицы 1: ");
                b1 = int.TryParse(Console.ReadLine(), out d11);
                Console.WriteLine("Введите количество столбцов матрицы 1: ");
                b2 = int.TryParse(Console.ReadLine(), out d12);
                Console.WriteLine("Введите количество строк матрицы 2: ");
                b3 = int.TryParse(Console.ReadLine(), out d21);
                Console.WriteLine("Введите количество столбцов матрицы 2: ");
                b4 = int.TryParse(Console.ReadLine(), out d22);

                b = b1 && b2 && b3 && b4;
                if (!b)
                    Console.WriteLine("Неверные исходные данные");
                if (d12 != d21)
                {
                    Console.WriteLine("Количество столбцов матрицы 1 должно быть равно количеству строк матрицы 2");
                    b = false;
                }
            }

            Matrix m1 = new Matrix(d11, d12);
            Matrix m2 = new Matrix(d21, d22);
            DateTime t1 = DateTime.Now;
            Task<Matrix> task1 = Task<Matrix>.Factory.StartNew(Fill, m1);
            Task<Matrix> task2 = Task<Matrix>.Factory.StartNew(Fill, m2);

            Task.WaitAll(task1, task2);

            Console.WriteLine("Заполнение матриц завершено");
            m1 = task1.Result;
            m2 = task2.Result;
            task1.Dispose();
            task2.Dispose();

            Matrix res = MatrixOperations.Multiply(m1, m2);

            DateTime t2 = DateTime.Now;

            Console.WriteLine($@"Умножение завершено за {t2 - t1}") ;

            // Закомментировать для больших матриц
            //Console.WriteLine($@"m1 = {m1.ToString()}");
            //Console.WriteLine($@"m2 = {m2.ToString()}");
            //Console.WriteLine($@"res = {res.ToString()}");
        }
    }
}

