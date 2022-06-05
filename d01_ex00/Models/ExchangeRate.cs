using System;
using System.IO;

namespace d01_ex00
{
    public struct t_Rate
    {
        public double SecondRate;
        public double ThirdRate;
    }
    class TExchangeRate
    {
        public t_Rate WhichValue(string Value, string Path)
        {
            t_Rate Rate = new t_Rate();
            string[] tmpStr;

            if (Value == "RUB")
            {
                tmpStr = File.ReadAllLines(Path + "RUB.txt");
                Rate.SecondRate = Convert.ToDouble(tmpStr[0].Substring(4));
                Rate.ThirdRate = Convert.ToDouble(tmpStr[1].Substring(4));
                return Rate;
            }
            else if (Value == "USD")
            {
                tmpStr = File.ReadAllLines(Path + "USD.txt");
                Rate.SecondRate = Convert.ToDouble(tmpStr[0].Substring(4));
                Rate.ThirdRate = Convert.ToDouble(tmpStr[1].Substring(4));
                return Rate;
            }
            else if (Value == "EUR")
            {
                tmpStr = File.ReadAllLines(Path + "EUR.txt");
                Rate.SecondRate = Convert.ToDouble(tmpStr[0].Substring(4));
                Rate.ThirdRate = Convert.ToDouble(tmpStr[1].Substring(4));
                return Rate;
            }
            return Rate;
        }
    }
}