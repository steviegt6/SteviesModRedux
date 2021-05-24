using Terraria.ModLoader;

namespace SteviesModRedux.Content.Projectiles
{
    public abstract class ReduxProjectile : ModProjectile
    {
        public override string Texture =>
            ModContent.TextureExists(base.Texture) ? base.Texture : "ModLoader/UnloadedItem";


        public sealed override void SetStaticDefaults()
        {
            AbstractSetStaticDefaults();
        }

        public virtual void AbstractSetStaticDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            AbstractSetDefaults();
        }

        public virtual void AbstractSetDefaults()
        {
        }
    }
}