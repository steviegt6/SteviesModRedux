namespace SteviesModRedux.Content.Items.Armor.Vanity
{
    public abstract class VanityItem : ArmorItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.vanity = true;
        }
    }
}