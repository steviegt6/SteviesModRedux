using Terraria.ModLoader;

namespace SteviesModRedux.Content.Projectiles
{
    public abstract class ReduxProjectile : ModProjectile
    {
        public override string Texture =>
            ModContent.TextureExists(base.Texture) ? base.Texture : "ModLoader/UnloadedItem";
    }
}