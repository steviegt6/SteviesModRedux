using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items
{
    public abstract class ReduxItem : ModItem
    {
        public class ItemSet
        {
            public int SacrificeCount { get; protected set; }

            public ItemSet SetSacrificeCount(int sacrificeCount)
            {
                SacrificeCount = sacrificeCount;
                return this;
            }
        }

        public override string Texture =>
            ModContent.RequestIfExists<Texture2D>(base.Texture, out _) ? base.Texture : "ModLoader/UnloadedItem";

        protected ItemSet ItemValues;

        public virtual ItemSet ValueSet
        {
            get => ItemValues ??= new ItemSet();

            set => ItemValues = value;
        }

        public override void SetStaticDefaults()
        {
            SetItemSetValues();
        }

        public virtual int GetValueFromItems(params int[] items)
        {
            int total = 0;

            foreach (int item in items)
            {
                Item instance = new();
                instance.SetDefaults(item, true);
                total += instance.value;
            }

            return total;
        }

        public virtual void SetItemSetValues()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = ValueSet.SacrificeCount;
        }
    }
}