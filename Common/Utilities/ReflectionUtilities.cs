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

        public static TFieldType GetField<TType, TFieldType>(this TType obj, string field) =>
            (TFieldType) typeof(TType).GetField(field, AllFlags)?.GetValue(obj);

        public static void SetField<TType, TFieldType>(this TType obj, string property, TFieldType value) =>
            typeof(TType).GetField(property, AllFlags)?.SetValue(obj, value);

        public static TFieldType GetProperty<TType, TFieldType>(this TType obj, string field) =>
            (TFieldType) typeof(TType).GetProperty(field, AllFlags)?.GetValue(obj);

        public static void SetProperty<TType, TFieldType>(this TType obj, string setProperty, TFieldType value) =>
            typeof(TType).GetProperty(setProperty, AllFlags)?.SetValue(obj, value);

        public static MethodInfo GetMethod<TType>(this TType obj, string method) =>
            typeof(TType).GetMethodForced(method);

        public static void InvokeMethod<TType>(this TType obj, string method, params object[] parameters) =>
            obj.GetMethod(method).Invoke(obj, parameters);

        public static TReturn InvokeMethod<TType, TReturn>(this TType obj, string method, params object[] parameters) =>
            (TReturn) obj.GetMethod(method).Invoke(obj, parameters);
    }
}