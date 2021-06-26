using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Projectiles
{
    public abstract class ReduxProjectile : ModProjectile
    {
        public override string Texture =>
            ModContent.RequestIfExists<Texture2D>(base.Texture, out _) ? base.Texture : "ModLoader/UnloadedItem";
    }
}