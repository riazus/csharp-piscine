using System;
using System.IO;

namespace d01_ex01
{
    class TError
    {
        public void ErrorMsg(int num)
        {
            string[] Msg;

            Msg = File.ReadAllLines("error_msg.txt");
            Console.WriteLine(Msg[num]);
        }
    }
    class Program
    {
        static string[] PutCommands()
        {
            string[] commands = new string[] {"add", "list", "done",
            "wontdo", "quit", "q", "help"};
            return commands;
        }
        static bool IsCommand(string? UserInput)
        {
            string[] commands;
            bool i;

            i = false;
            commands = PutCommands();
            foreach (string str in commands)
            {
                if (UserInput == str)
                    i = true;
            }
            return i;
        }
        public static void Main(string[] args)
        {
            string? UserInput;
            TError Error = new TError();
            T_Task newTask = new T_Task();

            Console.WriteLine("Привет! Это таск-менеджер от riazus\n" +
            "Если ты здесь первый раз, то набери 'help'\n" +
            "Введи команду, которую ты хочешь сделать:");
            while (true)
            {
                
                UserInput = Console.ReadLine();
                if (!IsCommand(UserInput))
                    Error.ErrorMsg(0);
                newTask.WhichMethod(UserInput!);
            }
        }
    }
}