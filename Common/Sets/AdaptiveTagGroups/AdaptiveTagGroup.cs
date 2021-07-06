using System;
using System.Collections.Generic;
using SteviesModRedux.Common.Utilities;
using Terraria.ModLoader.Tags;

namespace SteviesModRedux.Common.Sets.AdaptiveTagGroups
{
    public abstract class AdaptiveTagGroup : TagGroup
    {
        public override int TypeCount => GetTypeCount();

        public abstract Func<int> GetTypeCount { get; }

        public Dictionary<string, TagData> VisibleTagNameToData => typeof(TagGroup).GetCachedField("TagNameToData")
            .GetValue<Dictionary<string, TagData>>(this);

        protected AdaptiveTagGroup()
        {
            MonoModUtils.ApplyHook(typeof(TagGroup).GetCachedMethod(nameof(GetTag)),
                typeof(AdaptiveTagGroup).GetCachedMethod(nameof(NewGetTag)));

            MonoModUtils.ApplyHook(typeof(TagData).GetCachedMethod(nameof(TagData.Set)),
                typeof(AdaptiveTagGroup).GetCachedMethod(nameof(NewSet)));
        }

        public static TagData NewGetTag(AdaptiveTagGroup self, string tagName)
        {
            if (!self.VisibleTagNameToData.TryGetValue(tagName, out TagData tag))
                typeof(TagGroup).GetCachedField("TagNameToData")
                    .GetValue<Dictionary<string, TagData>>(self)[tagName] = tag = typeof(TagData)
                    .GetCachedConstructor(typeof(int))
                    .Invoke(new object[] {self.GetTypeCount()}) as TagData;

            bool[] values = typeof(TagData).GetCachedField("idToValue").GetValue<bool[]>(tag);

            if (values.Length >= self.GetTypeCount())
                return tag;

            Array.Resize(ref values, self.GetTypeCount() + 1);
            typeof(TagData).GetCachedField("idToValue").SetValue(tag, values);

            return tag;
        }

        public static void NewSet(Action<TagData, int, bool> orig, TagData self, int id, bool value)
        {
            bool[] values = typeof(TagData).GetCachedField("idToValue").GetValue<bool[]>(self);

            if (values.Length < id)
            {
                Array.Resize(ref values, id + 1);
                typeof(TagData).GetCachedField("idToValue").SetValue(self, values);
            }

            orig(self, id, value);
        }
    }
}