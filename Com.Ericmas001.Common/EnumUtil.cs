using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Com.Ericmas001.Common
{
    public static class EnumUtil<T>
    {
        public static T[] AllValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();

        private static Dictionary<T, Dictionary<Type, Attribute>> m_Attributes = new Dictionary<T, Dictionary<Type, Attribute>>();

        public static TAtt GetAttribute<TAtt>(T enumerationValue)
            where TAtt : Attribute
        {
            if (!m_Attributes.ContainsKey(enumerationValue))
                m_Attributes.Add(enumerationValue, new Dictionary<Type, Attribute>());

            Type attType = typeof(TAtt);
            if (!m_Attributes[enumerationValue].ContainsKey(attType))
            {
                MemberInfo[] memberInfo = typeof(T).GetMember(enumerationValue.ToString());
                if (memberInfo.Any())
                {
                    object[] attrs = memberInfo[0].GetCustomAttributes(typeof(TAtt), false);
                    if (attrs.Any())
                        m_Attributes[enumerationValue].Add(attType, (TAtt)attrs.First());
                    else
                        m_Attributes[enumerationValue].Add(attType, null);
                }
                else
                    m_Attributes[enumerationValue].Add(attType, null);
            }
            return (TAtt)m_Attributes[enumerationValue][attType];
        }
    }
}
