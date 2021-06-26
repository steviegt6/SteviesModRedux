using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;

namespace SteviesModRedux.Content.Items.Consumable
{
    public abstract class FoodItem : ReduxItem
    {
        public abstract int FoodBuff { get; }

        public abstract int BuffDuration { get; }

        public abstract Color[] FoodParticleColors { get; }

        public override ItemSet ValueSet => base.ValueSet.SetSacrificeCount(5).SetIsFood(true)
            .SetFoodParticleColors(FoodParticleColors);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
        }

        public sealed override void SetDefaults()
        {
            base.SetDefaults();

            Item.DefaultToFood(Item.width, Item.height, FoodBuff, BuffDuration);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(gold: 1));
        }
    }
}