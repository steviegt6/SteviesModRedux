using System;
using SteviesModRedux.Common.Systems;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SteviesModRedux
{
    public sealed class ReduxMod : Mod
    {
        public override object Call(params object[] args)
        {
            try
            {
                switch ((args[0] as string)?.ToLower())
                {
                    case "addsplashtext":
                        LocalizationSystem.SplashTexts.Add(Language.GetText(args[1] as string));
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