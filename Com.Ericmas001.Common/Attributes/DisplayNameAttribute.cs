using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; private set; }

        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
