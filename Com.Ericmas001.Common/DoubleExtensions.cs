﻿using System;

namespace Com.Ericmas001.Common
{
    public static class DoubleExtensions
    {
        public static bool Is(this double d1, double d2)
        {
            return Math.Abs(d1 - d2) < double.Epsilon;
        }
    }
}
