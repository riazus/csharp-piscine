using System;

namespace d01_ex00
{
    struct t_Data
    {
        public double MainSum;
        public double SecondSum;
        public double ThirdSum;
        public string MainValue;
        public string SecondVal;
        public string ThirdVal;
    }
    class TExcganger
    {
        t_Data PutInData(double[] AllSum, string Value)
        {
            t_Data Data = new t_Data();
            if (Value == "RUB")
            {
                Data.MainValue = "RUB";
                Data.SecondVal = "USD";
                Data.ThirdVal = "EUR";
            }
            else if (Value == "USD")
            {
                Data.MainValue = "USD";
                Data.SecondVal = "RUB";
                Data.ThirdVal = "EUR";
            }
            else if (Value == "EUR")
            {
                Data.MainValue = "EUR";
                Data.SecondVal = "USD";
                Data.ThirdVal = "RUB";
            }
            Data.MainSum = AllSum[0];
            Data.SecondSum = AllSum[1];
            Data.ThirdSum = AllSum[2];
            return Data;
        }
        public t_Data Exchange(double Sum, string Value, string Path)
        {
            TExchangeRate ExchangeRate = new TExchangeRate();
            TExchangeSum ExchangeSum = new TExchangeSum();
            t_Data Data = new t_Data();
            t_Rate Rate = new t_Rate();
            double[] AllSum = new double[3];
            Rate = ExchangeRate.WhichValue(Value, Path);
            AllSum = ExchangeSum.AllSum(Sum, Rate);
            Data = PutInData(AllSum, Value);
            return Data;
        }

    }
}