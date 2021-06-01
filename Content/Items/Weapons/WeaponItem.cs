using Terraria.ID;

namespace SteviesModRedux.Content.Items.Weapons
{
    public abstract class WeaponItem : ReduxItem
    {
        public override int SacrificeCount => 1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }
    }
}