using System;

namespace Com.Ericmas001.Common
{
    public static class RandomUtil
    {
        private static readonly Random m_Random = new Random();

        public static int RandomWithMax(int max)
        {
            return max > 0 ? m_Random.Next(max + 1) : max;
        }

        public static int RandomWithMin(int min)
        {
            return min < 0 ? -m_Random.Next(-min + 1) : min;
        }

        public static int RandomWithLength(int startVal, int length)
        {
            if (length == 0)
                return length;
            return startVal + length > 0 ? m_Random.Next(length) : -m_Random.Next(-length);
        }

        public static int RandomMinMax(int min, int max)
        {
            if (min == max)
                return min;

            var theMin = Math.Min(min, max);
            var theMax = Math.Max(min, max);

            return theMin + m_Random.Next((theMax - theMin) + 1);
        }

        public static bool RandomBool()
        {
            return m_Random.Next(2) == 0;
        }
    }
}
