using System;

class Program
{
    static int MonthDays(int i)
    {
        string Base;
        string Now;
        TimeSpan days;
        int ddays;

        Base = DatePay(i - 1);
        Now = DatePay(i);
        days = Convert.ToDateTime(Now) - Convert.ToDateTime(Base);
        ddays = Convert.ToInt32(days);
        return ddays;
    }

    static double MainDept(double sum, int month)
    {
        double  Dept;

        Dept = sum / month;
        return Dept;
    }

    static double  OutStanding(double sum, int i)
    {
        double Main;
        double Standing;

        Main = MainDept(sum, i);
        Standing = sum - Main * i;
        return Standing;
    }

    static double  PercentSum(double sum, int i, double percent)
    {
        double Standing;
        double PerSum;
        int days;

        days = MonthDays(i);
        Standing = OutStanding(sum , i);
        PerSum = Standing * (percent / 100 * days / 365);
        return PerSum;
    }

    static double TotalPayment(double sum, int i, double percent)
    {
        double Dept;
        double Percent;

        Dept = MainDept(sum, i);
        Percent = PercentSum(sum, i, percent);
        return (Dept + Percent);

    }

    static string DatePay(int i)
    {
        DateTime date1 = new DateTime(2022, 2, 4);
        date1 = date1.AddMonths(i);
        return date1.ToShortDateString();
    }

    static void OutPutString(double sum, double percent, int month)
    {
        int i;

                i = 1;
        while (i <= month)
        {
            Console.WriteLine($"{i})\t{Program.DatePay(i)}\t{Program.TotalPayment(sum, i, percent)}\t" + 
            $"{Program.PercentSum(sum, i, percent)}\t{Program.MainDept(sum, month)}\t{Program.OutStanding(sum, i)}");
            i++;
        }
    }

    static void Main(string[] args)
    {
        if (args.Length == 3)
        {
            // string sums = Console.ReadLine();
            // string percents;
            // string months;
            double sum;
            double percent;
            int month;

            // sums = Console.ReadLine();
            // percents = Console.ReadLine();
            // months = Console.ReadLine();
            //Console.WriteLine($"{args[0]}");
            sum = Convert.ToDouble(args[0]);
            percent = Convert.ToDouble(args[1]);
            month = Convert.ToInt32(args[2]);
            // percent = double.Parse(args[1]);
            // month = Int32.Parse(args[2]);
            //Program.OutPutString(sum, percent, month);
            // Console.WriteLine("Input sum: ");
            // sum = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Input percent: ");
            // percent = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Input month: ");
            // month = Convert.ToInt32(Console.ReadLine());
            Program.OutPutString(sum, percent, month);
        }
        else 
            Console.WriteLine("Please, put 3 arguments");
        //return 0;
    }
}