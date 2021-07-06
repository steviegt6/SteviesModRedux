using SteviesModRedux.Common.Utilities;
using SteviesModRedux.Common.Utilities.ImplicitConverters;
using Terraria.ID;

namespace SteviesModRedux.Content.Items.Weapons.Ranger.Guns
{
    public class CoinPistol : WeaponItem
    {
        private static readonly IntegerTuple[] Ingredients = {ItemID.Handgun, ItemID.CoinGun};

        public override ItemSet ValueSet => base.ValueSet.SetForceCoinsToDisplayStats(true);

        public override bool OverwriteTexture => true;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Coin Pistol");
            Tooltip.SetDefault("Uses coins for ammo" +
                               "\nHigher valued coins do more damage" +
                               "\n'Greedier!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.CloneDefaults(ItemID.CoinGun);
            Item.useAnimation = Item.useTime = 15;
            Item.UseSound = SoundID.Item41;
            Item.damage += 50;
            Item.value = GetValueFromItems(Ingredients);
        }

        public override void AddRecipes()
        {
            base.AddRecipes();

            CreateRecipe()
                .AddIngredients(Ingredients)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}