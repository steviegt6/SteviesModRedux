using System;
using System.Collections.Generic;

namespace SteviesModRedux.Common.Utilities
{
    public static class CollectionUtils
    {
        public static void Replace<T>(this IList<T> list, T match, T value)
        {
            int index = list.IndexOf(match);
            list.Remove(match);
            list.Insert(index, value);
        }

        public static T[] ArrayAdd<T>(this T[] array, T value)
        {
            Array.Resize(ref array, array.Length);
            array[^1] = value;
            return array;
        }
    }
}