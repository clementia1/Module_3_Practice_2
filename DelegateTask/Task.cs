using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3_Practice_2
{
    public class Task
    {
        public event Func<double, double, double> OnSum;

        public double TotalSum()
        {
            OnSum += Sum;
            OnSum += Sum;

            double sum = 0;

            TryMethod(() =>
            {
                foreach (var method in OnSum.GetInvocationList())
                {
                    sum += (double)method.DynamicInvoke(4, 5);
                }
            });

            return sum;
        }

        private double Sum(double a, double b)
        {
            return a + b;
        }

        private void TryMethod(Action someAction)
        {
            try
            {
                someAction();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}