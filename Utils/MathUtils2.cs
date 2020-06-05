using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Utils
{
    /*Автор: Полятыкина Татьяна*/

    public static partial class MathUtils
    {
        /// <summary>
        /// Расчет индекса массы тела
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static double CalcBodyMassaIndex(double height, double weight)
        {
            if (height == 0) return 0;

            return weight / (height * height);
        }

        public static double CalcBodyMassaToNorm(double height, double koeff)
        {
            if (height == 0) return 0;

            return koeff * height * height;
        }
    }
}
