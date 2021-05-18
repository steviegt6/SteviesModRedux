using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Terraria;
using Terraria.GameContent;
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

        public static Dictionary<string, ModTranslation> AutoRegisteredTranslations { get; private set; }

        public static List<ModTranslation> SplashTexts { get; private set; }

        public override void OnModLoad()
        {
            AutoRegisteredTranslations = new Dictionary<string, ModTranslation>();
            SplashTexts = new List<ModTranslation>();

            foreach (string culture in GetCultures())
            foreach (string fileName in ExistingJsonFiles)
            {
                try
                {
                    using Stream stream = Mod.GetFileStream(GetFilePath(culture, fileName));
                    foreach ((string s, Dictionary<string, string> dictionary) in
                        DeserializeJsonFromStream<Dictionary<string, Dictionary<string, string>>>(stream))
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

            foreach (ModTranslation mTrans in AutoRegisteredTranslations.Values)
            {
                Mod.AddTranslation(mTrans);

                if (mTrans.Key.Contains(".Splashes."))
                    SplashTexts.Add(mTrans);
            }

            ModMenuSplashTextSystem.CycleText();
        }

        private ModTranslation GetOrCreateTranslation(string key)
        {
            if (AutoRegisteredTranslations.ContainsKey(key))
                return AutoRegisteredTranslations[key];

            ModTranslation translation = Mod.CreateTranslation(key);
            AutoRegisteredTranslations.Add(key, translation);
            return translation;
        }

        public static T DeserializeJsonFromStream<T>(Stream stream)
        {
            using StreamReader reader = new(stream);
            using JsonTextReader textReader = new(reader);
            return new JsonSerializer().Deserialize<T>(textReader);
        }

        public static string[] GetCultures() => Enum.GetValues<GameCulture.CultureName>()
            .Select(name => GameCulture.FromCultureName(name).Name).ToArray();

        public static string GetFilePath(string culture, string fileName) =>
            Path.Combine("Localization", culture, fileName);
    }
}