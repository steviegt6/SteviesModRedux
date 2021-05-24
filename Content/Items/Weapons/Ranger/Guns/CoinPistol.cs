using SteviesModRedux.Common.Utilities;
using Terraria.ID;

namespace SteviesModRedux.Content.Items.Weapons.Ranger.Guns
{
    public class CoinPistol : WeaponItem
    {
        public override void SafeSetStaticDefaults()
        {
            DisplayName.SetDefault("Coin Pistol");
            Tooltip.SetDefault("Uses coins for ammo" +
                               "\nHigher valued coins do more damage" +
                               "\n'Greedier!'");
        }

        public override void SafeSetDefaults()
        {
            Item.CloneDefaults(ItemID.CoinGun);
            Item.useAnimation = Item.useTime = 15;
            Item.UseSound = SoundID.Item41;
            Item.damage += 50;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredients(ItemID.Handgun, ItemID.CoinGun)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}