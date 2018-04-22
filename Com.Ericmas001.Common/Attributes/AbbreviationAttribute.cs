using System;

namespace Com.Ericmas001.Common.Attributes
{
    public class AbbreviationAttribute : Attribute
    {
        public string Abbreviation { get; }

        public AbbreviationAttribute(string abbreviation)
        {
            Abbreviation = abbreviation;
        }
    }
}
