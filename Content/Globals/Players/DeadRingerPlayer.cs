using Terraria;
using Terraria.ID;

namespace SteviesModRedux.Content.Globals.Players
{
    public class DeadRingerPlayer : ReduxPlayer
    {
        public virtual int DeadRingerInvisibilityTime { get; set; }

        public virtual bool DeadRingerInvincibility { get; set; }

        public virtual int DeadRingerCooldownTime { get; set; }

        public virtual bool HasDeadRinger { get; set; }

        // public virtual int ClonedPlayer { get; set; }

        // public virtual int ClonedPlayerTimeAlive { get; set; }

        public override void ResetEffects()
        {
            HasDeadRinger = false;
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (Main.rand.NextBool(20) && HasDeadRinger)
                SetDeadRinger(ref damage);
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (Main.rand.NextBool(20) && HasDeadRinger)
                SetDeadRinger(ref damage);
        }

        public virtual void SetDeadRinger(ref int damage)
        {
            if (damage > 0)
                damage = 0;

            DeadRingerInvisibilityTime = 60 * 3;
            DeadRingerInvincibility = true;
        }

        public override void PostUpdate()
        {
            // UpdateClonedBody();

            if (DeadRingerCooldownTime > 0)
                DeadRingerCooldownTime--;

            if (DeadRingerInvisibilityTime > 0)
            {
                Player.invis = true;
                DeadRingerInvisibilityTime--;
            }

            if (!DeadRingerInvincibility || DeadRingerCooldownTime > 0)
                return;

            Player.SetImmuneTimeForAllTypes(Player.longInvince ? 160 : 120);
            DeadRingerInvincibility = false;
            DeadRingerCooldownTime = 60 * 5;
            // GenerateClonedBody();
        }

        /* public virtual void GenerateClonedBody()
        {
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] is null)
                {
                    Main.player[i] = (Player) Player.clientClone();
                    ClonedPlayer = i;
                }

            ClonedPlayerTimeAlive = 0;

            Player player = Main.player[ClonedPlayer];

            player.headVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
            player.bodyVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
            player.legVelocity.Y = Main.rand.Next(-40, -10) * 0.1f;
            player.headVelocity.X = Main.rand.Next(-20, 21) * 0.1f;
            player.bodyVelocity.X = Main.rand.Next(-20, 21) * 0.1f;
            player.legVelocity.X = Main.rand.Next(-20, 21) * 0.1f;

            for (int i = 0; i < 100; i++)
                Dust.NewDust(player.position, player.width, player.height, DustID.Blood,
                    2f * (Main.rand.NextBool() ? -1f : 1f), -2f);
        }

        public virtual void UpdateClonedBody()
        {
            if (Main.player[ClonedPlayer] is null)
                return;

            Main.player[ClonedPlayer].UpdateDead();

            ClonedPlayerTimeAlive++;

            if (ClonedPlayerTimeAlive > 60 * 5)
                Main.player[ClonedPlayer] = null;
        }*/
    }
}