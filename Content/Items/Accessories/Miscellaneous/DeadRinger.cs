using SteviesModRedux.Content.Globals.Players;
using Terraria;

namespace SteviesModRedux.Content.Items.Accessories.Miscellaneous
{
    public class DeadRinger : AccessoryItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dead Ringer");
            Tooltip.SetDefault("'You'll already be behind him, poised for the killing blow.'");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DeadRingerPlayer>().HasDeadRinger = true;
        }
    }
}