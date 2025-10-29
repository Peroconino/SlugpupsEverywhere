using System;
using System.Collections.Generic;
using BepInEx;
using MoreSlugcats;
using RWCustom;
using Random = UnityEngine.Random;

namespace SlugpupsEverywhere
{
  [BepInPlugin(GUID, Name, Version)]
  public class SlugpupsEverywhere : BaseUnityPlugin
  {
    public const string GUID = "Peroconino.SlugpupsEverywhere";
    public const string Version = "1.0.4";
    public const string Name = "Pups Everywhere";
    private readonly SlugpupsEverywhereOptions Options;
    public InGameTranslator InGameTranslator;
    private readonly CustomLogger CustomLogger;
    private bool IsInit;
    public SlugpupsEverywhere()
    {
      try
      {
        Options = new SlugpupsEverywhereOptions(CustomLogger);
        CustomLogger = new CustomLogger();
      }
      catch (Exception data)
      {
        CustomLogger.LogError(data);
      }
    }

    public void OnEnable()
    {
      On.RainWorld.OnModsInit += RainWorldOnOnModsInit;
    }

    private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
      orig(self);
      bool isInit = IsInit;
      if (!isInit)
      {
        try
        {
          InGameTranslator = new InGameTranslator(self);
          MachineConnector.SetRegisteredOI(GUID, Options);
          IsInit = true;
        }
        catch (Exception data)
        {
          CustomLogger.LogError(data);
        }
      }
    }

    public int hook_SpawnPupNPCs(On.World.orig_SpawnPupNPCs _orig, World self)
    {
      bool flag = self.game.world.singleRoomWorld || self.game.rainWorld.safariMode || self.game.wasAnArtificerDream || self.game.GetStorySession.Players.Count == 0;
      int result;
      if (flag)
      {
        result = 0;
      }
      else
      {
        int num = 0;
        int num2 = 0;
        AbstractRoom room = self.game.GetStorySession.Players[0].Room;
        foreach (AbstractCreature abstractCreature in room.creatures)
        {
          bool flag2 = abstractCreature != null && abstractCreature.state.alive && abstractCreature.creatureTemplate.type == MoreSlugcatsEnums.CreatureTemplateType.SlugNPC;
          if (flag2)
          {
            num++;
            num2++;
          }
        }
        Random.State state = Random.state;
        self.game.GetStorySession.SetRandomSeedToCycleSeed(self.region.regionNumber);
        bool flag3 = Random.value >= CalculatePupSpawnChance(self.region.regionParams.slugPupSpawnChance) && self.game.GetStorySession.saveStateNumber != MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel && self.game.GetStorySession.saveState.forcePupsNextCycle != 1;
        if (flag3)
        {
          CustomLogger.LogInfo(string.Format("No slugpups this cycle, region spawn chance: {0}", self.region.regionParams.slugPupSpawnChance));
          Random.state = state;
          result = num;
        }
        else
        {
          int num3 = CalculatePupNumber(self.game.GetStorySession.saveState);
          CustomLogger.LogInfo(string.Format("Allowed number of pups to spawn this cycle: {0}", num3 - num));
          bool flag4 = num < num3;
          if (flag4)
          {
            List<AbstractRoom> list = [];
            foreach (AbstractRoom abstractRoom in self.abstractRooms)
            {
              bool flag5 = abstractRoom != room && abstractRoom.shelter && abstractRoom.name != "SU_S05";
              if (flag5)
              {
                list.Add(abstractRoom);
              }
            }
            int num4 = Options.IsByPassAllowedNumOfPups.Value ? (num3 - num) : 1;
            bool flag6 = self.game.GetStorySession.saveState.forcePupsNextCycle == 1;
            AbstractRoom abstractRoom2;
            if (flag6)
            {
              CustomLogger.LogInfo("Pups forced into this cycle!");
              abstractRoom2 = room;
              self.game.GetStorySession.saveState.forcePupsNextCycle = 2;
            }
            else
            {
              bool flag7 = list.Count == 0;
              if (flag7)
              {
                CustomLogger.LogWarning("No shelters for pup spawns");
                return num;
              }
              bool flag8 = list.Count == 1;
              if (flag8)
              {
                CustomLogger.LogWarning("only a SINGLE shelter for pup spawns");
                abstractRoom2 = list[0];
              }
              else
              {
                abstractRoom2 = list[Random.Range(0, list.Count)];
              }
            }
            for (int j = 0; j < num4; j++)
            {
              bool flag9 = j > 2 && list.Count > 1;
              if (flag9)
              {
                abstractRoom2 = list[Random.Range(0, list.Count)];
              }
              AbstractCreature abstractCreature2 = new(self, StaticWorld.GetCreatureTemplate(MoreSlugcatsEnums.CreatureTemplateType.SlugNPC), null, new WorldCoordinate(abstractRoom2.index, -1, -1, 0), self.game.GetNewID());
              bool flag10 = abstractCreature2 == null;
              if (flag10)
              {
                CustomLogger.LogError("Failed to create slugpup!");
              }
              else
              {
                abstractRoom2.AddEntity(abstractCreature2);
                bool flag11 = abstractRoom2.realizedRoom != null;
                if (flag11)
                {
                  abstractCreature2.RealizeInRoom();
                }
                (abstractCreature2.state as PlayerNPCState).foodInStomach = 1;
                num++;
                CustomLogger customLogger = CustomLogger;
                string[] array = new string[6];
                array[0] = "Created slugpup! ";
                int num5 = 1;
                AbstractCreature abstractCreature3 = abstractCreature2;
                array[num5] = abstractCreature3?.ToString();
                array[2] = " at ";
                array[3] = abstractRoom2.name;
                array[4] = " ";
                array[5] = abstractRoom2.index.ToString();
                customLogger.LogInfo(string.Concat(array));
              }
            }
          }
          Random.state = state;
          result = num2;
        }
      }
      return result;
    }

