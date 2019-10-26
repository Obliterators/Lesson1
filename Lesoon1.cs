
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = "C:\\logs";
            do
            {
                SetText(dirName);

                Console.WriteLine("q  повтор");
            }
            while (Console.ReadLine() == "q");
        }
        static void SetText(string file_name)
        {
            List<string> date = new List<string>();
            string[] files = Directory.GetFiles(file_name);
            foreach (string el in files)
            {
                // Console.WriteLine(el);
                foreach (string stroka in File.ReadAllLines(el))
                {
                    //Console.WriteLine(stroka);
                    date.AddRange(stroka.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
            // Vivod(date);
            List<string> time = new List<string>();
            List<string> pribor = new List<string>();
            List<string> power = new List<string>();
            string ch;
            for (int i = 0; i < date.Count; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        time.Add(date[i]);
                        continue;
                    case 1:
                        pribor.Add(date[i]);
                        continue;
                    case 2:
                        power.Add(date[i]);
                        continue;
                }
            }
            //Vivod(time);
            // Vivod(pribor);
            // Vivod(power);

            Console.WriteLine("Введите имя прибора, для которого хотите получить информацию: ");
            ch = Console.ReadLine();


            List<int> index_el = new List<int>();
            for (int i = 0; i < pribor.Count; i++)
            {

                if (ch.IndexOf("garbage") != -1)
                {

                    Console.WriteLine("Слово \"garbage\" найдено в строке");
                    break;
                }

                if (ch == pribor[i])
                    index_el.Add(i);
            }
            if (index_el.Count == 0)
                Console.WriteLine($"Элемент {ch} не найден");
            //Vivod(index_el);
            for (int i = 0; i < index_el.Count; i++)
            {
                Console.WriteLine(files[i].Substring(13, 16) + $"-{time[index_el[i]]} , Результат замеров: {power[index_el[i]]}");
            }


        }
        static void Vivod(List<string> pa)
        {
            foreach (string el in pa)
                Console.WriteLine(el);
        }
        static void Vivod(List<int> pa)
        {
            foreach (int el in pa)
                Console.WriteLine(el);
        }


    }

}
