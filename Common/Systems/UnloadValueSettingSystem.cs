using System;
using System.Linq;
using System.Reflection;
using MonoMod.RuntimeDetour;
using SteviesModRedux.Common.UnloadContext;
using SteviesModRedux.Common.Utilities;
using Terraria.ModLoader;

namespace SteviesModRedux.Common.Systems
{
    public sealed class UnloadValueSettingSystem : ModSystem
    {
        public override void OnModLoad()
        {
            MonoModHooks.RequestNativeAccess();

            new Hook(typeof(ModLoader).GetCachedMethod("Mods_Unload"),
                typeof(UnloadValueSettingSystem).GetCachedMethod(nameof(HijackUnloading))).Apply();
        }

        private static void HijackUnloading(Action orig)
        {
            orig();

            foreach (Mod mod in ModLoader.Mods)
            foreach (Type type in mod.Code.GetTypes())
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