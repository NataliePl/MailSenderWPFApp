using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        //количество столбцов и строк в матрице
        private const int DIM = 1000;

        static void Main(string[] args)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            TimeSpan timeSpan = new TimeSpan();

            #region Инициализация исходных матриц
            var A = InitializationMatrix();
            //Console.WriteLine("Матрица A:\n");
            //PrintMatrix(A);

            Thread.Sleep(100);

            var B = InitializationMatrix();
            //Console.WriteLine("Матрица B:\n");
            //PrintMatrix(B);
            #endregion


            #region Произведение синхронным методом
            //Синхронный метод

            stopwatch1.Start();
            var D = MultiplicationMatrix(A, B);
            //Console.WriteLine("Результат умножения матриц при синхронном методе:\n");
            //PrintMatrix(D);
            stopwatch1.Stop();

            timeSpan = stopwatch1.Elapsed;
            Console.WriteLine("Время вычисления при синхронном методе: {0}\n", timeSpan.ToString());
            #endregion

            #region Произведение асинхронным методом
            //асинхронный метод

            stopwatch2.Start();
            var C = MultiplicationMatrixWithParallel(A, B);
            //Console.WriteLine("Результат умножения матриц с использованием класса Parallel: :\n");
            //PrintMatrix(C);
            stopwatch2.Stop();

            timeSpan = stopwatch2.Elapsed;
            Console.WriteLine("Время вычисления с использованием класса Parallel: {0}\n", timeSpan.ToString());
            #endregion

            Console.ReadLine();
        }

        private static int[,] InitializationMatrix()
        {
            var matrix = new int[DIM, DIM];

            var rand = new Random();

            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матриц с классом Parallel
        /// </summary>

        private static int[,] MultiplicationMatrixWithParallel(int[,] firstMatrix, int[,] secondMatrix)
        {
            {
                var firstRows = firstMatrix.GetLength(0);
                var secondRows = secondMatrix.GetLength(0);
                var firstColumns = firstMatrix.GetLength(1);
                var secondColumns = secondMatrix.GetLength(1);
                if (firstColumns != secondRows)
                    throw new ArgumentException();

                var resultMatrix = new int[firstRows, secondColumns];

                Parallel.For(0, firstRows, row =>
                    Parallel.For(0, secondColumns, column =>
                        resultMatrix[row, column] = Enumerable
                            .Range(0, firstColumns)
                            .Select(i => firstMatrix[row, i] * secondMatrix[column, i])
                            .Sum())
                );
                return resultMatrix;
            }
        }

        /// <summary>
        /// Умножение матриц без TPL
        /// </summary>
        private static int[,] MultiplicationMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            var resultMatrix = new int[DIM, DIM];

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < secondMatrix.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }                   
                }                
            }

            return resultMatrix;
        }

    /// <summary>
    /// Выведение матрицы в консоль
    /// </summary>
        private static void PrintMatrix(int[,] matrix)
        {

            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
 
    }

}
