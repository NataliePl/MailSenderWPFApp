using System;
using System.Collections.Generic;
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
        private enum SomeEnum
        {
            First = 4,
            Second,
            Third = 7,
            Fourth
        }

        static void Main(string[] args)
        {
            #region Задача 2

            //ЗАДАЧА 2. ОТВЕТ: По внутренним типам данных переменная int имеет системный тип System.Int32, 
            //при присвоении obj значения int она также становится Int32. А short в качестве системного типа относится Int16.

            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(i.GetType());

            short c = (short)i;
            object obj2 = c;

            Console.WriteLine(c);
            Console.WriteLine(c.GetType());

            Console.WriteLine(obj);
            Console.WriteLine(obj.GetType());
            Console.WriteLine((obj).GetType());


            Console.WriteLine(obj2);
            Console.WriteLine(obj2.GetType());
            //Console.WriteLine((short)obj);
            #endregion

            #region Задача 3
            //ЗАДАЧА 3: 3. Есть таблица Users. Столбцы в ней — Id, Name. Написать SQL-запрос, который выведет имена пользователей, 
            //начинающиеся на 'A' и встречающиеся в таблице более одного раза, и их количество.
            //ОТВЕТ:

            //SELECT last_name, COUNT(*) AS Count FROM employees
            //    WHERE last_name LIKE 'Ф%'
            //    GROUP BY last_name
            //    HAVING COUNT(*) > 1;
            #endregion

            #region Задача 4

            //ЗАДАЧА 4. ОТВЕТ - выведется число 5 (если в перечислении не добавлять числа принудительно, они будут назначены значения предыдущего числа

            Console.WriteLine((int)SomeEnum.Second);
            Console.WriteLine((int)SomeEnum.Fourth);

            #endregion

            #region Задача 6 дополнительные материалы
            //ЗАДАЧА 6.1 (ДОП).Как найти средний элемент в LinkedList за один проход?

            //Создание рандомного ссылочного списка
            LinkedList<int> linkedList = new LinkedList<int>();
            Random random = new Random();
            for (int j = 0; j < random.Next(10, 30); j++)
            {
                linkedList.AddFirst(random.Next(0, 100));
            }
            foreach (var v in linkedList)
            {
                Console.Write(v + " ");
            }

            Console.ReadLine();

        }
      
    }

}
