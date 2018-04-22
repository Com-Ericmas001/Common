using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class ColorAttribute : Attribute
    {
        public string Color { get; }

        public ColorAttribute(string color)
        {
            Color = color;
        }
    }
}
