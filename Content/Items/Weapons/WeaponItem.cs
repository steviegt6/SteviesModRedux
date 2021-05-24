using Terraria.ID;

namespace SteviesModRedux.Content.Items.Weapons
{
    public abstract class WeaponItem : ReduxItem
    {
        public override int SacrificeCount => 1;

        public sealed override void AbstractSetStaticDefaults()
        {
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;

            SafeSetStaticDefaults();
        }

        public virtual void SafeSetStaticDefaults()
        {
        }

        public sealed override void AbstractSetDefaults()
        {
            SafeSetDefaults();
        }

        public virtual void SafeSetDefaults()
        {
        }
    }
}