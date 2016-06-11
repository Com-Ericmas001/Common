using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Ericmas001.Common
{
    public static class EnumUtil
    {
        public static IEnumerable<T> AllValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static T Parse<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
        private static readonly Dictionary<Type, Dictionary<Enum, Dictionary<Type, Attribute>>> m_Attributes = new Dictionary<Type, Dictionary<Enum, Dictionary<Type, Attribute>>>();

        public static TAtt GetAttribute<TAtt>(this Enum enumerationValue)
            where TAtt : Attribute
        {
            Type t = enumerationValue.GetType();
            if (!m_Attributes.ContainsKey(t))
                m_Attributes.Add(t, new Dictionary<Enum, Dictionary<Type, Attribute>>());

            if (!m_Attributes[t].ContainsKey(enumerationValue))
                m_Attributes[t].Add(enumerationValue, new Dictionary<Type, Attribute>());

            var attType = typeof(TAtt);
            if (!m_Attributes[t][enumerationValue].ContainsKey(attType))
            {
                var memberInfo = t.GetMember(enumerationValue.ToString());
                if (memberInfo.Any())
                {
                    var attrs = memberInfo[0].GetCustomAttributes(typeof(TAtt), false);
                    if (attrs.Any())
                        m_Attributes[t][enumerationValue].Add(attType, (TAtt)attrs.First());
                    else
                        m_Attributes[t][enumerationValue].Add(attType, null);
                }
                else
                    m_Attributes[t][enumerationValue].Add(attType, null);
            }
            return (TAtt)m_Attributes[t][enumerationValue][attType];
        }
    }
}
