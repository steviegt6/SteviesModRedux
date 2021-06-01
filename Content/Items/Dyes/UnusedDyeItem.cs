using Terraria.ID;

namespace SteviesModRedux.Content.Items.Dyes
{
    public abstract class UnusedDyeItem : ReduxItem
    {
        public sealed override int SacrificeCount => 1;

        public override string Texture => $"Terraria/Images/Item_{ItemID.BlackAndWhiteDye}";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.width = Item.height = 20;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
        }
    }
}