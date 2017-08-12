using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.Common
{
    public static class EnumUtil
    {
        public static IEnumerable<T> AllValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }
        public static IEnumerable<Enum> AllValues(Type t)
        {
            return Enum.GetValues(t).OfType<Enum>().ToArray();
        }

        public static T Parse<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s, true);
        }
        private static readonly Dictionary<Type, Dictionary<Enum, Dictionary<Type, Attribute>>> m_Attributes = new Dictionary<Type, Dictionary<Enum, Dictionary<Type, Attribute>>>();

        public static TAtt GetAttribute<TAtt>(this Enum enumerationValue)
            where TAtt : Attribute
        {
            var t = enumerationValue.GetType();
            if (!m_Attributes.ContainsKey(t))
                m_Attributes.Add(t, new Dictionary<Enum, Dictionary<Type, Attribute>>());

            if (!m_Attributes[t].ContainsKey(enumerationValue))
                m_Attributes[t].Add(enumerationValue, new Dictionary<Type, Attribute>());

            var attType = typeof(TAtt);
            if (!m_Attributes[t][enumerationValue].ContainsKey(attType))
            {
                var memberInfo = t.GetMember(enumerationValue.ToString()).Where(x => x.DeclaringType == t).ToArray();
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

        public static bool HasSingleFlag(this Enum enumerationValue)
        {
            int value = Convert.ToInt32(enumerationValue);
            return value != 0 && (value & (value - 1)) == 0;
        }

        private static readonly Dictionary<Type, Dictionary<Enum, string>> m_Abbreviations = new Dictionary<Type, Dictionary<Enum, string>>();
        private static readonly Dictionary<Type, Dictionary<Enum, string>> m_Colors = new Dictionary<Type, Dictionary<Enum, string>>();
        private static readonly Dictionary<Type, Dictionary<Enum, string>> m_DisplayNames = new Dictionary<Type, Dictionary<Enum, string>>();
        private static readonly Dictionary<Type, Dictionary<Enum, string>> m_FrDisplayNames = new Dictionary<Type, Dictionary<Enum, string>>();
        private static readonly Dictionary<Type, Dictionary<Enum, string>> m_Tags = new Dictionary<Type, Dictionary<Enum, string>>();
        private static readonly Dictionary<Type, Dictionary<Enum, int>> m_Priorities = new Dictionary<Type, Dictionary<Enum, int>>();

        public static string Abbreviation(this Enum e)
        {
            var t = e.GetType();
            if (!m_Abbreviations.ContainsKey(t))
                m_Abbreviations.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<AbbreviationAttribute>()?.Abbreviation));

            return !m_Abbreviations[t].ContainsKey(e) ? null : m_Abbreviations[t][e];
        }
        public static string Color(this Enum e)
        {
            var t = e.GetType();
            if (!m_Colors.ContainsKey(t))
                m_Colors.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<ColorAttribute>()?.Color));

            return !m_Colors[t].ContainsKey(e) ? null : m_Colors[t][e];
        }
        public static string DisplayName(this Enum e)
        {
            var t = e.GetType();
            if (!m_DisplayNames.ContainsKey(t))
                m_DisplayNames.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<DisplayNameAttribute>()?.DisplayName ?? x.ToString()));

            return !m_DisplayNames[t].ContainsKey(e) ? e.ToString() : m_DisplayNames[t][e];
        }
        public static string DisplayNameFr(this Enum e)
        {
            var t = e.GetType();
            if (!m_FrDisplayNames.ContainsKey(t))
                m_FrDisplayNames.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<FrDisplayNameAttribute>()?.DisplayName ?? x.DisplayName()));

            return !m_FrDisplayNames[t].ContainsKey(e) ? e.DisplayName() : m_FrDisplayNames[t][e];
        }
        public static string Tag(this Enum e)
        {
            var t = e.GetType();
            if (!m_Tags.ContainsKey(t))
                m_Tags.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<TagAttribute>()?.Tag));

            return !m_Tags[t].ContainsKey(e) ? null : m_Tags[t][e];
        }
        public static int Priority(this Enum e)
        {
            var t = e.GetType();
            if (!m_Priorities.ContainsKey(t))
                m_Priorities.Add(t, AllValues(e.GetType()).ToDictionary(x => x, x => x.GetAttribute<PriorityAttribute>()?.Priority ?? 0));

            return !m_Priorities[t].ContainsKey(e) ? 0 : m_Priorities[t][e];
        }
    }
}
