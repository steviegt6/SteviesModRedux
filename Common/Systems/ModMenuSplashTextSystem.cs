using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour;
using ReLogic.Content;
using ReLogic.Graphics;
using SteviesModRedux.Common.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace SteviesModRedux.Common.Systems
{
    public sealed class ModMenuSplashTextSystem : ModSystem
    {
        // TODO: JSON config
        public static bool ShouldDrawSplashText { get; set; } = true;

        public static string DrawnSplashText { get; set; } = "nil";

        public static float TextScale { get; set; } = 1f;

        public static bool TextDirection { get; set; }

        public override void OnModLoad()
        {
            MonoModHooks.RequestNativeAccess();

            new Hook(
                typeof(ModLoader).Assembly.GetType("Terraria.ModLoader.MenuLoader")!.GetMethodForced(
                    "UpdateAndDrawModMenu"),
                typeof(ModMenuSplashTextSystem).GetMethodForced(nameof(OverlaySplashText))).Apply();
        }

        private static void OverlaySplashText(Action<SpriteBatch, GameTime, Color, float, float> orig,
            SpriteBatch spriteBatch, GameTime gameTime, Color color, float logoRotation, float logoScale)
        {
            if (ShouldDrawSplashText)
            {
                logoRotation = 0f;
                logoScale = 1f;
            }

            orig(spriteBatch, gameTime, color, logoRotation, logoScale);

            DynamicSpriteFont font = FontAssets.MouseText.Value;
            string text = ShouldDrawSplashText
                ? Language.GetTextValue("Mods.SteviesModRedux.UI.EnabledSplashText")
                : Language.GetTextValue("Mods.SteviesModRedux.UI.DisabledSplashText");

            Vector2 textSize = font.MeasureString(text);
            Rectangle clickArea = Main.menuMode == MenuID.Title
                ? new Rectangle((int) (Main.screenWidth / 2f - textSize.X / 2),
                    (int) (Main.screenHeight - 2 - textSize.Y * 2), (int) textSize.X, (int) textSize.Y)
                : Rectangle.Empty;

            if (Main.menuMode == MenuID.Title)
            {
                Color drawColor = new(120, 120, 120, 76);

                if (clickArea.Contains(Main.mouseX, Main.mouseY) && !Main.alreadyGrabbingSunOrMoon)
                {
                    drawColor = Main.OurFavoriteColor;

                    if (Main.mouseLeftRelease && Main.mouseLeft)
                    {
                        CycleText();
                        SoundEngine.PlaySound(SoundID.MenuTick);
                        ShouldDrawSplashText = !ShouldDrawSplashText;
                    }
                }

                ChatManager.DrawColorCodedStringWithShadow(spriteBatch, font, text,
                    new Vector2(clickArea.X, clickArea.Y), drawColor, 0f, Vector2.Zero, Vector2.One);
            }

            if (ShouldDrawSplashText)
                DrawSplashText(MenuLoader.CurrentMenu.Logo, spriteBatch);
        }

        private static void DrawSplashText(Asset<Texture2D> logo, SpriteBatch spriteBatch)
        {
            TextDirection = TextScale switch
            {
                >= 1.1f => true,
                <= 0.9f => false,
                _ => TextDirection
            };

            TextScale -= TextDirection ? 0.0075f : -0.0075f;

            Vector2 center = logo.Size() / 2f;

            for (int i = 0; i < 4; i++)
                DrawText(logo, spriteBatch, center, new Color(0, 0, 0, 200), i);

            DrawText(logo, spriteBatch, center, Main.OurFavoriteColor);
        }

        private static void DrawText(Asset<Texture2D> logo, SpriteBatch spriteBatch, Vector2 center, Color color,
            int shadow = -1)
        {
            Vector2 accountForShadow = new(Main.screenWidth / 2 + logo.Width() / 4, center.Y * 1.5f);

            if (shadow != -1)
                accountForShadow += new Vector2(shadow switch
                {
                    0 => 2f,
                    1 => -2f,
                    _ => 0f
                }, shadow switch
                {
                    2 => 2f,
                    3 => -2f,
                    _ => 0f
                });

            spriteBatch.DrawString(FontAssets.DeathText.Value,
                DrawnSplashText,
                accountForShadow,
                color,
                MathHelper.ToRadians(-20f),
                FontAssets.DeathText.Value.MeasureString(DrawnSplashText) / 2,
                0.5f * TextScale,
                SpriteEffects.None,
                0f);
        }

        public static void CycleText()
        {
            DrawnSplashText = string.Format(LocalizationSystem
                    .SplashTexts[Main.rand.Next(LocalizationSystem.SplashTexts.Count)]
                    .Value,
                Environment.MachineName.ToUpper(),
                LocalizationSystem.SplashTexts.Count + 1,
                Environment.MachineName,
                ChildSafety.Disabled ? "LETSFUCKINGGOOOOOOOOOOOOOO" : "LETSFREAKINGGOOOOOOOOOOOOOO",
                DateTime.Now.Year);
        }
    }
}