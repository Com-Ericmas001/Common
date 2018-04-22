using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class TagAttribute : Attribute
    {
        public string Tag { get; }

        public TagAttribute(string tag)
        {
            Tag = tag;
        }
    }
}
