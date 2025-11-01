using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using RWCustom;
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
        public readonly Configurable<bool> AllowTheWatcherCampaignSlugpups;
        public readonly Configurable<bool> IsCustomSlugpupSpawnChance;
        public readonly Configurable<bool> IsByPassAllowedNumOfPups;
        public readonly Configurable<bool> AllowPupsInExpedition;
        public readonly Configurable<int> AmountOfPups;
        public readonly Configurable<int> CappedSpawnAmount;
        public readonly Configurable<float> SlugpupSpawnChance;
        private UIelement[] UIArrPlayerOptions;
        private UIelement[] UIArrCapabilitiesOptions;
        public SlugpupsEverywhereOptions(CustomLogger loggerSource)
        {
            Logger = loggerSource;
            AmountOfPups = config.Bind<int>("AmountOfPups", 7, new ConfigAcceptableRange<int>(0, 500));
            CappedSpawnAmount = config.Bind<int>("CappedSpawnAmount", 500, new ConfigAcceptableRange<int>(0, 500));
            SlugpupSpawnChance = config.Bind<float>("SlugpupSpawnChance", 1f, new ConfigAcceptableRange<float>(0f, 1f));
            AllowWhiteCampaignSlugpups = config.Bind<bool>("AllowWhiteCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowYellowCampaignSlugpups = config.Bind<bool>("AllowYellowCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowRedCampaignSlugpups = config.Bind<bool>("AllowRedCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowGourmandCampaignSlugpups = config.Bind<bool>("AllowGourmandCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowArtificerCampaignSlugpups = config.Bind<bool>("AllowArtificerCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowRivuletCampaignSlugpups = config.Bind<bool>("AllowRivuletCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowSpearmasterCampaignSlugpups = config.Bind<bool>("AllowSpearmasterCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowSaintCampaignSlugpups = config.Bind<bool>("AllowSaintCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowTheWatcherCampaignSlugpups = config.Bind<bool>("AllowTheWatcherCampaignSlugpups", true, new ConfigAcceptableRange<bool>(false, true));
            IsCustomSlugpupSpawnChance = config.Bind<bool>("IsCustomSlugpupSpawnChance", true, new ConfigAcceptableRange<bool>(false, true));
            IsByPassAllowedNumOfPups = config.Bind<bool>("IsByPassAllowedNumOfPups", true, new ConfigAcceptableRange<bool>(false, true));
            AllowPupsInExpedition = config.Bind<bool>("AllowPupsInExpedition", true, new ConfigAcceptableRange<bool>(false, true));
        }

        public override void Initialize()
        {
            InGameTranslator inGameTranslator = Custom.rainWorld.inGameTranslator;



            OpTab opTab = new(this, inGameTranslator.Translate("Options"));
            OpTab capTab = new(this, SlugpupsEverywhereTranslator.GetCapabilitiesText());
            Tabs =
            [
                opTab,
                capTab,
            ];
            UIArrPlayerOptions =
            [
                new OpLabel(10f, 570f, inGameTranslator.Translate("Options"), true),
                new OpLabel(10f, 540f, SlugpupsEverywhereTranslator.GetQuantityText() , false),
                new OpSlider(AmountOfPups, new Vector2(20f, 490f), 1.1f, false),
                new OpLabel(10f, 470f, SlugpupsEverywhereTranslator.GetByPassText(), false),
                new OpCheckBox(IsByPassAllowedNumOfPups, new Vector2(20f, 440f)),
                new OpLabel(10f, 410f, SlugpupsEverywhereTranslator.GetNoteText(), false),
                new OpLabel(10f, 370f, SlugpupsEverywhereTranslator.GetAllowText(), true),
                new OpLabel(10f, 340f, SlugpupsEverywhereTranslator.GetMonkText(), false),
                new OpCheckBox(AllowYellowCampaignSlugpups, new Vector2(10f, 310f)),
                new OpLabel(160f, 340f, SlugpupsEverywhereTranslator.GetHunterText(), false),
                new OpCheckBox(AllowRedCampaignSlugpups, new Vector2(160f, 310f)),
                new OpLabel(310f, 340f, SlugpupsEverywhereTranslator.GetArtificierText(), false),
                new OpCheckBox(AllowArtificerCampaignSlugpups, new Vector2(310f, 310f)),
                new OpLabel(10f, 280f, SlugpupsEverywhereTranslator.GetSurvivorText(), false),
                new OpCheckBox(AllowWhiteCampaignSlugpups, new Vector2(10f, 250f)),
                new OpLabel(160f, 280f, SlugpupsEverywhereTranslator.GetRivuletText(), false),
                new OpCheckBox(AllowRivuletCampaignSlugpups, new Vector2(160f, 250f)),
                new OpLabel(310f, 280f, SlugpupsEverywhereTranslator.GetSaintText(), false),
                new OpCheckBox(AllowSaintCampaignSlugpups, new Vector2(310f, 250f)),
                new OpLabel(10f, 220f, SlugpupsEverywhereTranslator.GetGourmandText(), false),
                new OpCheckBox(AllowGourmandCampaignSlugpups, new Vector2(10f, 190f)),
                new OpLabel(160f, 220f, SlugpupsEverywhereTranslator.GetSpearmasterText(), false),
                new OpCheckBox(AllowSpearmasterCampaignSlugpups, new Vector2(160f, 190f)),
                new OpLabel(310f, 220f, SlugpupsEverywhereTranslator.GetTheWatcherText(), false),
                new OpCheckBox(AllowTheWatcherCampaignSlugpups, new Vector2(310f, 190f)),
                new OpLabel(10f, 140f, SlugpupsEverywhereTranslator.GetCustomSpawnText(), true),
                new OpCheckBox(IsCustomSlugpupSpawnChance, new Vector2(520f, 140f)),
                new OpFloatSlider(SlugpupSpawnChance, new Vector2(20f, 90f), 545, 2, false),
                new OpLabel(10f, 50f, SlugpupsEverywhereTranslator.GetExpeditionText(), false),
                new OpCheckBox(AllowPupsInExpedition, new Vector2(10f, 20f))
            ];
            opTab.AddItems(UIArrPlayerOptions);

            UIArrCapabilitiesOptions =
            [
                new OpLabel(10f, 570f, SlugpupsEverywhereTranslator.GetCapabilitiesText(), true),
                new OpLabel(10f, 540f, SlugpupsEverywhereTranslator.GetCapText() , false),
                new OpSlider(CappedSpawnAmount, new Vector2(20f, 490f), 1.1f, false),
            ];
            capTab.AddItems(UIArrCapabilitiesOptions);

        }

        public override void Update()
        {
            bool flag = UIArrPlayerOptions == null;
            if (!flag)
            {
                bool valueBool = ValueExt.GetValueBool((OpCheckBox)UIArrPlayerOptions[26]);
                if (valueBool)
                {
                    ((OpFloatSlider)UIArrPlayerOptions[27]).Show();
                }
                else
                {
                    ((OpFloatSlider)UIArrPlayerOptions[27]).Hide();
                }
            }
        }
    }
}
