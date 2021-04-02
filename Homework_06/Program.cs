﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Домашнее задание
            Разработайте программу, которая будет разбивать числа от 1 до N на группы, 
            при этом числа в каждой отдельно взятой группе не делятся друг на друга. 
            Число N хранится в файле, поэтому его необходимо сначала оттуда прочитать. 
            Это число может изменяться от единицы до одного миллиарда.

            После получения числа N необходимо начать поиск групп неделящихся друг на друга чисел. 
            Сделать это можно различными способами. Например, для N = 50 группы могут получиться такими:

            Группа 1: 1.
            Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47.
            Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49.
            Группа 4: 8 12 18 20 27 28 30 42 44 45 50.
            Группа 5: 16 24 36 40.
            Группа 6: 32 48.

            А для N = 10, такими:

            Группа 1: 1.
            Группа 2: 2 7 9.
            Группа 3: 3 4 10.
            Группа 4: 5 6 8.

            Кроме распределения чисел реализуйте возможность получить только количество групп. 
            После получения групп их надо записать на диск. 
            Если пользователь захотел рассчитать только их количество, записывать его на диск не нужно, достаточно вывести на экран.

            После записи групп на диск необходимо спросить пользователя, хочет ли он поместить файл с группами в архив. 
            В случае положительного ответа заархивируйте этот файл и выведите информацию о его размере до и после архивации.

            Советы и рекомендации

            Заметьте, что группы можно рассчитать совершенно разными способами, при этом неважно, 
            какой способ расчёта вы выбрали ― до тех пор, пока числа в группах не делятся друг на друга, задача считается решённой.
            Для расчёта только количества групп необязательно проходить все числа. Попробуйте сделать этот расчёт с помощью формулы.
            При N равному миллиарду вам может не хватить оперативной памяти для хранения всех групп. Тогда стоит отказаться от их хранения.
            Не стоит использовать цикл тройной вложенности, так как это решение будет слишком медленным.
            После архивации расширение исходного файла может потеряться. Стоит предусмотреть этот момент.
            Если расчёт для миллиарда чисел идёт более 20 минут (с поправкой на слабое оборудование), вам стоит поменять алгоритм их поиска.
            Задачу можно решить с помощью одного цикла и без использования массивов.

            Что оценивается

            Число N прочитано из файла. Если данного числа там нет, а также если оно выходит за рамки заданного диапазона или не может быть прочитано, пользователю выводится сообщение об ошибке.
            Группы чисел рассчитаны, при этом в каждой группе находятся только те числа, которые не делятся друг на друга.
            Пользователю предлагается выбрать: рассчитать все группы или только посмотреть их количество для заданного N.
            После расчётов группы чисел записываются в файл, по строке на группу.
            Пользователю предлагается поместить файл с рассчитанными группами в архив. При его положительном ответе архив сформирован, а статистика по размеру обоих файлов выведена на экран.
            Расчёт групп для N = 1_000_000_000 не должен превышать 20 минут, какое бы оборудование ни использовалось.
                                    
            */
            
            PrintResult(DivisibilityProperty(10));
            PrintResult(DivisibilityProperty(50));

            var N = GetPositiveNumber();
            PrintResult(DivisibilityProperty(N));

            Console.ReadKey();
        }


        /// <summary>
        /// Контроль ввода пользователя. Требуем ввести целое положительное число.
        /// </summary>
        /// <returns></returns>
        private static int GetPositiveNumber()
        {
            string inputData = string.Empty;
            int result = 0;
            do
            {
                Console.Write("Введите целое положительное число: ");
                inputData = Console.ReadLine();
                if(int.TryParse(inputData, out result))
                {
                    if (result > 0)
                        break;
                }
                
                Console.WriteLine("Некорректный ввод!");
            } while (true);

            return result;
        }

        /// <summary>
        /// Распределения числа на несколько групп в соответствии со свойством делимости числа
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int[] DivisibilityProperty(int n)
        {
            int k = 0;
            while(Math.Pow(2, k)<n)
            {
                k++;   
            }
            int row = k;
            int col = n;
            int[,] groups = new int[row, col];
            
            groups[0, 0] = 1;
            
            for (int i=2; i<=n; i++)
            {
                for(int j=0; j<row; j++)
                {
                    for(int k=0;k<col;k++)
                    {
                        if (groups[j, k] == 0)
                            break;
                    }
                    if(groups)
                    if(IsDivided(i, j))
                    {
                        groups[i - 1] = groups[j - 1];
                        break;
                    }
                }
                if (groups[i - 1] == 0)
                    groups[i - 1] = ++groupCnt;
            }
            return groups;
        }

        /// <summary>
        /// Проверка, что число A не делится на B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsNotDivided(int a, int b)
        {
            return (a % b)>0;
        }

        /// <summary>
        /// Проверка, что число A кратно числу B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsDivided(int a, int b)
        {
            return (a % b) == 0;
        }


        private static void PrintResult(int[] groups)
        {
            Console.WriteLine($"Результат для N = {groups.Length}");
            for(int i=0; i<groups.Max(); i++)
            {
                Console.Write($"{i+1}: ");
                for(int j=0; j<groups.Length; j++)
                {
                    if(groups[j] == i+1)
                    Console.Write($"{j+1, 4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}