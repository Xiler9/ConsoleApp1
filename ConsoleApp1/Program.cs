using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла: ");

            //записывание путя до файла
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

            //удаление лишних символов
            var noPunctuationText = new string(Content.Where(c => !char.IsPunctuation(c)).ToArray());

            //разделение на слова
            string[] text = Regex.Split(noPunctuationText.Trim(), @"\s+");

            //запись 10 самых часто встречаемых слов в словарь
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary[text[i]]++;
                }
                else
                {
                    dictionary.Add(text[i], 1);
                }
            }

            //выборка 10 и вывод их в консоль
            foreach (var pare in dictionary.OrderByDescending(x => x.Value).Take(10))
            {
                Console.WriteLine(pare.Key);
            }
        }

    }
}
