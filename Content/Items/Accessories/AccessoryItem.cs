namespace SteviesModRedux.Content.Items.Accessories
{
    public abstract class AccessoryItem : ReduxItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.accessory = true;
        }
    }
}