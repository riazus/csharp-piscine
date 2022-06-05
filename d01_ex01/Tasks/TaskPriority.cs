using System;

namespace d01_ex01
{
    public enum TPriority
    {
        Low,
        Normal,
        High
    }
    class GetPriority
    {
        TError Error = new TError();
        public void AddPriority(ref Task Task)
        {
            string? tmpString;

            Console.WriteLine("Установите приоритет (можно пропустить):");
            while (true)
            {
                tmpString = Console.ReadLine();
                if (tmpString == "low")
                {
                    Task.Priority = TPriority.Low;
                    break;
                }
                else if (tmpString == "high")
                {
                    Task.Priority = TPriority.High;
                    break;
                }
                else if (tmpString == "" || tmpString == "normal")
                {
                    Task.Priority = TPriority.Normal;
                    break;
                }
                else
                    Error.ErrorMsg(0);
            }
            //return Task;
        }
    }
}