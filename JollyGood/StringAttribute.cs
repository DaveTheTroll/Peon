using System;
using System.Reflection;

namespace JollyGood
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class StringAttribute : Attribute
    {
        public StringAttribute(object key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
        public StringAttribute(string value) : this(null, value)
        {
        }

        public string Value { get; set; }
        public object Key { get; set; }

        public static string GetString(Enum x) { return GetString(x, null); }

        public static string GetString(Enum x, object key)
        {
            Type type = x.GetType();
            MemberInfo[] member = type.GetMember(x.ToString());
            string defaultString = null;
            foreach(StringAttribute attr in member[0].GetCustomAttributes(typeof(StringAttribute)))
            {
                if (attr.Key == null)
                {
                    if (key == null)
                        return attr.Value;
                    defaultString = attr.Value;
                }
                else if (attr.Key.Equals(key))
                    return attr.Value;
            }

            if (defaultString != null)
                return defaultString;

            return x.ToString();
        }
    }
}
