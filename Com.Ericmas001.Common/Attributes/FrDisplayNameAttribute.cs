using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class FrDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; private set; }

        public FrDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
