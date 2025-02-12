using System;
using BepInEx.Logging;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using UnityEngine;

namespace SlugpupsEverywhere;

public class SlugpupsEverywhereOptions : OptionInterface
{
    private readonly ManualLogSource Logger;
    public readonly Configurable<bool> AllowYellowCampaignSlugpups;
    public readonly Configurable<bool> AllowWhiteCampaignSlugpups;
    public readonly Configurable<bool> AllowRedCampaignSlugpups;
    public readonly Configurable<bool> AllowGourmandCampaignSlugpups;
    public readonly Configurable<bool> AllowArtificerCampaignSlugpups;
    public readonly Configurable<bool> AllowRivuletCampaignSlugpups;
    public readonly Configurable<bool> AllowSpearmasterCampaignSlugpups;
    public readonly Configurable<bool> AllowSaintCampaignSlugpups;
    public readonly Configurable<bool> IsCustomSlugpupSpawnChance;
    public readonly Configurable<bool> IsByPassAllowedNumOfPups;
    public readonly Configurable<bool> AllowPupsInExpedition;
    public readonly Configurable<int> AmountOfPups;
    public readonly Configurable<float> SlugpupSpawnChance;
    private UIelement[]? UIArrPlayerOptions;
    public SlugpupsEverywhereOptions(SlugpupsEverywhere modInstance, ManualLogSource loggerSource)
    {
        Logger = loggerSource;
        AmountOfPups = this.config.Bind<int>(nameof(AmountOfPups), 2, new ConfigAcceptableRange<int>(0, 500));
        SlugpupSpawnChance = this.config.Bind<float>(nameof(SlugpupSpawnChance), 1, new ConfigAcceptableRange<float>(0, 1));
        AllowWhiteCampaignSlugpups = this.config.Bind<bool>(nameof(AllowWhiteCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowYellowCampaignSlugpups = this.config.Bind<bool>(nameof(AllowYellowCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowRedCampaignSlugpups = this.config.Bind<bool>(nameof(AllowRedCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowGourmandCampaignSlugpups = this.config.Bind<bool>(nameof(AllowGourmandCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowArtificerCampaignSlugpups = this.config.Bind<bool>(nameof(AllowArtificerCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowRivuletCampaignSlugpups = this.config.Bind<bool>(nameof(AllowRivuletCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowSpearmasterCampaignSlugpups = this.config.Bind<bool>(nameof(AllowSpearmasterCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        AllowSaintCampaignSlugpups = this.config.Bind<bool>(nameof(AllowSaintCampaignSlugpups), true, new ConfigAcceptableRange<bool>(false, true));
        IsCustomSlugpupSpawnChance = this.config.Bind<bool>(nameof(IsCustomSlugpupSpawnChance), false, new ConfigAcceptableRange<bool>(false, true));
        IsByPassAllowedNumOfPups = this.config.Bind<bool>(nameof(IsByPassAllowedNumOfPups), false, new ConfigAcceptableRange<bool>(false, true));
        AllowPupsInExpedition = this.config.Bind<bool>(nameof(AllowPupsInExpedition), true, new ConfigAcceptableRange<bool>(false, true));
    }
    public override void Initialize()
    {
        var opTab = new OpTab(this, "Options");
        this.Tabs =
        [
            opTab
        ];

        UIArrPlayerOptions =
        [
            new OpLabel(10f, 570f, "Options", true),
            new OpLabel(10f, 540f, "Possible amount of pups to spawn in the region"),
            new OpSlider(AmountOfPups, new Vector2(20f, 490f),1.1f),
            new OpLabel(10f, 450f, "Bypass allowed numbers of pups in a region?"),
            new OpCheckBox(IsByPassAllowedNumOfPups, new Vector2(270f, 450f)),
            new OpLabel(10f, 410f, "Note: If you want to bypass the allowed number of pups in a region, you can set this to true. This will\n allow you to spawn as many pups as you want in a region."),
            new OpLabel(10f, 370f, "Allow pups to spawn on:", true),
            new OpLabel(10f, 340f, "Monk campaign"),
            new OpCheckBox(AllowYellowCampaignSlugpups, new Vector2(10f, 310f)),
            new OpLabel(10f, 280f, "Survivor campaign"),
            new OpCheckBox(AllowWhiteCampaignSlugpups, new Vector2(10f, 250f)),
            new OpLabel(160f, 340f, "Hunter campaign"),
            new OpCheckBox(AllowRedCampaignSlugpups, new Vector2(160f, 310f)),
            new OpLabel(160f, 280f, "Gourmand campaign"),
            new OpCheckBox(AllowGourmandCampaignSlugpups, new Vector2(160f, 250f)),
            new OpLabel(310f, 340f, "Artificer campaign"),
            new OpCheckBox(AllowArtificerCampaignSlugpups, new Vector2(310f, 310f)),
            new OpLabel(310f, 280f, "Rivulet campaign"),
            new OpCheckBox(AllowRivuletCampaignSlugpups, new Vector2(310f, 250f)),
            new OpLabel(460f, 340f, "Spearmaster campaign"),
            new OpCheckBox(AllowSpearmasterCampaignSlugpups, new Vector2(460f, 310f)),
            new OpLabel(460f, 280f, "Saint campaign"),
            new OpCheckBox(AllowSaintCampaignSlugpups, new Vector2(460f, 250f)),
            new OpLabel(10f, 190f, "Do you want a custom pup spawn chance?", true),
            new OpCheckBox(IsCustomSlugpupSpawnChance,new Vector2(430f, 190f)),
            new OpFloatSlider(SlugpupSpawnChance, new Vector2(20f, 140f), 545, 2),
            new OpLabel(10f,100f,"Allow pups to be spawned in expedition?"),
            new OpCheckBox(AllowPupsInExpedition,new Vector2(240f,100f)),
        ];
        opTab.AddItems(UIArrPlayerOptions);
    }
    public override void Update()
    {
        if (UIArrPlayerOptions is null)
        {
            return;
        }

        if (((OpCheckBox)UIArrPlayerOptions[24]).GetValueBool())
        {
            ((OpFloatSlider)UIArrPlayerOptions[25]).Show();
        }
        else
        {
            ((OpFloatSlider)UIArrPlayerOptions[25]).Hide();
        }
    }
}