using System;
using Microsoft.Xna.Framework.Graphics;
using SteviesModRedux.Common.Sets;
using SteviesModRedux.Common.Systems;
using SteviesModRedux.Content.Items.Dyes.Unused;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesModRedux
{
    public sealed class ReduxMod : Mod
    {
        public static ReduxMod Instance { get; private set; }

        public ReduxMod()
        {
            Instance = this;
        }

        public override void Load()
        {
            LoadDyes();
            ExtraItemTags.Load(this);
        }

        public override object Call(params object[] args)
        {
            try
            {
                switch ((args[0] as string)?.ToLower())
                {
                    case "addsplashtext":
                        LocalizationSystem.SplashTexts.Add(args[1] as ModTranslation);
                        return null;

                    case "removesplashtext":
                        LocalizationSystem.SplashTexts.RemoveAll(x => x.Key.Equals(args[1] as string));
                        return null;
                }
            }
            catch (IndexOutOfRangeException)
            {
                // ignore, maybe un-ignore later?
            }

            return null;
        }

        private void LoadDyes()
        {
            if (Main.netMode == NetmodeID.Server)
                return;

            Ref<Effect> waveRef = new(GetEffect("Effects/Wavy").Value);
            const string wavePass = "WavyPass";

            GameShaders.Armor.BindShader(ModContent.ItemType<WavyDye>(),
                new ArmorShaderData(waveRef, wavePass));
        }
    }
}