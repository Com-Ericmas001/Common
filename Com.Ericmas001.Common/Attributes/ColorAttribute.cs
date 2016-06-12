using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class ColorAttribute : Attribute
    {
        public string Color { get; private set; }

        public ColorAttribute(string color)
        {
            Color = color;
        }
    }
}
