using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SteviesModRedux.Common.Sets;
using SteviesModRedux.Common.Utilities;
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
            public virtual bool ProcessedAfterNormalContentSamples { get; protected set; }

            public virtual bool AllowRepeatedRightClick { get; protected set; }

            public virtual bool CountsAsBombsForDemolitionistToSpawn { get; protected set; }

            public virtual int ItemSpawnPriority { get; protected set; }

            public virtual bool ForStuffCannon { get; protected set; }

            public virtual bool? CanBeQuickUsedOnGamePad { get; protected set; }

            public virtual bool? ForcesBreaksSleeping { get; protected set; }

            public virtual bool SkipsInitialUseSound { get; protected set; }

            public virtual bool UsesCursedByPlanteraTooltip { get; protected set; }

            public virtual bool IsAKite { get; protected set; }

            public virtual bool? ForceConsumption { get; protected set; }

            public virtual bool HasAProjectileThatHasAUsabilityCheck { get; protected set; }

            public virtual bool CanGetPrefixes { get; protected set; } = true;

            public virtual bool NonColorfulDyeItem { get; protected set; }

            public virtual FlowerPacketInfo FlowerPacketInfo { get; protected set; }

            public virtual bool IgnoresEncumberingStone { get; protected set; }

            public virtual float ToolTipDamageMultiplier { get; protected set; } = 1f;

            public virtual bool IsAPickup { get; protected set; }

            public virtual bool IsDrill { get; protected set; }

            public virtual bool IsChainsaw { get; protected set; }

            public virtual bool IsPaintScraper { get; protected set; }

            public virtual bool SummonerWeaponThatScalesWithAttackSpeed { get; protected set; }

            public virtual bool IsFood { get; protected set; }

            public virtual Color[] FoodParticleColors { get; protected set; } = Array.Empty<Color>();

            public virtual Color[] DrinkParticleColors { get; protected set; } = Array.Empty<Color>();

            public virtual ItemID.BannerEffect BannerStrength { get; protected set; }

            public virtual int KillsToBanner { get; protected set; } = 50;

            public virtual bool CanFishInLava { get; protected set; }

            public virtual bool IsLavaBait { get; protected set; }

            public virtual int ItemSpawnDecaySpeed { get; protected set; } = 1;

            public virtual bool IsFishingCrate { get; protected set; }

            public virtual bool IsFishingCrateHardMode { get; protected set; }

            public virtual bool CanBePlacedOnWeaponRacks { get; protected set; }

            public virtual int TextureCopyLoad { get; protected set; } = -1; // probably redundant

            public virtual bool TrapSigned { get; protected set; }

            public virtual bool Deprecated { get; protected set; }

            public virtual bool NeverAppearsAsNewInInventory { get; protected set; }

            public virtual bool CommonCoin { get; protected set; }

            public virtual bool ItemIconPulse { get; protected set; }

            public virtual bool ItemNoGravity { get; protected set; }

            public virtual int ExtractinatorMode { get; protected set; } = -1;

            public virtual bool ExoticPlantForDyeTrade { get; protected set; }

            public virtual bool NebulaPickup { get; protected set; }

            public virtual bool AnimatesAsSoul { get; protected set; }

            public virtual bool GunProjectile { get; protected set; }

            public virtual int SortingPriorityBossSpawns { get; protected set; } = -1;

            public virtual int SortingPriorityWiring { get; protected set; } = -1;

            public virtual int SortingPriorityMaterials { get; protected set; } = -1;

            public virtual int SortingPriorityExtractibles { get; protected set; } = -1;

            public virtual int SortingPriorityRopes { get; protected set; } = -1;

            public virtual int SortingPriorityPainting { get; protected set; } = -1;

            public virtual int SortingPriorityTerraforming { get; protected set; } = -1;

            public virtual int GamePadExtraRange { get; protected set; }

            public virtual bool GamePadWholeScreenUseRange { get; protected set; }

            public virtual float BonusMeleeSpeedMultiplier { get; protected set; } = 1f;

            public virtual bool GamePadSmartQuickReach { get; protected set; }

            public virtual bool YoYo { get; protected set; }

            public virtual bool AlsoABuildingItem { get; protected set; }

            public virtual bool LockOnIgnoresCollision { get; protected set; }

            public virtual int LockOnAimAbove { get; protected set; }

            public virtual float? LockOnAimCompensation { get; protected set; }

            public virtual bool SingleUseInGamePad { get; protected set; }

            public virtual bool Torch { get; protected set; }

            public virtual bool WaterTorch { get; protected set; }

            public virtual bool WorkBench { get; protected set; }

            public virtual bool GlowStick { get; protected set; }

            public virtual int SacrificeCount { get; protected set; }

            public bool ForceCoinsToDisplayStats { get; protected set; }

            public ItemSet SetProcessedAfterNormalContentSamples(bool value)
            {
                ProcessedAfterNormalContentSamples = value;
                return this;
            }

            public ItemSet SetAllowRepeatedRightClick(bool value)
            {
                AllowRepeatedRightClick = value;
                return this;
            }

            public ItemSet SetCountsAsBombsForDemolitionistToSpawn(bool value)
            {
                CountsAsBombsForDemolitionistToSpawn = value;
                return this;
            }

            public ItemSet SetItemSpawnPriority(int value)
            {
                ItemSpawnPriority = value;
                return this;
            }

            public ItemSet SetForStuffCannon(bool value)
            {
                ForStuffCannon = value;
                return this;
            }

            public ItemSet SetCanBeQuickUsedOnGamePad(bool? value)
            {
                CanBeQuickUsedOnGamePad = value;
                return this;
            }

            public ItemSet SetForcesBreaksSleeping(bool? value)
            {
                ForcesBreaksSleeping = value;
                return this;
            }

            public ItemSet SetSkipsInitialUseSound(bool value)
            {
                SkipsInitialUseSound = value;
                return this;
            }

            public ItemSet SetUsesCursedByPlanteraTooltip(bool value)
            {
                UsesCursedByPlanteraTooltip = value;
                return this;
            }

            public ItemSet SetIsAKite(bool value)
            {
                IsAKite = value;
                return this;
            }

            public ItemSet SetForceConsumption(bool? value)
            {
                ForceConsumption = value;
                return this;
            }

            public ItemSet SetHasAProjectileThatHasAUsabilityCheck(bool value)
            {
                HasAProjectileThatHasAUsabilityCheck = value;
                return this;
            }

            public ItemSet SetCanGetPrefixes(bool value)
            {
                CanGetPrefixes = value;
                return this;
            }

            public ItemSet SetNonColorfulDyeItem(bool value)
            {
                NonColorfulDyeItem = value;
                return this;
            }

            public ItemSet SetFlowerPacketInfo(FlowerPacketInfo value)
            {
                FlowerPacketInfo = value;
                return this;
            }

            public ItemSet SetIgnoresEncumberingStone(bool value)
            {
                IgnoresEncumberingStone = value;
                return this;
            }

            public ItemSet SetToolTiPDamageMultiplier(float value)
            {
                ToolTipDamageMultiplier = value;
                return this;
            }

            public ItemSet SetIsAPickup(bool value)
            {
                IsAPickup = value;
                return this;
            }

            public ItemSet SetIsDrill(bool value)
            {
                IsDrill = value;
                return this;
            }

            public ItemSet SetIsChainsaw(bool value)
            {
                IsChainsaw = value;
                return this;
            }

            public ItemSet SetIsPainScraper(bool value)
            {
                IsPaintScraper = value;
                return this;
            }

            public ItemSet SetSummonerWeaponThatScalesWithAttackSpeed(bool value)
            {
                SummonerWeaponThatScalesWithAttackSpeed = value;
                return this;
            }

            public ItemSet SetIsFood(bool value)
            {
                IsFood = value;
                return this;
            }

            public ItemSet SetFoodParticleColors(Color[] value)
            {
                FoodParticleColors = value;
                return this;
            }

            public ItemSet SetDrinkParticleColors(Color[] value)
            {
                DrinkParticleColors = value;
                return this;
            }

            public ItemSet SetBannerStrength(ItemID.BannerEffect value)
            {
                BannerStrength = value;
                return this;
            }

            public ItemSet SetKillsToBanner(int value)
            {
                KillsToBanner = value;
                return this;
            }

            public ItemSet SetCanFishInLava(bool value)
            {
                CanFishInLava = value;
                return this;
            }

            public ItemSet SetIsLavaBait(bool value)
            {
                IsLavaBait = value;
                return this;
            }

            public ItemSet SetItemSpawnDecaySpeed(int value)
            {
                ItemSpawnDecaySpeed = value;
                return this;
            }

            public ItemSet SetIsFishingCrate(bool value)
            {
                IsFishingCrate = value;
                return this;
            }

            public ItemSet SetIsFishingCreateHardMode(bool value)
            {
                IsFishingCrateHardMode = value;
                return this;
            }

            public ItemSet SetCanBePlacedOnWeaponRacks(bool value)
            {
                CanBePlacedOnWeaponRacks = value;
                return this;
            }

            public ItemSet SetTextureCopyLoad(int value)
            {
                TextureCopyLoad = value;
                return this;
            }

            public ItemSet SetTrapSigned(bool value)
            {
                TrapSigned = value;
                return this;
            }

            public ItemSet SetDeprecated(bool value)
            {
                Deprecated = value;
                return this;
            }

            public ItemSet SetNeverAppearsAsNewInInventory(bool value)
            {
                NeverAppearsAsNewInInventory = value;
                return this;
            }

            public ItemSet SetCommonCoin(bool value)
            {
                CommonCoin = value;
                return this;
            }

            public ItemSet SetItemIconPulse(bool value)
            {
                ItemIconPulse = value;
                return this;
            }

            public ItemSet SetItemNoGravity(bool value)
            {
                ItemNoGravity = value;
                return this;
            }

            public ItemSet SetExtractinatorMode(int value)
            {
                ExtractinatorMode = value;
                return this;
            }

            public ItemSet SetExoticPlantForDyTrade(bool value)
            {
                ExoticPlantForDyeTrade = value;
                return this;
            }

            public ItemSet SetNebulaPickup(bool value)
            {
                NebulaPickup = value;
                return this;
            }

            public ItemSet SetAnimatesAsSoul(bool value)
            {
                AnimatesAsSoul = value;
                return this;
            }

            public ItemSet SetGunProjectile(bool value)
            {
                GunProjectile = value;
                return this;
            }

            public ItemSet SetSortingPriorityBossSpawns(int value)
            {
                SortingPriorityBossSpawns = value;
                return this;
            }

            public ItemSet SetSortingPriorityWiring(int value)
            {
                SortingPriorityWiring = value;
                return this;
            }

            public ItemSet SetSortingPriorityMaterials(int value)
            {
                SortingPriorityMaterials = value;
                return this;
            }

            public ItemSet SetSortingPriorityExtractibles(int value)
            {
                SortingPriorityExtractibles = value;
                return this;
            }

            public ItemSet SetSortingPriorityRopes(int value)
            {
                SortingPriorityRopes = value;
                return this;
            }

            public ItemSet SetSortingPriorityPainting(int value)
            {
                SortingPriorityPainting = value;
                return this;
            }

            public ItemSet SetSortingPriorityTerraforming(int value)
            {
                SortingPriorityTerraforming = value;
                return this;
            }

            public ItemSet SetGamePadExtraRange(int value)
            {
                GamePadExtraRange = value;
                return this;
            }

            public ItemSet SetGamePadWholeScreenUseRange(bool value)
            {
                GamePadWholeScreenUseRange = value;
                return this;
            }

            public ItemSet SetBonusMeleeSpeedMultiplier(float value)
            {
                BonusMeleeSpeedMultiplier = value;
                return this;
            }

            public ItemSet SetGamePadSmartQuickReach(bool value)
            {
                GamePadSmartQuickReach = value;
                return this;
            }

            public ItemSet SetYoYo(bool value)
            {
                YoYo = value;
                return this;
            }

            public ItemSet SetAlsoABuildingItem(bool value)
            {
                AlsoABuildingItem = value;
                return this;
            }

            public ItemSet SetLockOnIgnoresCollision(bool value)
            {
                LockOnIgnoresCollision = value;
                return this;
            }

            public ItemSet SetLockOnAimAbove(int value)
            {
                LockOnAimAbove = value;
                return this;
            }

            public ItemSet SetLockOnAimCompensation(float? value)
            {
                LockOnAimCompensation = value;
                return this;
            }

            public ItemSet SetSingleUseGamePad(bool value)
            {
                SingleUseInGamePad = value;
                return this;
            }

            public ItemSet SetTorch(bool value)
            {
                Torch = value;
                return this;
            }

            public ItemSet SetWaterTorch(bool value)
            {
                WaterTorch = value;
                return this;
            }

            public ItemSet SetWorkBench(bool value)
            {
                WorkBench = value;
                return this;
            }

            public ItemSet SetGlowStick(bool value)
            {
                GlowStick = value;
                return this;
            }

            public ItemSet SetSacrificeCount(int value)
            {
                SacrificeCount = value;
                return this;
            }

            public ItemSet SetForceCoinsToDisplayStats(bool value)
            {
                ForceCoinsToDisplayStats = value;
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
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = ValueSet.AllowRepeatedRightClick;
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] =
                ValueSet.CountsAsBombsForDemolitionistToSpawn;
            ItemID.Sets.NewItemSpawnPriority[Type] = ValueSet.ItemSpawnPriority;
            if (ValueSet.ForStuffCannon)
                ItemID.Sets.ItemsForStuffCannon = ItemID.Sets.ItemsForStuffCannon.ArrayAdd(Type);
            ItemID.Sets.CanBeQuickusedOnGamepad[Type] = ValueSet.CanBeQuickUsedOnGamePad;
            ItemID.Sets.ForcesBreaksSleeping[Type] = ValueSet.ForcesBreaksSleeping;
            ItemID.Sets.SkipsInitialUseSound[Type] = ValueSet.SkipsInitialUseSound;
            ItemID.Sets.UsesCursedByPlanteraTooltip[Type] = ValueSet.UsesCursedByPlanteraTooltip;
            ItemID.Sets.IsAKite[Type] = ValueSet.IsAKite;
            ItemID.Sets.ForceConsumption[Type] = ValueSet.ForceConsumption;
            ItemID.Sets.HasAProjectileThatHasAUsabilityCheck[Type] = ValueSet.HasAProjectileThatHasAUsabilityCheck;
            ItemID.Sets.CanGetPrefixes[Type] = ValueSet.CanGetPrefixes;
            if (ValueSet.NonColorfulDyeItem)
                ItemID.Sets.NonColorfulDyeItems.Add(Type);
            ItemID.Sets.flowerPacketInfo[Type] = ValueSet.FlowerPacketInfo;
            ItemID.Sets.IgnoresEncumberingStone[Type] = ValueSet.IgnoresEncumberingStone;
            ItemID.Sets.ToolTipDamageMultiplier[Type] = ValueSet.ToolTipDamageMultiplier;
            ItemID.Sets.IsAPickup[Type] = ValueSet.IsAPickup;
            ItemID.Sets.IsDrill[Type] = ValueSet.IsDrill;
            ItemID.Sets.IsChainsaw[Type] = ValueSet.IsChainsaw;
            ItemID.Sets.IsPaintScraper[Type] = ValueSet.IsPaintScraper;
            ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Type] =
                ValueSet.SummonerWeaponThatScalesWithAttackSpeed;
            ItemID.Sets.IsFood[Type] = ValueSet.IsFood;
            ItemID.Sets.FoodParticleColors[Type] = ValueSet.FoodParticleColors;
            ItemID.Sets.DrinkParticleColors[Type] = ValueSet.DrinkParticleColors;
            ItemID.Sets.BannerStrength[Type] = ValueSet.BannerStrength;
            ItemID.Sets.KillsToBanner[Type] = ValueSet.KillsToBanner;
            ItemID.Sets.CanFishInLava[Type] = ValueSet.CanFishInLava;
            ItemID.Sets.IsLavaBait[Type] = ValueSet.IsLavaBait;
            ItemID.Sets.ItemSpawnDecaySpeed[Type] = ValueSet.ItemSpawnDecaySpeed;
            ItemID.Sets.IsFishingCrate[Type] = ValueSet.IsFishingCrate;
            ItemID.Sets.IsFishingCrateHardmode[Type] = ValueSet.IsFishingCrateHardMode;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = ValueSet.CanBePlacedOnWeaponRacks;
            ItemID.Sets.TextureCopyLoad[Type] = ValueSet.TextureCopyLoad;
            ItemID.Sets.TrapSigned[Type] = ValueSet.TrapSigned;
            ItemID.Sets.Deprecated[Type] = ValueSet.Deprecated;
            ItemID.Sets.NeverAppearsAsNewInInventory[Type] = ValueSet.NeverAppearsAsNewInInventory;
            ItemID.Sets.CommonCoin[Type] = ValueSet.CommonCoin;
            ItemID.Sets.ItemIconPulse[Type] = ValueSet.ItemIconPulse;
            ItemID.Sets.ItemNoGravity[Type] = ValueSet.ItemNoGravity;
            ItemID.Sets.ExtractinatorMode[Type] = ValueSet.ExtractinatorMode;
            ItemID.Sets.ExoticPlantsForDyeTrade[Type] = ValueSet.ExoticPlantForDyeTrade;
            ItemID.Sets.NebulaPickup[Type] = ValueSet.NebulaPickup;
            ItemID.Sets.AnimatesAsSoul[Type] = ValueSet.AnimatesAsSoul;
            ItemID.Sets.gunProj[Type] = ValueSet.GunProjectile;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = ValueSet.SortingPriorityBossSpawns;
            ItemID.Sets.SortingPriorityWiring[Type] = ValueSet.SortingPriorityWiring;
            ItemID.Sets.SortingPriorityMaterials[Type] = ValueSet.SortingPriorityMaterials;
            ItemID.Sets.SortingPriorityExtractibles[Type] = ValueSet.SortingPriorityExtractibles;
            ItemID.Sets.SortingPriorityRopes[Type] = ValueSet.SortingPriorityRopes;
            ItemID.Sets.SortingPriorityPainting[Type] = ValueSet.SortingPriorityPainting;
            ItemID.Sets.SortingPriorityTerraforming[Type] = ValueSet.SortingPriorityTerraforming;
            ItemID.Sets.GamepadExtraRange[Type] = ValueSet.GamePadExtraRange;
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = ValueSet.GamePadWholeScreenUseRange;
            ItemID.Sets.BonusMeleeSpeedMultiplier[Type] = ValueSet.BonusMeleeSpeedMultiplier;
            ItemID.Sets.GamepadSmartQuickReach[Type] = ValueSet.GamePadSmartQuickReach;
            ItemID.Sets.Yoyo[Type] = ValueSet.YoYo;
            ItemID.Sets.AlsoABuildingItem[Type] = ValueSet.AlsoABuildingItem;
            ItemID.Sets.LockOnIgnoresCollision[Type] = ValueSet.LockOnIgnoresCollision;
            ItemID.Sets.LockOnAimAbove[Type] = ValueSet.LockOnAimAbove;
            ItemID.Sets.LockOnAimCompensation[Type] = ValueSet.LockOnAimCompensation;
            ItemID.Sets.SingleUseInGamepad[Type] = ValueSet.SingleUseInGamePad;
            ItemID.Sets.Torches[Type] = ValueSet.Torch;
            ItemID.Sets.WaterTorches[Type] = ValueSet.WaterTorch;
            if (ValueSet.WorkBench)
                ItemID.Sets.Workbenches = ItemID.Sets.Workbenches.ArrayAdd((short) Type);
            ItemID.Sets.Glowsticks[Type] = ValueSet.GlowStick;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = ValueSet.SacrificeCount;
            if (ValueSet.ForceCoinsToDisplayStats)
                ExtraItemTags.CoinStatDisplay.Add(true, Type);
        }
    }
}