using System;

namespace d01_ex01
{
    public enum TType
    {
        Study,
        Work,
        Personal
    }
    class GetType
    {
        TError Error = new TError();
        public void AddType(ref Task Task)
        {
            string? tmpString;
            Console.WriteLine("Введите тип (work || study || personal):");
            while (true)
            {
                tmpString = Console.ReadLine();
                if (tmpString == "work")
                {
                    Task.Type = TType.Work;
                    break;
                }
                else if (tmpString == "study") 
                {
                    Task.Type = TType.Study;
                    break;
                }
                else if (tmpString == "personal")
                {
                    Task.Type = TType.Personal;
                    break;
                }
                else
                    Error.ErrorMsg(0);
            }
        }
    }
}