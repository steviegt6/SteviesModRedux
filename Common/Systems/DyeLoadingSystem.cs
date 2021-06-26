using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SteviesModRedux.Content.Items.Dyes.Unused;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesModRedux.Common.Systems
{
    public class DyeLoadingSystem : ModSystem
    {
        public static List<(int, string, string)> ArmorShaders { get; private set; }

        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
                return;

            ArmorShaders = PopulateArmorShaders();

            foreach ((int itemType, string effectPath, string pathName) in ArmorShaders)
                BindArmorShader(itemType, CreateArmorData(GetEffect(effectPath), pathName));
        }

        public static void BindArmorShader(int itemType, ArmorShaderData shaderData) =>
            GameShaders.Armor.BindShader(itemType, shaderData);

        public static ArmorShaderData CreateArmorData(Ref<Effect> effectReference, string pass) =>
            new(effectReference, pass);

        public static Ref<Effect> GetEffect(string effectPath) =>
            new(ModContent.Request<Effect>("SteviesModRedux/Effects/Wavy").Value);

        public static List<(int, string, string)> PopulateArmorShaders() => new()
        {
            (ModContent.ItemType<WavyDye>(), "SteviesModRedux/Effects/Wavy", "WavyPass")
        };
    }
}