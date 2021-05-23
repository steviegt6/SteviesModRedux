using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;

namespace SteviesModRedux.Content.Items.Consumable
{
    public abstract class FoodItem : ReduxItem
    {
        public override int SacrificeCount => 5;

        public abstract int FoodBuff { get; }

        public abstract int BuffDuration { get; }

        public abstract Color[] FoodParticleColors { get; }

        public sealed override void AbstractSetStaticDefaults()
        {
            ItemID.Sets.IsFood[Type] = true;
            ItemID.Sets.FoodParticleColors[Type] = FoodParticleColors;

            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));

            SafeSetStaticDefaults();
        }

        public virtual void SafeSetStaticDefaults()
        {
        }

        public sealed override void AbstractSetDefaults()
        {
            SafeSetDefaults();

            Item.DefaultToFood(Item.width, Item.height, FoodBuff, BuffDuration);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(gold: 1));
        }

        public virtual void SafeSetDefaults()
        {
        }
    }
}