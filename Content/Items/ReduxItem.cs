using System.Collections.Generic;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items
{
    public abstract class ReduxItem : ModItem
    {
        public override string Texture =>
            ModContent.TextureExists(base.Texture) ? base.Texture : "ModLoader/UnloadedItem";

        public abstract int SacrificeCount { get; }

        public sealed override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = SacrificeCount;

            AbstractSetStaticDefaults();
        }

        public virtual void AbstractSetStaticDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            AbstractSetDefaults();
        }

        public virtual void AbstractSetDefaults()
        {
        }

        public sealed override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            SafeModifyTooltips(tooltips);
        }

        public virtual void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
        }
    }
}