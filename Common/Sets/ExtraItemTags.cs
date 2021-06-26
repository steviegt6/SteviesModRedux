using System;
using System.Linq;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using SteviesModRedux.Common.AdaptiveTagGroups;
using SteviesModRedux.Common.UnloadContext;
using SteviesModRedux.Common.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Tags;

namespace SteviesModRedux.Common.Sets
{
    public class ExtraItemTags : ILoadable
    {
        [NullifyUponUnload] public static TagData CoinStatDisplay { get; private set; }

        public void Load(Mod mod)
        {
            CoinStatDisplay = ContentTags.Get<AdaptiveItemTags>(nameof(CoinStatDisplay));
            CoinStatDisplay.Add(true, ItemID.CoinGun);

            IL.Terraria.Main.MouseText_DrawItemTooltip_GetLinesInfo += SwapCoinGun;
        }

        void ILoadable.Unload()
        {
        }

        private static void SwapCoinGun(ILContext il)
        {
            /*
             * Original block:
             * 	IL_0155: ldsfld class Terraria.Player[] Terraria.Main::player
	         *  IL_015a: ldsfld int32 Terraria.Main::myPlayer
	         *  IL_015f: ldelem.ref
	         *  IL_0160: ldc.i4 905
	         *  IL_0165: callvirt instance bool Terraria.Player::HasItem(int32)
	         *  IL_016a: br.s IL_016d
             *
             * Pops callvirt opcode and replaces it with our own delegate.
             *
             * Goal:
             *  Remove a hardcoded check for the Coin Gun in exchange for a generalized check for any item ID in CoinStatDisplay
             *  This allows other items to enable tooltips for coin damage and other stuff normally limited to the coin gun
             */

            ILCursor c = new(il);

            c.TryGotoNext(x => x.MatchCallvirt<Player>("HasItem"));
            //c.TryGotoPrev(x => x.MatchLdsfld<Main>("player"));
            //c.RemoveRange(5);
            c.Index++;
            c.Emit(OpCodes.Pop);

            c.EmitDelegate<Func<bool>>(() => CoinStatDisplay.GetEntries().Any(item => Main.LocalPlayer.HasItem(item)));
        }
    }
}