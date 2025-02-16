using System;
using System.Security;
using System.Security.Permissions;
using BepInEx;
using MoreSlugcats;
using System.Collections.Generic;
using RWCustom;
using PupKarma;
using System.Reflection;

#pragma warning disable CS0618

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace SlugpupsEverywhere;

[BepInPlugin(GUID, Name, Version)]
public partial class SlugpupsEverywhere : BaseUnityPlugin
{
    public const string GUID = "Peroconino.SlugpupsEverywhere";
    public const string Version = "1.1.2";
    public const string Name = "Pups Everywhere";
    private readonly SlugpupsEverywhereOptions? Options;
    private bool IsInit, hasPupKarmaMod;
    public SlugpupsEverywhere()
    {
        try
        {
            Options = new SlugpupsEverywhereOptions(this, Logger);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
        }
    }
    public void OnEnable()
    {
        On.RainWorld.OnModsInit += RainWorldOnOnModsInit;
    }
    private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);
        if (IsInit) return;

        try
        {
            IsInit = true;
            hasPupKarmaMod = false;
            foreach (ModManager.Mod mod in ModManager.ActiveMods)
            {
                if (mod.name == "PupKarma")
                {
                    hasPupKarmaMod = true;
                    break;
                }
            }

            if (hasPupKarmaMod)
                On.World.SpawnPupNPCs += hook_SpawnPupNPCsPupKarma;
            else
                On.World.SpawnPupNPCs += hook_SpawnPupNPCs;

            MachineConnector.SetRegisteredOI(GUID, Options);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
        }
    }
    public int hook_SpawnPupNPCsPupKarma(On.World.orig_SpawnPupNPCs _orig, World self)
    {
        if (self.game.world.singleRoomWorld || self.game.rainWorld.safariMode || self.game.wasAnArtificerDream || self.game.GetStorySession.Players.Count == 0)
        {
            return 0;
        }

        int numOfAlivePups = 0;
        int origNumOfAlivePups = 0;
        AbstractRoom currentPlayerRoom = self.game.GetStorySession.Players[0].Room;
        foreach (AbstractCreature abstractCreature in currentPlayerRoom.creatures)
        {
            if (abstractCreature.state.alive && abstractCreature.creatureTemplate.type == MoreSlugcatsEnums.CreatureTemplateType.SlugNPC)
            {
                numOfAlivePups++;
                origNumOfAlivePups++;
            }
        }

        UnityEngine.Random.State state = UnityEngine.Random.state;
        self.game.GetStorySession.SetRandomSeedToCycleSeed(self.region.regionNumber);
        if (UnityEngine.Random.value >= CalculatePupSpawnChance(self.region.regionParams.slugPupSpawnChance))
        {
            if (ModManager.DevTools)
                Logger.LogInfo(
                "No slugpups this cycle"
            );
            UnityEngine.Random.state = state;
            return numOfAlivePups;
        }

        int slugPupMaxCount = CalculatePupNumber(self.game.GetStorySession.saveState);
        if (numOfAlivePups < slugPupMaxCount)
        {
            List<AbstractRoom> listOfShelters = [];
            foreach (AbstractRoom abstractRoom in self.abstractRooms)
            {
                if (abstractRoom != currentPlayerRoom && abstractRoom.shelter && abstractRoom.name != "SU_S05")
                {
                    listOfShelters.Add(abstractRoom);
                }
            }

            int allowedNumOfPups = Options!.IsByPassAllowedNumOfPups.Value ? Options.AmountOfPups.Value : 1;
            AbstractRoom shelterOrCurrentRoom;
            if (self.game.GetStorySession.saveState.forcePupsNextCycle >= 1)
            {//REVIEW - Deixando em >= 1 faz com que continue nascendo filhotes mesmo sendo que eles tenham sobrevivido a mais de 1 ciclo
                shelterOrCurrentRoom = currentPlayerRoom;
                allowedNumOfPups = slugPupMaxCount - numOfAlivePups;
                self.game.GetStorySession.saveState.forcePupsNextCycle = 2;
            }
            else
            {
                if (listOfShelters.Count == 0)
                {
                    if (ModManager.DevTools)
                        Logger.LogWarning(
                        "No shelters for pup spawns"
                    );
                    return numOfAlivePups;
                }

                if (listOfShelters.Count == 1)
                {
                    if (ModManager.DevTools)
                        Logger.LogWarning(
                        "only a SINGLE shelter for pup spawns"
                    );
                    shelterOrCurrentRoom = listOfShelters[0];
                }
                else
                {
                    shelterOrCurrentRoom = listOfShelters[UnityEngine.Random.Range(0, listOfShelters.Count)];
                }

            }

            for (int j = 0; j < allowedNumOfPups; j++)
            {
                AbstractCreature slugPup = new(self, StaticWorld.GetCreatureTemplate(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC), null, new WorldCoordinate(shelterOrCurrentRoom.index, -1, -1, 0), self.game.GetNewID());
                if (slugPup.TryGetPupData(out PupData pupData))
                {
                    pupData.AssignKarmaToPup();
                }

                shelterOrCurrentRoom.AddEntity(slugPup);
                if (shelterOrCurrentRoom.realizedRoom != null)
                {
                    slugPup.RealizeInRoom();
                }

                (slugPup.state as PlayerNPCState)!.foodInStomach = 1;
                numOfAlivePups++;
                if (listOfShelters.Count > 1)
                    shelterOrCurrentRoom = listOfShelters[UnityEngine.Random.Range(0, listOfShelters.Count)];

                if (ModManager.DevTools)
                    Logger.LogInfo(
                         "Created slugpup! " + slugPup + " at " + shelterOrCurrentRoom.name + " " + shelterOrCurrentRoom.index
                     );

            }
        }

        UnityEngine.Random.state = state;
        return origNumOfAlivePups;
    }
    public int hook_SpawnPupNPCs(On.World.orig_SpawnPupNPCs _orig, World self)
    {
        if (self.game.world.singleRoomWorld || self.game.rainWorld.safariMode || self.game.wasAnArtificerDream || self.game.GetStorySession.Players.Count == 0)
        {
            return 0;
        }

        int numOfAlivePups = 0;
        int origNumOfAlivePups = 0;
        AbstractRoom currentPlayerRoom = self.game.GetStorySession.Players[0].Room;
        foreach (AbstractCreature abstractCreature in currentPlayerRoom.creatures)
        {
            if (abstractCreature.state.alive && abstractCreature.creatureTemplate.type == MoreSlugcatsEnums.CreatureTemplateType.SlugNPC)
            {
                numOfAlivePups++;
                origNumOfAlivePups++;
            }
        }

        UnityEngine.Random.State state = UnityEngine.Random.state;
        self.game.GetStorySession.SetRandomSeedToCycleSeed(self.region.regionNumber);
        if (UnityEngine.Random.value >= CalculatePupSpawnChance(self.region.regionParams.slugPupSpawnChance))
        {
            if (ModManager.DevTools)
                Logger.LogInfo(
                "No slugpups this cycle"
            );
            UnityEngine.Random.state = state;
            return numOfAlivePups;
        }

        int slugPupMaxCount = CalculatePupNumber(self.game.GetStorySession.saveState);
        if (numOfAlivePups < slugPupMaxCount)
        {
            List<AbstractRoom> listOfShelters = [];
            foreach (AbstractRoom abstractRoom in self.abstractRooms)
            {
                if (abstractRoom != currentPlayerRoom && abstractRoom.shelter && abstractRoom.name != "SU_S05")
                {
                    listOfShelters.Add(abstractRoom);
                }
            }

            int allowedNumOfPups = Options!.IsByPassAllowedNumOfPups.Value ? Options.AmountOfPups.Value : 1;
            AbstractRoom shelterOrCurrentRoom;
            if (self.game.GetStorySession.saveState.forcePupsNextCycle >= 1)
            {//REVIEW - Deixando em >= 1 faz com que continue nascendo filhotes mesmo sendo que eles tenham sobrevivido a mais de 1 ciclo
                shelterOrCurrentRoom = currentPlayerRoom;
                allowedNumOfPups = slugPupMaxCount - numOfAlivePups;
                self.game.GetStorySession.saveState.forcePupsNextCycle = 2;
            }
            else
            {
                if (listOfShelters.Count == 0)
                {
                    if (ModManager.DevTools)
                        Logger.LogWarning(
                        "No shelters for pup spawns"
                    );
                    return numOfAlivePups;
                }

                if (listOfShelters.Count == 1)
                {
                    if (ModManager.DevTools)
                        Logger.LogWarning(
                        "only a SINGLE shelter for pup spawns"
                    );
                    shelterOrCurrentRoom = listOfShelters[0];
                }
                else
                {
                    shelterOrCurrentRoom = listOfShelters[UnityEngine.Random.Range(0, listOfShelters.Count)];
                }

            }

            for (int j = 0; j < allowedNumOfPups; j++)
            {
                AbstractCreature slugPup = new(self, StaticWorld.GetCreatureTemplate(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC), null, new WorldCoordinate(shelterOrCurrentRoom.index, -1, -1, 0), self.game.GetNewID());
                shelterOrCurrentRoom.AddEntity(slugPup);
                if (shelterOrCurrentRoom.realizedRoom != null)
                {
                    slugPup.RealizeInRoom();
                }

                (slugPup.state as PlayerNPCState)!.foodInStomach = 1;
                numOfAlivePups++;
                if (listOfShelters.Count > 1)
                    shelterOrCurrentRoom = listOfShelters[UnityEngine.Random.Range(0, listOfShelters.Count)];

                if (ModManager.DevTools)
                    Logger.LogInfo(
                         "Created slugpup! " + slugPup + " at " + shelterOrCurrentRoom.name + " " + shelterOrCurrentRoom.index
                     );

            }
        }

        UnityEngine.Random.state = state;
        return origNumOfAlivePups;
    }
    private int CalculatePupNumber(SaveState saveState)
    {
        if (Options is null || !ModManager.MSC || !(saveState.progression.miscProgressionData.beaten_Gourmand_Full || MoreSlugcats.MoreSlugcats.chtUnlockSlugpups.Value || (ModManager.Expedition && Custom.rainWorld.ExpeditionMode && Options.AllowPupsInExpedition.Value)))
        {
            return 0;
        }

        if (((saveState.saveStateNumber == SlugcatStats.Name.White) && !Options.AllowWhiteCampaignSlugpups.Value) || ((saveState.saveStateNumber == SlugcatStats.Name.Yellow) && !Options.AllowYellowCampaignSlugpups.Value) || ((saveState.saveStateNumber == SlugcatStats.Name.Red) && !Options.AllowRedCampaignSlugpups.Value) ||
        ((saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Gourmand) && !Options.AllowGourmandCampaignSlugpups.Value) || ((saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Artificer) && !Options.AllowArtificerCampaignSlugpups.Value) || ((saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Rivulet) && !Options.AllowRivuletCampaignSlugpups.Value) ||
        ((saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Spear) && !Options.AllowSpearmasterCampaignSlugpups.Value) || ((saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Saint) && !Options.AllowSaintCampaignSlugpups.Value))
        {
            return 0;
        }

        if (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel)
        {
            return 1000;
        }

        return Options.AmountOfPups.Value;
    }
    private float CalculatePupSpawnChance(float origPupSpawnChance)
    {
        if (Options is null || !Options.IsCustomSlugpupSpawnChance.Value)
        {
            return origPupSpawnChance;
        }

        return Options.SlugpupSpawnChance.Value;
    }
}