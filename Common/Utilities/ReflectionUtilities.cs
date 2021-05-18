using System;
using System.Reflection;

namespace SteviesModRedux.Common.Utilities
{
    public static class ReflectionUtilities
    {
        public static BindingFlags AllFlags => BindingFlags.Public
                                               | BindingFlags.NonPublic
                                               | BindingFlags.Instance
                                               | BindingFlags.Static;

        public static MethodInfo GetMethodForced(this Type type, string method) => type.GetMethod(method, AllFlags);
    }
}