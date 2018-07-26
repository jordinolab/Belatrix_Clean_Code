using System;

namespace SOLID._01_SingleResponsability
{
    public class Sample
    {
        int sumResult = 0;
        public void EvaluateRangeOfSum(int num1, int num2)
        {
            var message = GetSumRangeEvaluatedMessage(num1, num2);

            PrintMessage(sumResult, message);
        }

        private string GetSumRangeEvaluatedMessage(int num1, int num2)
        {
            sumResult = Sum(num1, num2);

            if (EvaluateRange(0, 10))
                return "Value between 0 and 10";

            if (EvaluateRange(10, 20))
                return "Value between 11 and 20";

            if (EvaluateRange(20, 30))
                return "Value between 11 and 20";

            return string.Empty;
        }

        private bool EvaluateRange(int minRange, int maxRange)
        {
            return sumResult > minRange && sumResult <= maxRange;
        }

        private int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        private void PrintMessage(int sum, string message)
        {
            Console.WriteLine(string.Format("The sum is: {0} and is in range {1}", sum, message));
        }
    }
}
