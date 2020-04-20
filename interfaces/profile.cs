using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace d3bot.interfaces
{
    public class PlayTime {
        [JsonProperty(PropertyName = "demon-hunter")]
        public float demon_hunter {get;set;}
        public float barbarian {get;set;}
        [JsonProperty(PropertyName = "witch-doctor")]
        public float witch_doctor {get;set;}
        public float necromancer {get;set;}
        public float wizard {get;set;}
        public float monk {get;set;}
        public float crusader {get;set;}
    }

    public class KillCount {
        public int monsters {get;set;}
        public int elites {get;set;}
        public int hardcoreMonsters {get;set;}
    }

    public class Heroes {
        public long id {get;set;}
        public string name {get;set;}
        public string classSlug {get;set;}
        public int gender {get;set;}
        public int level {get;set;}
        public KillCount kills {get;set;}
        public int paragonLevel {get;set;}
        public bool hardcore {get;set;}
        public bool seasonal {get;set;}
        public bool dead {get;set;}
        [JsonProperty(PropertyName = "last-updated")]
        public long last_updated {get;set;}
    }

    public class ProfileInt {
        public int paragonLevel {get;set;}
        public int paragonLevelHardcore {get;set;}
        public int paragonLevelSeason {get;set;}
        public int paragonLevelSeasonHardcore {get;set;}
        public string guildName {get;set;}
        public Heroes[] heroes {get;set;}
        public KillCount kills {get;set;}
        public PlayTime timePlayed {get;set;}
    }
    
    public class ProfileDraw
    {
        public static Color ParColor = Color.FromArgb(167, 145,194);
        public static Color BasicColor = Color.FromArgb(173, 131, 90);
        public static Color GuildColor = Color.FromArgb(165, 154, 124);

        public static Color wiz = Color.FromArgb(24, 88, 162);
        public static Color wd = Color.FromArgb(82, 134, 33);
        public static Color dh = Color.FromArgb(88, 43, 121);
        public static Color barb = Color.FromArgb(140, 40, 8);
        public static Color crus = Color.FromArgb(154, 139, 16);
        public static Color monk = Color.FromArgb(143, 92, 24);
        public static Color nec = Color.FromArgb(0, 165, 134);
    }
}