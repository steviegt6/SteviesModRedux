using System.Reflection;
using MonoMod.RuntimeDetour;
using Terraria.ModLoader;

namespace SteviesModRedux.Common.Utilities
{
    public static class MonoModUtils
    {
        public static void ApplyHook(MethodInfo from, MethodInfo to)
        {
            MonoModHooks.RequestNativeAccess();
            new Hook(from, to).Apply();
        }
    }
}