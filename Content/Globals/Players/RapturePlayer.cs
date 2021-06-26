using System.Collections.Generic;
using SteviesModRedux.Common.RaptureSystem;

namespace SteviesModRedux.Content.Globals.Players
{
    public class RapturePlayer : ReduxPlayer
    {
        public List<IRapture> PlayerRaptures { get; protected set; }

        public override void Initialize()
        {
            base.Initialize();

            PlayerRaptures = new List<IRapture>();
        }

        public override void PreUpdate()
        {
            base.PreUpdate();

            // reset list every tick
            PlayerRaptures = new List<IRapture>();
        }
    }
}