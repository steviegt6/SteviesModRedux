using Terraria.ModLoader.Tags;

namespace SteviesModRedux.Common.Utilities
{
    public static class TagDataUtilities
    {
        public static void Add(this TagData tag, bool toSet, params int[] ids)
        {
            foreach (int id in ids)
                tag.Set(id, toSet);
        }

        public static void Add(this TagData tag, params (int, bool)[] values)
        {
            foreach ((int id, bool value) in values)
                tag.Set(id, value);
        }
    }
}