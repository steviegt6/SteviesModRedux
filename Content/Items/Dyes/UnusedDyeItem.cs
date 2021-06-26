using Terraria.ID;

namespace SteviesModRedux.Content.Items.Dyes
{
    public abstract class UnusedDyeItem : ReduxItem
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.BlackAndWhiteDye}";

        public override ItemSet ValueSet => base.ValueSet.SetSacrificeCount(1);

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.width = Item.height = 20;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Blue;
        }
    }
}