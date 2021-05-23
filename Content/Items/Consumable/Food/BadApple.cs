using Microsoft.Xna.Framework;
using Terraria.ID;

namespace SteviesModRedux.Content.Items.Consumable.Food
{
    public class BadApple : FoodItem
    {
        public override int FoodBuff => BuffID.Poisoned;

        public override int BuffDuration => 60 * 1000;

        public override Color[] FoodParticleColors => new[]
            {Color.Green, Color.GreenYellow, Color.DarkOliveGreen};

        public override void SafeSetStaticDefaults()
        {
            DisplayName.SetDefault("Bad Apple (lol)");
            Tooltip.SetDefault(":(");
        }
    }
}