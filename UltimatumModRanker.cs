using System.Collections.Generic;
using System.Linq;
using ExileCore;

namespace UltimatumCheck
{
    public class UltimatumModRanker
    {
        // Base priorities for mods (lower number = higher priority)
        private static readonly Dictionary<string, int> BasePriorities = new()
        {
            {"BossTrialMaster",10},
            {"Radius1",20},
            {"LightningRuneDaemon1",30},
            {"LightningRuneDaemon1Trial",40},
            {"MonsterBuffAcceleratingSpeed",50},
            {"FlamespitterDaemon1",60},
            {"FlamespitterDaemon1Trial",70},
            {"LightningRuneDaemon2",80},
            {"LightningRuneDaemon2Trial",90},
            {"FlamespitterDaemon2",100},
            {"FlamespitterDaemon2Trial",110},
            {"LightningRuneDaemon3",120},
            {"GraveyardDaemon1",130},
            {"GraveyardDaemon1Trial",140},
            {"LightningRuneDaemon4",150},
            {"PlayerDebuffBuffsExpireFaster",160},
            {"MonsterSuppressionAndEvasion",170},
            {"PlayerDebuffAreaAndProjectileSpeed",180},
            {"PlayerDebuffRandomProjectileDirection",190},
            {"PlayerDebuffSelfLightningDamageOnSkillUseManaSpentOnCostHigh",200},
            {"PlayerDebuffHinderedMsOnFlaskUse",210},
            {"MonsterHitsCantBeEvaded",220},
            {"MonsterBlock",230},
            {"MonsterSlowProtection",240},
            {"MonsterRemoveEnergyShieldAndManaOnHit",250},
            {"PlayerDebuffAurasAffectAllies",260},
            {"PlayerDebuffExtraCriticalRolls",270},
            {"MonsterExtraRareModifiers",280},
            {"MonsterResistances",290},
            {"FlamespitterDaemon3",300},
            {"FlamespitterDaemon3Trial",310},
            {"GraveyardDaemon2",320},
            {"GraveyardDaemon2Trial",330},
            {"SawbladeDaemon1",340},
            {"SawbladeDaemon2",350},
            {"PlayerDebuffCursesandNonDamagingAilmentsReflectedToSelf",360},
            {"MonsterBuffNonChaosDamageToAddAsChaosDamage",370},
            {"EleTotemDaemon",380},
            {"FlamespitterDaemon4",390},
            {"FlamespitterDaemon4Trial",400},
            {"FrostInfectionDaemon1",410},
            {"FrostInfectionDaemon2",420},
            {"FrostInfectionDaemon3",430},
            {"ChaosCloudDaemon1",440},
            {"SawbladeDaemon3",450},
            {"ChaosCloudDaemon2",460},
            {"ChaosCloudDaemon3",470},
            {"PlayerDebuffIncreasingVulnerability",480},
            {"PlayerDebuffCooldownSpeed",490},
            {"ChaosCloudDaemon4",500},
            {"PlayerDebuffUltimatumDealNoDamageFor2SecondEvery8Seconds",510},
            {"AltarDaemon1",520},
            {"AltarDaemon2",530},
            {"SawbladeDaemon4",540},
            {"PhysTotemDaemon",550},
            {"PlayerDebuffUltimatumLoseChargesEverySecond",560},
            {"FrostInfectionDaemon4",570},
            {"GolemCrawlerSpawner",580},
            {"GraveyardDaemon3",590},
            {"GraveyardDaemon3Trial",600},
            {"GraveyardDaemon4",610},
            {"GraveyardDaemon4Trial",620},
            {"MonsterHitsAreCriticalStrikes",630},
            {"MonsterOverwhelm",640},
            {"MonsterPhysAsExtraEachElement",650},
            {"RevenantDaemon1",660},
            {"RevenantDaemon2",670},
            {"RevenantDaemon3",680},
            {"RevenantDaemon4",690},
            {"MonstersApplyRuin1",700},
            {"MonstersApplyRuin2",710},
            {"MonstersApplyRuin3",720},
            {"MonstersApplyRuin4",730},
            {"PlayerDebuffCancelFlaskEffectOnFlaskUse",740},
            {"PlayerDebuffRecoveryReduction1",750},
            {"PlayerDebuffRecoveryReduction2",760},
            {"SpookySupplementSpawner",770},
            {"UltimatumWave10MonsterDamageLife",780},
            {"UltimatumWave11MonsterDamageLife",790},
            {"UltimatumWave12MonsterDamageLife",800},
            {"UltimatumWave13MonsterDamageLife",810},
            {"UltimatumWave2MonsterDamageLife",820},
            {"UltimatumWave3MonsterDamageLife",830},
            {"UltimatumWave4MonsterDamageLife",840},
            {"UltimatumWave5MonsterDamageLife",850},
            {"UltimatumWave6MonsterDamageLife",860},
            {"UltimatumWave7MonsterDamageLife",870},
            {"UltimatumWave8MonsterDamageLife",880},
            {"UltimatumWave9MonsterDamageLife",890},
            
            // Default priority for unknown mods
            {"Default", 10000}
        };

        public int GetModPriority(string modId)
        {
            // Start with base priority
            int priority = BasePriorities.TryGetValue(modId, out int basePriority) 
                ? basePriority 
                : BasePriorities["Default"];

            if (priority == 10000)
            {
                DebugWindow.LogError($"Unknown modId: {modId}");
            }
            return priority;
        }

        public string GetBestChoice(IEnumerable<string> availableModIds)
        {
            return availableModIds
                .OrderBy(GetModPriority)
                .First();
        }
    }
} 
