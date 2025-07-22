using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //записывание путя до файла
            Console.WriteLine("Введите путь до файла: ");
            string path = Console.ReadLine();
            string Content = null;

            //чтение текста
            try
            {
                Content = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка {ex}");
            }

            //нахождение 4 слов из текста
            string[] strings = new string[4];
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = FindFirstWord(ref Content);
            }

            //замеры List
            List<string> list = new List<string>();
            Stopwatch listStopwatch = new Stopwatch();
            listStopwatch.Start();
            list.Add(strings[0]);
            list.Add(strings[1]);
            list.Add(strings[2]);
            list.Add(strings[3]);
            listStopwatch.Stop();
            
            //замеры LinkedList
            LinkedList<string> linkedList = new LinkedList<string>();
            Stopwatch linkedListStopwatch = new Stopwatch();
            linkedListStopwatch.Start();
            linkedList.AddFirst(strings[0]);
            linkedList.AddLast(strings[1]);
            linkedList.AddFirst(strings[2]);
            linkedList.AddLast(strings[3]);
            linkedListStopwatch.Stop();

            //сравнение
            Console.WriteLine($"Скорость записи list - {listStopwatch.Elapsed} Скорость записи LinkedList - {linkedListStopwatch.Elapsed}");
        }
        public static string FindFirstWord(ref string text)
        {
            //находим индекс первого слова
            string word = null;
            int index = 0;
            for (int i = 0; !Char.IsLetter(text[i]); i++)
            {
                index++;
            }
            int firrstIndex = index;

            //записываем всё слово целиком
            while (Char.IsLetter(text[index]))
            {
                word += text[index];
                index++;
            }

            //удаляем это слово из текста
            text = text.Remove(firrstIndex, index - firrstIndex);

            //возращаем это слово
            return word;
        }
    }
}