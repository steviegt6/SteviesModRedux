using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SteviesModRedux.Content.Configs
{
    public class ReduxConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static ReduxConfig Instance { get; private set; }

        public override void OnLoaded()
        {
            Instance = this;
        }

        [Header("Testing")]
        [Label("Empty Test Recipes")]
        [DefaultValue(false)]
        public bool EmptyTestRecipes { get; set; }
    }
}