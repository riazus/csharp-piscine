using System;

namespace d01_ex00
{
    class Program
    {
        public static void Main(string[] args)
        {
            double Sum;
            //int tmpSum;
            string Value;
            string Path;

            if (args.Length == 3)
            {
                //tmpSum = Convert.ToInt32(args[0]);
                Sum = Convert.ToDouble(args[0]);
                Value = args[1];
                Path = args[2];
                TExcganger Excganger = new TExcganger();
                t_Data Data = new t_Data();
                Data = Excganger.Exchange(Sum, Value, Path);
                Console.WriteLine($"Сумма в исходной валюте: {Data.MainSum}" + 
                $" {Data.MainValue}\nСумма в {Data.SecondVal}: {Data.SecondSum}" +
                $" {Data.SecondVal}\nСумма в {Data.ThirdVal}: {Data.ThirdSum}" +
                $" {Data.ThirdVal}");
            }
            else
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");

        }
    }
}