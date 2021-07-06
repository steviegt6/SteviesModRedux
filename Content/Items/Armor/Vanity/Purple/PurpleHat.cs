using Microsoft.Xna.Framework;
using SteviesModRedux.Common.Utilities;
using SteviesModRedux.Common.Utilities.ImplicitConverters;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items.Armor.Vanity.Purple
{
    [AutoloadEquip(EquipType.Head)]
    public class PurpleHat : VanityItem
    {
        private static readonly IntegerTuple[] Ingredients =
            {(ItemID.Silk, 20), ItemID.PurpleDye, (ItemID.SnowBlock, 5)};

        public override bool OverwriteTextureConditionally => false;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Purple Hat");
            Tooltip.SetDefault("'It's awfully cold'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.Size = new Vector2(22f, 24f);
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