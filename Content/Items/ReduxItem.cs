using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesModRedux.Content.Items
{
    public abstract class ReduxItem : ModItem
    {
        public class ItemSet
        {
            public bool ProcessedAfterNormalContentSamples { get; protected set; }

            public bool AllowRepeatedRightClick { get; protected set; }

            public bool CountsAsBombsForDemolitionistToSpawn { get; protected set; }

            public int ItemSpawnPriority { get; protected set; }

            public bool ForStuffCannon { get; protected set; }

            public bool? CanBeQuickUsedOnGamePad { get; protected set; } = null;

            public bool? ForcesBreaksSleeping { get; protected set; } = null;

            public bool SkipsInitialUseSound { get; protected set; }

            public bool UsesCursedByPlanteraTooltip { get; protected set; }

            public bool IsAKite { get; protected set; }

            public bool? ForceConsumption { get; protected set; } = null;

            public bool HasAProjectileThatHasAUsabilityCheck { get; protected set; }

            public bool CanGetPrefixes { get; protected set; } = true;

            public bool NonColorfulDyeItem { get; protected set; }

            public FlowerPacketInfo FlowerPacketInfo { get; protected set; } = null;

            public bool IgnoresEncumberingStone { get; protected set; }

            public float ToolTiPDamageMultiplier { get; protected set; } = 1f;

            public bool IsAPickup { get; protected set; }

            public bool IsDrill { get; protected set; }

            public bool IsChainsaw { get; protected set; }

            public bool IsPainScraper { get; protected set; }

            public bool SummonerWeaponThatScalesWithAttackSpeed { get; protected set; }

            public bool IsFood { get; protected set; }

            public Color[] FoodParticleColors { get; protected set; } = Array.Empty<Color>();

            public Color[] DrinkParticleColors { get; protected set; } = Array.Empty<Color>();

            public ItemID.BannerEffect BannerStrength { get; protected set; } = new();

            public int KillsToBanner { get; protected set; } = 50;

            public bool CanFishInLava { get; protected set; }

            public bool IsLavaBait { get; protected set; }

            public int ItemSpawnDecaySpeed { get; protected set; } = 1;

            public bool IsFishingCrate { get; protected set; }

            public bool IsFishingCreateHardMode { get; protected set; }

            public bool CanBePlacedOnWeaponRacks { get; protected set; }

            public int TextureCopyLoad { get; protected set; } = -1; // probably redundant

            public bool TrapSigned { get; protected set; }

            public bool Deprecated { get; protected set; }

            public bool NeverAppearsAsNewInInventory { get; protected set; }

            public bool CommonCoin { get; protected set; }

            public bool ItemIconPulse { get; protected set; }

            public bool ItemNoGravity { get; protected set; }

            public int ExtractinatorMode { get; protected set; } = -1;

            public bool ExoticPlantForDyTrade { get; protected set; }

            public bool NebulaPickup { get; protected set; }

            public bool AnimatesAsSoul { get; protected set; }

            public bool GunProjectile { get; protected set; }

            public int SortingPriorityBossSpawns { get; protected set; } = -1;

            public int SortingPriorityWiring { get; protected set; } = -1;

            public int SortingPriorityMaterials { get; protected set; } = -1;

            public int SortingPriorityExtractibles { get; protected set; } = -1;

            public int SortingPriorityRopes { get; protected set; } = -1;

            public int SortingPriorityPainting { get; protected set; } = -1;

            public int SortingPriorityTerraforming { get; protected set; } = -1;

            public int GamePadExtraRange { get; protected set; }

            public bool GamePadWholeScreenUseRange { get; protected set; }

            public float BonusMeleeSpeedMultiplier { get; protected set; } = 1f;

            public bool GamePadSmartQuickReach { get; protected set; }

            public bool YoYo { get; protected set; }

            public bool AlsoABuildingItem { get; protected set; }

            public bool LockOnIgnoresCollision { get; protected set; }

            public int LockOnAimAbove { get; protected set; }

            public float? LockOnAimCompensation { get; protected set; } = null;

            public bool SingleUseGamePad { get; protected set; }

            public bool Torch { get; protected set; }

            public bool WaterTorch { get; protected set; }

            public bool WorkBench { get; protected set; }

            public bool GlowStick { get; protected set; }

            public int SacrificeCount { get; protected set; }

            public ItemSet SetProcessedAfterNormalContentSamples(bool processedAfterNormalContentSamples)
            {
                ProcessedAfterNormalContentSamples = processedAfterNormalContentSamples;
                return this;
            }

            public ItemSet SetSacrificeCount(int sacrificeCount)
            {
                SacrificeCount = sacrificeCount;
                return this;
            }
        }

        public override string Texture =>
            ModContent.RequestIfExists<Texture2D>(base.Texture, out _) ? base.Texture : "ModLoader/UnloadedItem";

        protected ItemSet ItemValues;

        public virtual ItemSet ValueSet
        {
            get => ItemValues ??= new ItemSet();

            set => ItemValues = value;
        }

        public override void SetStaticDefaults()
        {
            SetItemSetValues();
        }

        public virtual int GetValueFromItems(params int[] items)
        {
            int total = 0;

            foreach (int item in items)
            {
                Item instance = new();
                instance.SetDefaults(item, true);
                total += instance.value;
            }

            return total;
        }

        public virtual void SetItemSetValues()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = ValueSet.SacrificeCount;
        }
    }
}