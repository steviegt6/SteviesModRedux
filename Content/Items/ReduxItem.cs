using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items
{
    public abstract class ReduxItem : ModItem
    {
        public override string Texture =>
            ModContent.RequestIfExists<Texture2D>(base.Texture, out _) ? base.Texture : "ModLoader/UnloadedItem";

        public abstract int SacrificeCount { get; }

        public virtual int GetValueFromItems(params int[] items)
        {
            int total = 0;

            foreach (int item in items)
            {
                Item instance = new();
                instance.SetDefaults(item, true);
                total += instance.value;
            }

            return total;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = SacrificeCount;
        }
    }
}