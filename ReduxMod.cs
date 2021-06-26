using System;
using SteviesModRedux.Common.Sets;
using SteviesModRedux.Common.Systems;
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
    }
}