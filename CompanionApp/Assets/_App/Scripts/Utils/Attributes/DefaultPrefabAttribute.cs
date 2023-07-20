using System;

namespace Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultPrefabAttribute : Attribute
    {
        public string PrefabPath { get; }

        public DefaultPrefabAttribute(string resourcePath)
        {
            PrefabPath = resourcePath;
        }
    }
}