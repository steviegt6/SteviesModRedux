using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SteviesModRedux.Common.UnloadContext;
using SteviesModRedux.Common.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SteviesModRedux.Common.Systems
{
    public sealed class LocalizationSystem : ModSystem
    {
        public static string[] ExistingJsonFiles => new[]
        {
            "UI.json",
            "Splashes.json"
        };

        /// <summary>
        ///     A dictionary of automatically-registered translations. Keys are localization keys.
        /// </summary>
        [NullifyUponUnload]
        public static Dictionary<string, ModTranslation> AutoRegisteredTranslations { get; private set; }

        /// <summary>
        ///     List of all Splash Texts. Most are automatically-registered.
        /// </summary>
        [NullifyUponUnload]
        public static List<ModTranslation> SplashTexts { get; private set; }

        public override void OnModLoad()
        {
            AutoRegisteredTranslations = new Dictionary<string, ModTranslation>();

            foreach (string culture in GetCultures())
            foreach (string fileName in ExistingJsonFiles)
            {
                try
                {
                    using Stream stream = Mod.GetFileStream(GetFilePath(culture, fileName));
                    foreach ((string s, Dictionary<string, string> dictionary) in
                        JsonUtilities.DeserializeJsonFromStream<Dictionary<string, Dictionary<string, string>>>(stream))
                    {
                        foreach ((string key, string value) in dictionary)
                            GetOrCreateTranslation($"{s}.{key}").AddTranslation(culture, value);
                    }
                }
                catch (KeyNotFoundException)
                {
                    // ignore if localization file doesn't exist
                }
            }

            foreach (ModTranslation translation in AutoRegisteredTranslations.Values)
                Mod.AddTranslation(translation);
        }

        public override void PostSetupContent()
        {
            SplashTexts = new List<ModTranslation>();

            // In post-setup content to allow other mods to register localizations
            // following the same format, if they wish to register their own
            // (https://github.com/Steviegt6/SteviesModRedux/wiki/Splash-Text)
            foreach (Mod mod in ModLoader.Mods)
            {
                ICollection<ModTranslation> modTranslations = (typeof(Mod)
                    .GetField("translations", ReflectionUtilities.AllFlags)
                    ?.GetValue(mod) as IDictionary<string, ModTranslation>)?.Values;

                if (modTranslations == null) 
                    continue;

                foreach (ModTranslation translation in modTranslations.Where(x => x.Key.Contains(".Splashes.")))
                    SplashTexts.Add(translation);
            }

            ModMenuSplashTextSystem.CycleText();
        }

        /// <summary>
        ///     Creates or gets a translation from <see cref="AutoRegisteredTranslations"/>. If a translation is created, it will be added to <see cref="AutoRegisteredTranslations"/>.
        /// </summary>
        public ModTranslation GetOrCreateTranslation(string key)
        {
            if (AutoRegisteredTranslations.ContainsKey(key))
                return AutoRegisteredTranslations[key];

            ModTranslation translation = Mod.CreateTranslation(key);
            AutoRegisteredTranslations.Add(key, translation);
            return translation;
        }

        /// <summary>
        ///     Returns an array containing the names of all localizable cultures.
        /// </summary>
        public static string[] GetCultures() => Enum.GetValues<GameCulture.CultureName>()
            .Select(name => GameCulture.FromCultureName(name).Name).ToArray();

        /// <summary>
        ///     Returns the would-be path for any file contained in SM:R's "Localization" sub-directory, given the culture.
        /// </summary>
        public static string GetFilePath(string culture, string fileName) =>
            Path.Combine("Localization", culture, fileName);
    }
}