using System;

namespace d01_ex00
{
    class TExchangeSum
    {
        public double[] AllSum(double Sum, t_Rate Rate)
        {
            double SecondSum;
            double ThirdSum;
            double[] AllSum = new double[3];

            SecondSum = Sum * Rate.SecondRate;
            ThirdSum = Sum * Rate.ThirdRate;
            AllSum[0] = Math.Round(Sum, 2);
            AllSum[1] = Math.Round(SecondSum, 2);
            AllSum[2] = Math.Round(ThirdSum, 2);
            return AllSum;
        }
    }
}