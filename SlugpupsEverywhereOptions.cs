using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using UnityEngine;

namespace SlugpupsEverywhere
{
    public class SlugpupsEverywhereOptions : OptionInterface
    {
        private readonly CustomLogger Logger;
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
        public InGameTranslator InGameTranslator;

        private UIelement[] UIArrPlayerOptions;
        public SlugpupsEverywhereOptions(CustomLogger loggerSource)
        {
            this.Logger = loggerSource;
            this.AmountOfPups = this.config.Bind<int>("AmountOfPups", 2, new ConfigAcceptableRange<int>(0, 500));
            this.SlugpupSpawnChance = this.config.Bind<float>("SlugpupSpawnChance", 1f, new ConfigAcceptableRange<float>(0f, 1f));
            this.AllowWhiteCampaignSlugpups = this.config.Bind<bool>("AllowWhiteCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowYellowCampaignSlugpups = this.config.Bind<bool>("AllowYellowCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowRedCampaignSlugpups = this.config.Bind<bool>("AllowRedCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowGourmandCampaignSlugpups = this.config.Bind<bool>("AllowGourmandCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowArtificerCampaignSlugpups = this.config.Bind<bool>("AllowArtificerCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowRivuletCampaignSlugpups = this.config.Bind<bool>("AllowRivuletCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowSpearmasterCampaignSlugpups = this.config.Bind<bool>("AllowSpearmasterCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.AllowSaintCampaignSlugpups = this.config.Bind<bool>("AllowSaintCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            this.IsCustomSlugpupSpawnChance = this.config.Bind<bool>("IsCustomSlugpupSpawnChance", false, new ConfigAcceptableRange<bool>(false, true));
            this.IsByPassAllowedNumOfPups = this.config.Bind<bool>("IsByPassAllowedNumOfPups", false, new ConfigAcceptableRange<bool>(false, true));
            this.AllowPupsInExpedition = this.config.Bind<bool>("AllowPupsInExpedition", true, new ConfigAcceptableRange<bool>(false, true));
        }

        public override void Initialize()
        {
            string optionsString = InGameTranslator.Translate("Options");
            OpTab opTab = new(this, optionsString);
            this.Tabs =
            [
                opTab
            ];
            this.UIArrPlayerOptions =
            [
                new OpLabel(10f, 570f, "Options", true),
                new OpLabel(10f, 540f, "Possible amount of pups to spawn in the region", false),
                new OpSlider(this.AmountOfPups, new Vector2(20f, 490f), 1.1f, false),
                new OpLabel(10f, 450f, "Bypass allowed numbers of pups in a region?", false),
                new OpCheckBox(this.IsByPassAllowedNumOfPups, new Vector2(270f, 450f)),
                new OpLabel(10f, 410f, "Note: If you want to bypass the allowed number of pups in a region, you can set this to true. This will\n allow you to spawn as many pups as you want in a region.", false),
                new OpLabel(10f, 370f, "Allow pups to spawn on:", true),
                new OpLabel(10f, 340f, "Monk campaign", false),
                new OpCheckBox(this.AllowYellowCampaignSlugpups, new Vector2(10f, 310f)),
                new OpLabel(10f, 280f, "Survivor campaign", false),
                new OpCheckBox(this.AllowWhiteCampaignSlugpups, new Vector2(10f, 250f)),
                new OpLabel(160f, 340f, "Hunter campaign", false),
                new OpCheckBox(this.AllowRedCampaignSlugpups, new Vector2(160f, 310f)),
                new OpLabel(160f, 280f, "Gourmand campaign", false),
                new OpCheckBox(this.AllowGourmandCampaignSlugpups, new Vector2(160f, 250f)),
                new OpLabel(310f, 340f, "Artificer campaign", false),
                new OpCheckBox(this.AllowArtificerCampaignSlugpups, new Vector2(310f, 310f)),
                new OpLabel(310f, 280f, "Rivulet campaign", false),
                new OpCheckBox(this.AllowRivuletCampaignSlugpups, new Vector2(310f, 250f)),
                new OpLabel(460f, 340f, "Spearmaster campaign", false),
                new OpCheckBox(this.AllowSpearmasterCampaignSlugpups, new Vector2(460f, 310f)),
                new OpLabel(460f, 280f, "Saint campaign", false),
                new OpCheckBox(this.AllowSaintCampaignSlugpups, new Vector2(460f, 250f)),
                new OpLabel(10f, 190f, "Do you want a custom pup spawn chance?", true),
                new OpCheckBox(this.IsCustomSlugpupSpawnChance, new Vector2(430f, 190f)),
                new OpFloatSlider(this.SlugpupSpawnChance, new Vector2(20f, 140f), 545, 2, false),
                new OpLabel(10f, 100f, "Allow pups to be spawned in expedition?", false),
                new OpCheckBox(this.AllowPupsInExpedition, new Vector2(240f, 100f))
            ];
            opTab.AddItems(this.UIArrPlayerOptions);
        }

        public override void Update()
        {
            bool flag = this.UIArrPlayerOptions == null;
            if (!flag)
            {
                bool valueBool = ValueExt.GetValueBool((OpCheckBox)UIArrPlayerOptions[24]);
                if (valueBool)
                {
                    ((OpFloatSlider)this.UIArrPlayerOptions[25]).Show();
                }
                else
                {
                    ((OpFloatSlider)this.UIArrPlayerOptions[25]).Hide();
                }
            }
        }
    }
}
