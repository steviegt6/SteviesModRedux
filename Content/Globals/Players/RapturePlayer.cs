using System.Collections.Generic;
using SteviesModRedux.Common.RaptureSystem;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Globals.Players
{
    public class RapturePlayer : ModPlayer
    {
        public List<IRapture> PlayerRaptures { get; protected set; }

        public override void Initialize()
        {
            PlayerRaptures = new List<IRapture>();
        }

        public override void PreUpdate()
        {
            // reset list every tick
            PlayerRaptures = new List<IRapture>();
        }
    }
}