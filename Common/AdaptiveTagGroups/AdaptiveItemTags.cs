using System;
using Terraria.ModLoader;

namespace SteviesModRedux.Common.AdaptiveTagGroups
{
    public class AdaptiveItemTags : AdaptiveTagGroup
    {
        public override Func<int> GetTypeCount => () => ItemLoader.ItemCount;
    }
}