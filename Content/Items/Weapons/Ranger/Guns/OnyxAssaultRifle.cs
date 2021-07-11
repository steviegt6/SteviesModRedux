using Microsoft.Xna.Framework;
using SteviesModRedux.Common.Utilities;
using SteviesModRedux.Common.Utilities.ImplicitConverters;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace SteviesModRedux.Content.Items.Weapons.Ranger.Guns
{
    public class OnyxAssaultRifle : WeaponItem
    {
        private static readonly IntegerTuple[] Ingredients = {ItemID.OnyxBlaster, ItemID.ClockworkAssaultRifle};

        public override bool OverwriteTexture => true;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Onyx Assault Rifle");
            Tooltip.SetDefault("Three-round burst" +
                               "\nOnly the first shot consumes ammo");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.CloneDefaults(ItemID.ClockworkAssaultRifle);
            //Item.useAnimation *= 2;
            //Item.useTime *= 2;
            Item.damage += 5;
            Item.reuseDelay = (int) (Item.reuseDelay * 1.5f);
            Item.value = GetValueFromItems(Ingredients);
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position,
            Vector2 velocity, int type,
            int damage, float knockback)
        {
            base.Shoot(player, source, position, velocity, type, damage, knockback);

            switch (player.itemAnimation)
            {
                case < 5:
                    velocity.X += Main.rand.Next(-40, 41) * 0.01f;
                    velocity.Y += Main.rand.Next(-40, 41) * 0.01f;
                    velocity.X *= 1.1f;
                    velocity.Y *= 1.1f;
                    break;

                case < 10:
                    velocity.X += Main.rand.Next(-20, 21) * 0.01f;
                    velocity.Y += Main.rand.Next(-20, 21) * 0.01f;
                    velocity.X *= 1.05f;
                    velocity.Y *= 1.05f;
                    break;

                default:
                    Projectile.NewProjectile(source, position, velocity, 661, (int)(damage * 2.5f), knockback, player.whoAmI);
                    break;
            }

            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false;
        }

        public override bool ConsumeAmmo(Player player) => player.itemAnimation > Item.useAnimation - 2;

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