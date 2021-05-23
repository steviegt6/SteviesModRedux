using System;
using System.Reflection;

namespace SteviesModRedux.Common.Utilities
{
    public static class ReflectionUtilities
    {
        /// <summary>
        ///     Includes <see cref="BindingFlags.Public"/>, <see cref="BindingFlags.NonPublic"/>, <see cref="BindingFlags.Instance"/>, and <see cref="BindingFlags.Static"/>.
        /// </summary>
        public static BindingFlags AllFlags => BindingFlags.Public
                                               | BindingFlags.NonPublic
                                               | BindingFlags.Instance
                                               | BindingFlags.Static;

        /// <summary>
        ///     Equivalent of calling <see cref="Type.GetMethod(string, BindingFlags)"/> with the given <paramref name="type"/> and <paramref name="method"/>, but <see cref="AllFlags"/> is used.
        /// </summary>
        public static MethodInfo GetMethodForced(this Type type, string method) => type.GetMethod(method, AllFlags);
    }
}