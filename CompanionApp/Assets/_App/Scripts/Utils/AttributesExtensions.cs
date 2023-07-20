using System;
using System.Linq;

namespace Utils
{
    public static class AttributesExtensions
    {
        public static T GetAttribute<T>(this Type target) where T : Attribute
        {
            var attributeType = typeof(T);
            var attr = target.GetCustomAttributes(attributeType, false).FirstOrDefault() as T;
            return attr;
        }
    }
}