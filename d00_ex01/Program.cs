using System;
using System.IO;

namespace d00_ex01
{
    public class Program
    {
        static bool Simple_sort(string str)
        {
            string [] strFile;

            strFile = File.ReadAllLines("/home/rusmanov/Myprojects/c#/d00_ex01/us_names.txt");
            foreach (string str1 in strFile)
            {
                if (str == str1)
                    return true;
            }
            return false;
        }
        static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }
        static List<string> Livenshtein(string str)
        {
            int diff;
            int i;
            int j;
            string[] strFile;
            List<string> tmpStr = new List<string>();

            strFile = File.ReadAllLines("/home/rusmanov/Myprojects/c#/d00_ex01/us_names.txt");
            i = 0;
            j = 0;
            while(j < strFile.Length)
            {
                diff = LevenshteinDistance(str, strFile[j]);
                if (diff == 1)
                {
                    tmpStr.Add(strFile[j]);
                    i++;
                }
                j++;
            }
            tmpStr.Add("fail");
            return tmpStr;
        }
        static bool ft_Sort(string str)
        {
            List<string> str1;
            int i;

            i = 0;
            str1 = Livenshtein(str);
            if (str1 != null)
            {
                while (str1[i] != "fail")
                {
                    Console.WriteLine($"Did you mean {str1[i]}? y/n");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine($"Hello, {str1[i]}!");
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }
        public static void Main(string[] args)
        {
            string? str;

            Console.WriteLine("Enter name: ");
            str = Console.ReadLine();
            if (str == "" || str == null)
                Console.WriteLine("Incorrect name!");
            else
            {
                if(Simple_sort(str!))
                    Console.WriteLine($"Hello, {str}!");
                else
                {
                    if (!ft_Sort(str!)) 
                        Console.WriteLine("Your name was not found");
                }
            }
        }
    }
}
