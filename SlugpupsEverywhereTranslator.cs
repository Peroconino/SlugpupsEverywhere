using RWCustom;

namespace SlugpupsEverywhere
{
  public static class SlugpupsEverywhereTranslator
  {
    private readonly static InGameTranslator inGameTranslator = Custom.rainWorld.inGameTranslator;
    public static string GetQuantityText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Quantidade possível de filhotes para aparecer na região";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Número posible de crías que aparecerán en la región";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Mögliche Anzahl der Nachkommen, die in der Region auftreten können";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Possibile numero di prole che apparirà nella regione";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Nombre possible de descendants qui apparaîtront dans la région";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "該地區可能出現的後代數量";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Возможное количество потомков, которые могут появиться в регионе";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "この地域に出現する可能性のある子孫の数";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "해당 지역에 나타날 수 있는 자손의 수";
      }
      else
      {
        return "Possible amount of pups to spawn in the region";
      }
    }

    public static string GetByPassText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Ignorar o número permitido de filhotes em uma região?";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "¿Ignorar el número permitido de cachorros en una región?";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Die zulässige Anzahl von Welpen in einer Region ignorieren?";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Ignorare il numero consentito di cuccioli in una regione?";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Ignorer le nombre autorisé de chiots dans une région ?";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "无视一个地区允许饲养的幼犬数量？";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Игнорирование разрешенного количества щенков в регионе?";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "地域で許可されている子犬の数を無視していますか?";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "특정 지역에서 허용되는 강아지 수를 무시하는 것인가요?";
      }
      else
      {
        return "Bypass allowed numbers of pups in a region?";
      }
    }

    public static string GetNoteText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Nota: Se você quiser ignorar o número permitido de filhotes em uma região, você pode definir isso como\n verdadeiro. Isso permitirá que você gere quantos filhotes quiser em uma região.";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Nota: Si desea ignorar el número permitido de cachorros en una región, puede activar esta opción.\nEsto le permitirá generar tantos cachorros como desee en una región.";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Hinweis: Wenn Sie die zulässige Anzahl an Welpen in einer Region ignorieren möchten, können Sie diese\n Option auf „true“ setzen. Dadurch können Sie in einer Region beliebig viele Welpen generieren.";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Nota: se vuoi ignorare il numero consentito di cuccioli in una regione, puoi impostare questo parametro\n su 'true'.Questo ti permetterà di generare tutti i cuccioli che desideri in una regione.";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Remarque : Si vous souhaitez ignorer le nombre de chiots autorisés dans une région, vous pouvez définir\n cette option sur « vrai ».Vous pourrez alors générer autant de chiots que vous le souhaitez dans cette région.";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "注意：如果您想忽略某个区域内允许的幼犬数量限制，可以将其设置为 true。\n这样您就可以在一个区域内生成任意数量的幼犬。";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Примечание: Если вы хотите игнорировать допустимое количество щенков в регионе, установите значение true.\nЭто позволит вам генерировать в регионе столько щенков, сколько нужно.";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "注: 地域内で子犬の許容数を無視したい場合は、これをtrueに設定してください。\nこれにより、地域内で必要な数の子犬を生成できるようになります。";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "참고: 특정 지역에 허용되는 강아지 수를 무시하려면 이 값을 true로 설정하면 됩니다.\n이렇게 하면 특정 지역에 원하는 만큼 강아지를 생성할 수 있습니다.";
      }
      else
      {
        return "Note: If you want to bypass the allowed number of pups in a region, you can set this to true.\nThis will allow you to spawn as many pups as you want in a region.";
      }
    }

    public static string GetAllowText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Permitir que filhotes apareçam nas campanhas:";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Permitir que los cachorros aparezcan en las campañas:";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Welpen dürfen in Kampagnen auftreten:";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Consenti ai cuccioli di apparire nelle campagne:";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Autoriser l'apparition de chiots dans les campagnes :";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "允许幼犬出现在竞选活动中：";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Разрешить щенкам появляться в кампаниях:";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "キャンペーンに子犬が登場することを許可する:";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "캠페인에 강아지 등장 허용:";
      }
      else
      {
        return "Allow pups to spawn on whichs campaigns:";
      }
    }

    public static string GetMonkText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Monge";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Monje";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Mönch";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Monaco";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Moine";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "僧";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Монах";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "モンク";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "수도사";
      }
      else
      {
        return "Monk";
      }
    }

    public static string GetSurvivorText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Sobrevivente";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Sobreviviente";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Überlebende";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Sopravvissuto";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Survivant";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "幸存者";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Выживший";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "サバイバー";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "살아남은 사람";
      }
      else
      {
        return "Survivor";
      }
    }

    public static string GetHunterText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Caçador";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Cazador";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Jäger";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Cacciatore";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Chasseur";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "猎人";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Охотник";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "ハンター";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "사냥꾼";
      }
      else
      {
        return "Hunter";
      }
    }

    public static string GetGourmandText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Gourmet";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Goloso";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Gourmand";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Buongustaio";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Gourmande";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "美食家";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Гурман";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "美食家";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "대식가";
      }
      else
      {
        return "Gourmand";
      }
    }

    public static string GetArtificierText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Artífice";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Artífice";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Künstler";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Artefice";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Artificier";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "技师";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Ремесленник";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "工匠";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "기술자";
      }
      else
      {
        return "Artificer";
      }
    }

    public static string GetRivuletText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Riacho";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Riachuelo";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Bach";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Rivolo";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Ruisseau";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "溪流";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Ривулет";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "細流";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "개울";
      }
      else
      {
        return "Rivulet";
      }
    }

    public static string GetSpearmasterText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Mestre das Lanças";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Maestro de lanza";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Speermeister";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Maestro di lancia";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Maître de lance";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "枪王";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Мастер копья";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "スピアマスター";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "창술의 달인";
      }
      else
      {
        return "Spearmaster";
      }
    }

    public static string GetSaintText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Santo";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Santo";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Heilige";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Santo";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Sainte";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "圣";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Святой";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "聖人";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "성자";
      }
      else
      {
        return "Saint";
      }
    }

    public static string GetTheWatcherText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "O Observador";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "El vigilante";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Der Wächter";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "L'Osservatore";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "L'Observateur";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "守望者";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Наблюдатель";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "ウォッチャー";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "감시자";
      }
      else
      {
        return "The Watcher";
      }
    }

    public static string GetCustomSpawnText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Usar chance de nascer personalizada para filhotes?";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "¿Usar una probabilidad de aparición personalizada para las crías?";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Benutzerdefinierte Spawn-Chance für Welpen verwenden?";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Utilizzare la probabilità di spawn personalizzata per i cuccioli?";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Utiliser une probabilité d'apparition personnalisée pour les chiots ?";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "是否可以使用自定义幼崽生成几率？";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Использовать пользовательский шанс появления щенков?";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "子犬のスポーンチャンスをカスタム設定しますか?";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "강아지의 생성 확률을 사용자 정의로 설정할까요?";
      }
      else
      {
        return "Use custom spawn chance for pups?";
      }
    }

    public static string GetExpeditionText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Permitir que filhotes apareçam em expedições?";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "¿Permitir que aparezcan cachorros en la expedición?";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Sollen Welpen in Expeditionen erscheinen dürfen?";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Consentire la generazione di cuccioli durante la spedizione?";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Autoriser l'apparition de chiots en expédition ?";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "允许在探险模式中生成幼崽吗？";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Разрешить рождение щенков в экспедиции?";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "遠征中に子犬が生まれるのを許可しますか?";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "원정 중에 새끼를 낳도록 허용할까요?";
      }
      else
      {
        return "Allow pups to be spawned in expedition?";
      }
    }

    public static string GetCapText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Reestringir o número de filhotes por ciclo:";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Restringir el número de crías por ciclo:";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Beschränken Sie die Anzahl der Welpen pro Zyklus:";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Limitare il numero di cuccioli per ciclo:";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Limiter le nombre de chiots par cycle :";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "限制每个繁殖周期内的幼崽数量：";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Ограничить количество щенков за цикл:";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "サイクルあたりの子犬の数を制限します:";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "주기당 새끼 수 제한:";
      }
      else
      {
        return "Restrict number of pups per cycle:";
      }
    }

    public static string GetCapabilitiesText()
    {
      InGameTranslator.LanguageID language = inGameTranslator.currentLanguage;

      if (language == InGameTranslator.LanguageID.Portuguese)
      {
        return "Capacidades";
      }
      else if (language == InGameTranslator.LanguageID.Spanish)
      {
        return "Capacidades";
      }
      else if (language == InGameTranslator.LanguageID.German)
      {
        return "Fähigkeiten";
      }
      else if (language == InGameTranslator.LanguageID.Italian)
      {
        return "Capacità";
      }
      else if (language == InGameTranslator.LanguageID.French)
      {
        return "Capacités";
      }
      else if (language == InGameTranslator.LanguageID.Chinese)
      {
        return "能力";
      }
      else if (language == InGameTranslator.LanguageID.Russian)
      {
        return "Возможности";
      }
      else if (language == InGameTranslator.LanguageID.Japanese)
      {
        return "能力";
      }
      else if (language == InGameTranslator.LanguageID.Korean)
      {
        return "기능";
      }
      else
      {
        return "Capabilities";
      }
    }
  }
}