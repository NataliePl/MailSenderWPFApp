using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        //количество столбцов и строк в матрице
        private const int DIM = 10;

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timeSpan = new TimeSpan();

            var A = InitializationMatrix();
            Console.WriteLine("Матрица A:\n");
            PrintMatrix(A);

            Thread.Sleep(100);

            var B = InitializationMatrix();
            Console.WriteLine("Матрица B:\n");
            PrintMatrix(B);

            //stopwatch.Start();
            //var C = MultiplicationMatrixWithParallel(A, B);
            //Console.WriteLine("Результат умножения матриц:\n");
            //PrintMatrix(C);
            //stopwatch.Stop();
            
            //timeSpan = stopwatch.Elapsed;
            //Console.WriteLine(timeSpan.ToString());

            stopwatch.Restart();

            stopwatch.Start();
            var D = MultiplicationMatrix(A, B);
            Console.WriteLine("Результат умножения матриц:\n");
            PrintMatrix(D);
            stopwatch.Stop();
           
            timeSpan = stopwatch.Elapsed;
            Console.WriteLine(timeSpan.ToString());





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
        /// 

        //private static int[,] MultiplicationMatrixWithParallel(int[,] firstMatrix, int[,] secondMatrix)
        //{
        //    var resultMatrix = new int[DIM, DIM];

        //    for (int i = 0; i < firstMatrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < secondMatrix.GetLength(1); j++)
        //        {
        //            for (int k = 0; k < secondMatrix.GetLength(0); k++)
        //            {
        //                resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
        //            }
        //        }
        //    }

        //    return resultMatrix;
        //}

        //private static async Task<int> MultiNumbersOfMatrixAsync (int[,] firstMatrix, int[,] secondMatrix, ref int i, ref int k, ref int j)
        //{
        //    return firstMatrix[i, k] * secondMatrix[k, j];
        //}
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

        private static void PrintMatrix(int [,] matrix)
        {

            for(int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        //var to = new MailAddress("79214126446@yandex.ru", "From_Наталия");
        //var from = new MailAddress("n.plaksickaya@gmail.com", "To_Наталия");

        //var message = new MailMessage(from, to);
        //message.Subject = "Тестовое письмо";
        //message.Body = "Текст тестового письма";

        //var client = new SmtpClient("smtp.gmail.com", 25);
        //client.EnableSsl = true;
        ////client.Timeout = 1000;
        //client.Credentials = new NetworkCredential
        //{
        //    UserName = "n.plaksickaya",
        //    Password = "..."
        //};

        //client.Send(message);
    }
    
}
