namespace SteviesModRedux.Content.Items.Weapons
{
    public abstract class WeaponItem : ReduxItem
    {
        public override ItemSet ValueSet => base.ValueSet.SetSacrificeCount(1).SetCanBePlacedOnWeaponRacks(true);
    }
}