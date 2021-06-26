using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Globals.Players
{
    public class DpsTrackerPlayer : ReduxPlayer
    {
        public List<(int, uint)> Damages { get; protected set; }

        public override void Initialize()
        {
            base.Initialize();

            Damages = new List<(int, uint)>();
        }

        public override void Load()
        {
            base.Load();

            On.Terraria.Player.getDPS += DpsHijacker;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(item, target, damage, knockback, crit);

            Damages.Add((damage, Main.GameUpdateCount));
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);

            Damages.Add((damage, Main.GameUpdateCount));
        }

        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            base.OnHitPvp(item, target, damage, crit);

            Damages.Add((damage, Main.GameUpdateCount));
        }

        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
        {
            base.OnHitPvpWithProj(proj, target, damage, crit);

            Damages.Add((damage, Main.GameUpdateCount));
        }

        private static int DpsHijacker(On.Terraria.Player.orig_getDPS orig, Player self)
        {
            for (int i = 0; i < self.GetModPlayer<DpsTrackerPlayer>().Damages.Count; i++)
                if (self.GetModPlayer<DpsTrackerPlayer>().Damages[i].Item2 < Main.GameUpdateCount - 60)
                    self.GetModPlayer<DpsTrackerPlayer>().Damages.RemoveAt(i);

            return self.GetModPlayer<DpsTrackerPlayer>().Damages.Sum(d => d.Item1);
        }
    }
}