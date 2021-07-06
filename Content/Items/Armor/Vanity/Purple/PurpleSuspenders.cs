using Microsoft.Xna.Framework;
using SteviesModRedux.Common.Utilities;
using SteviesModRedux.Common.Utilities.ImplicitConverters;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items.Armor.Vanity.Purple
{
    [AutoloadEquip(EquipType.BodyLegacy)]
    public class PurpleSuspenders : VanityItem
    {
        private static readonly IntegerTuple[] Ingredients =
            {(ItemID.Silk, 16), ItemID.PurpleDye, (ItemID.SnowBlock, 5)};

        public override bool OverwriteTextureConditionally => false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Suspenders");
            Tooltip.SetDefault("'It's awfully cold'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.Size = new Vector2(32f, 36f);
            Item.value = GetValueFromItems(Ingredients);
        }

        public override void AddRecipes()
        {
            base.AddRecipes();

            CreateRecipe()
                .AddIngredients(Ingredients)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}