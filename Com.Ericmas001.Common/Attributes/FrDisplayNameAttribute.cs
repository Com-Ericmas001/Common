using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class FrDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }

        public FrDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
