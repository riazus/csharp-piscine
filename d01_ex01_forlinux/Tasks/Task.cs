using System;
using System.IO;
using System.Collections.Generic;

namespace d01_ex01
{
    struct Task
    {
        public string Header;
        public string? Summary;
        public TState State;
        public DateTime dueDate;
        public TType Type;
        public TPriority Priority; 
    }
    class TAdd
    {

        TError Error = new TError();
        TList List = new TList();
        GetPriority Priority = new GetPriority();
        GetType Type = new GetType();
        GetState State = new GetState();

        void AddHeader(ref Task Task)
        {
            string? tmpString;

            Console.WriteLine("Пожалуйста, введи заголовок:");
            while (true)
            {
                tmpString = Console.ReadLine();
                if (tmpString == "" || tmpString == null)
                    Error.ErrorMsg(0);
                else
                {
                    Task.Header = tmpString;
                    break;
                }
            }
        }
        void AddSummary(ref Task Task)
        {
            Console.WriteLine("Введите описание (при желании можно пропустить):");
            Task.Summary = Console.ReadLine();
        }
        void AddDate(ref Task Task)
        {
            string? tmpString;
            
            Console.WriteLine("Введите срок (не обязательно):");
            while (true)
            {
                tmpString = Console.ReadLine();
                if (DateTime.TryParse(tmpString, out Task.dueDate) || tmpString == "")
                {
                    Console.WriteLine("Дата успешно добавлена!");
                    break;
                }
                else
                    Error.ErrorMsg(0);
            }
        }
        public void AddTask()
        {
            Task Task = new Task();

            AddHeader(ref Task);
            AddSummary(ref Task);
            AddDate(ref Task);
            Type.AddType(ref Task);
            Priority.AddPriority(ref Task);
            State.AddState(ref Task);
            List.AddToList(Task);
            Console.WriteLine("Новая задача добавлена!");
        }
    }
    class TList
    {
        TError Error = new TError();

        public static List<Task> MainList = new List<Task>();
        public static int numTask = 0;
        public void AddToList(Task Task)
        {
            MainList.Add(Task);
            numTask++;
        }
        public List<Task> SendList()
        {
            return MainList;
        }
        public int SendnumTask()
        {
            return numTask;
        }
        public void OutputList()
        {
            int i;

            i = 0;
            if (numTask == 0)
                Error.ErrorMsg(1);
            while (i < numTask)
            {
                Console.WriteLine($"\n{i + 1}) {MainList[i].Header}\n" +
                $"[{MainList[i].Type}] [{MainList[i].State}]\n" +
                $"Priority: {MainList[i].Priority}, " + 
                $"Due till {MainList[i].dueDate.ToShortDateString()}\n" +
                $"Summary: {MainList[i].Summary}");
                Console.WriteLine("----------------------------------");
                i++;
            }
        }
    }
    class TDone
    {
        TError Error = new TError();
        TList List = new TList();
        public void DoneTask()
        {
            List<Task> tmpList = new List<Task>();
            int numTask;
            string? tmpStr;
            Task tmpTask = new Task();
            int i;

            tmpList = List.SendList();
            numTask = List.SendnumTask();
            i = 0;
            if (numTask > 0)
            {
                Console.WriteLine("Введи заголовок");
                tmpStr = Console.ReadLine();
                if (tmpStr == "")
                    Error.ErrorMsg(0);
                tmpTask.Header = tmpStr!;
                while (i < numTask)
                {
                    if (tmpTask.Header == tmpList[i].Header)
                    {
                        Console.WriteLine($"Задача [{tmpTask.Header}] выполнена!\n" +
                        $"Так держать!\n");
                    }
                    i++;
                }
                if (tmpTask.Header != tmpList[i - 1].Header)
                     Error.ErrorMsg(2);
            }
            else
                Error.ErrorMsg(1);
        }
    }
    class TWontdo
    {
        TError Error = new TError();
        TList List = new TList();
        public void WontdoTask()
        {
            List<Task> tmpList = new List<Task>();
            int numTask;
            string? tmpStr;
            Task tmpTask = new Task();
            int i;

            tmpList = List.SendList();
            numTask = List.SendnumTask();
            i = 0;
            if (numTask > 0)
            {
                Console.WriteLine("Введи заголовок");
                tmpStr = Console.ReadLine();
                if (tmpStr == "")
                    Error.ErrorMsg(0);
                tmpTask.Header = tmpStr!;
                while (i < numTask)
                {
                    if (tmpTask.Header == tmpList[i].Header)
                    {
                        Console.WriteLine($"Задача [{tmpTask.Header}] более" +
                        $" не актуальна!\n");
                    }
                    i++;
                }
                if (tmpTask.Header != tmpList[i - 1].Header)
                     Error.ErrorMsg(2);
            }
            else
                Error.ErrorMsg(1);
        }
    }
    class THelp
    {
        public void OutPutHelp()
        {
            string[] str;

            str = File.ReadAllLines("help.txt");
            foreach(string tmpstr in str)
                Console.WriteLine(tmpstr);
        }
    }
    class T_Task
    {
        TAdd Add = new TAdd();
        TList List = new TList();
        TDone Done = new TDone();
        TWontdo Wont = new TWontdo();
        THelp Help = new THelp();

        public void WhichMethod(string method)
        {
            if (method == "add")
                Add.AddTask();
            else if (method == "list")
                List.OutputList();
            else if (method == "done")
                Done.DoneTask();
            else if (method == "wontdo")
                Wont.WontdoTask();
            else if (method == "help")
                Help.OutPutHelp();
            else if (method == "quit" || method == "q")
            {
                Console.WriteLine("So long, and thanks for fish!");
                Environment.Exit(1);
            }
        }
    }
}