using System.Collections.Generic;

namespace SteviesModRedux.Common.Utilities
{
    public static class ListUtils
    {
        public static void Replace<T>(this IList<T> list, T match, T value)
        {
            int index = list.IndexOf(match);
            list.Remove(match);
            list.Insert(index, value);
        }
    }
}