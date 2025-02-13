using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_раб_9
{
    public class Logic
    {
        public static double MathematicalRound(double c, int roun)
        {
            if (roun < 0)
            {
                throw new ArgumentException("Количество знаков после запятой не может быть отрицательным.");
            }

            double mult = 1;
            for (int i = 0; i < roun; i++)
            {
                mult *= 10;
            }

            double result = c * mult;
            if (result >= 0)
            {
                result += 0.5;
            }
            else
                result -= 0.5;
            result = (int)result;
            return result/mult;
        }
    }
}
