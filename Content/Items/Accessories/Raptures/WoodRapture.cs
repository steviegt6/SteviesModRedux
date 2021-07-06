namespace SteviesModRedux.Content.Items.Accessories.Raptures
{
    public class WoodRapture : AccessoryItem
    {
        public override bool OverwriteTexture => true;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Wood Rapture");
        }
    }
}