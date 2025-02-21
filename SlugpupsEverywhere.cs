﻿using System;
using System.Security;
using System.Security.Permissions;
using BepInEx;
using MoreSlugcats;
using System.Collections.Generic;
using RWCustom;
using System.Linq;

#pragma warning disable CS0618

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace SlugpupsEverywhere;

[BepInPlugin(GUID, Name, Version)]
public partial class SlugpupsEverywhere : BaseUnityPlugin
{
    public const string GUID = "Peroconino.SlugpupsEverywhere";
    public const string Version = "1.0.3";
    public const string Name = "Pups Everywhere";
    private readonly SlugpupsEverywhereOptions? Options;
    private readonly CustomLogger CustomLogger;
    private bool IsInit;
    public SlugpupsEverywhere()
    {
        try
        {
            Options = new SlugpupsEverywhereOptions(CustomLogger!);
            CustomLogger = new CustomLogger();
        }
        catch (Exception ex)
        {
            CustomLogger!.LogError(ex);
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
            On.World.SpawnPupNPCs += hook_SpawnPupNPCs;

            MachineConnector.SetRegisteredOI(GUID, Options);

            IsInit = true;
        }
        catch (Exception ex)
        {
            CustomLogger!.LogError(ex);
        }
    }
    public int hook_SpawnPupNPCs(On.World.orig_SpawnPupNPCs orig, World self)
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
        if (UnityEngine.Random.value >= CalculatePupSpawnChance(self.region.regionParams.slugPupSpawnChance) && self.game.GetStorySession.saveStateNumber != MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel && self.game.GetStorySession.saveState.forcePupsNextCycle != 1)
        {
            CustomLogger!.LogInfo($"No slugpups this cycle, region spawn chance: {self.region.regionParams.slugPupSpawnChance}");
            UnityEngine.Random.state = state;
            return numOfAlivePups;
        }

        int slugPupMaxCount = CalculatePupNumber(self.game.GetStorySession.saveState);

        CustomLogger!.LogInfo($"Allowed number of pups to spawn this cycle: {slugPupMaxCount - numOfAlivePups}");
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

            int allowedNumOfPups = Options!.IsByPassAllowedNumOfPups.Value ? slugPupMaxCount - numOfAlivePups : 1;
            AbstractRoom shelterOrCurrentRoom;
            if (self.game.GetStorySession.saveState.forcePupsNextCycle == 1)
            {
                CustomLogger.LogInfo("Pups forced into this cycle!");
                shelterOrCurrentRoom = currentPlayerRoom;
                self.game.GetStorySession.saveState.forcePupsNextCycle = 2;
            }
            else
            {
                if (listOfShelters.Count == 0)
                {

                    CustomLogger!.LogWarning(
                        "No shelters for pup spawns"
                    );
                    return numOfAlivePups;
                }

                if (listOfShelters.Count == 1)
                {

                    CustomLogger!.LogWarning(
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
                if (j > 2 && listOfShelters.Count > 1)// um jeito de consertar o final da campanha do gourmand com j > 2
                    shelterOrCurrentRoom = listOfShelters[UnityEngine.Random.Range(0, listOfShelters.Count)];

                AbstractCreature slugPup = new(self, StaticWorld.GetCreatureTemplate(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC), null, new WorldCoordinate(shelterOrCurrentRoom.index, -1, -1, 0), self.game.GetNewID());
                shelterOrCurrentRoom.AddEntity(slugPup);
                if (shelterOrCurrentRoom.realizedRoom != null)
                {
                    slugPup.RealizeInRoom();
                }

                (slugPup.state as PlayerNPCState)!.foodInStomach = 1;
                numOfAlivePups++;

                CustomLogger.LogInfo("Created slugpup! " + slugPup + " at " + shelterOrCurrentRoom.name + " " + shelterOrCurrentRoom.index);
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