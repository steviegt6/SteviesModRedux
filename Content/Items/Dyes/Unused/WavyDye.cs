namespace SteviesModRedux.Content.Items.Dyes.Unused
{
    public class WavyDye : UnusedDyeItem
    {
        public override ItemSet ValueSet => base.ValueSet.SetNonColorfulDyeItem(true);

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Wavy Dye");
        }
    }
}