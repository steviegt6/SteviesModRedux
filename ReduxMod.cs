using System;
using System.Linq;
using System.Reflection;
using SteviesModRedux.Common.Systems;
using SteviesModRedux.Common.UnloadContext;
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

        public override void Unload()
        {
            foreach (Type type in Code.GetTypes())
            {
                foreach (FieldInfo field in type.GetFields()
                    .Where(x => x.GetCustomAttribute<SetUponUnloadAttribute>() != null && x.IsStatic))
                    field.SetValue(null, field.GetCustomAttribute<SetUponUnloadAttribute>()!.Value);

                foreach (PropertyInfo property in type.GetProperties()
                    .Where(x => x.GetCustomAttribute<SetUponUnloadAttribute>() != null && x.CanWrite &&
                                (x.SetMethod?.IsStatic ?? false)))
                    property.SetValue(null, property.GetCustomAttribute<SetUponUnloadAttribute>()!.Value);
            }
        }
    }
}