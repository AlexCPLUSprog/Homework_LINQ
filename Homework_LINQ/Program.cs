﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_LINQ
{
    internal class Program
    {
        static void Main(string[] args)

        {
            try
            {
                string path1;
                string path2;
                if (args.Length == 2)
                {
                    path1 = args[0];
                    path2 = args[1];
                }
                else
                {
                    path1 = "text1.txt";
                    path2 = "text2.txt";
                }

                string file1 = File.ReadAllText(path1);
                string file2 = File.ReadAllText(path2);

                string[] words1 = file1.Split(' ', '.', '-', ',');
                string[] words2 = file2.Split(' ');

                Console.WriteLine($"Считываем слова из файла {path1}: ");
                foreach (string item in words1)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nСчитываем слова из файла {path2}: ");
                foreach (string item in words2)
                {
                    Console.WriteLine(item);
                }
                var intersectionWords = words1.Intersect(words2); // метод LINQ для поиска пересечений в коллекции                
                Console.WriteLine("\nНайденные пересечения:");
                foreach (var item in intersectionWords)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\nПовторяющиеся слова записаны в файл: text_3.txt");

                using (StreamWriter file3 = new StreamWriter("text_3.txt"))
                {
                    foreach (var item in intersectionWords)
                    {
                        file3.WriteLine(item);
                    }
                }
            }
            catch (Exception e00)
            {
                Console.WriteLine(e00.Message);
            }
            Console.ReadLine();
        }
    }
}