    private int CalculatePupNumber(SaveState saveState)
    {
      bool flag = Options == null || !ModManager.MSC || (!saveState.progression.miscProgressionData.beaten_Gourmand_Full && !MoreSlugcats.MoreSlugcats.chtUnlockSlugpups.Value && (!ModManager.Expedition || !Custom.rainWorld.ExpeditionMode || !Options.AllowPupsInExpedition.Value));
      int result;
      if (flag)
      {
        result = 0;
      }
      else
      {
        bool flag2 = (saveState.saveStateNumber == SlugcatStats.Name.White && !Options.AllowWhiteCampaignSlugpups.Value) || (saveState.saveStateNumber == SlugcatStats.Name.Yellow && !Options.AllowYellowCampaignSlugpups.Value) || (saveState.saveStateNumber == SlugcatStats.Name.Red && !Options.AllowRedCampaignSlugpups.Value) || (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Gourmand && !Options.AllowGourmandCampaignSlugpups.Value) || (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Artificer && !Options.AllowArtificerCampaignSlugpups.Value) || (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Rivulet && !Options.AllowRivuletCampaignSlugpups.Value) || (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Spear && !Options.AllowSpearmasterCampaignSlugpups.Value) || (saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Saint && !Options.AllowSaintCampaignSlugpups.Value);
        if (flag2)
        {
          result = 0;
        }
        else
        {
          bool flag3 = saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Sofanthiel;
          if (flag3)
          {
            result = 1000;
          }
          else
          {
            result = Options.AmountOfPups.Value;
          }
        }
      }
      return result;
    }

    private float CalculatePupSpawnChance(float origPupSpawnChance)
    {
      bool flag = Options == null || !Options.IsCustomSlugpupSpawnChance.Value;
      float result;
      if (flag)
      {
        result = origPupSpawnChance;
      }
      else
      {
        result = Options.SlugpupSpawnChance.Value;
      }
      return result;
    }
  }
}
