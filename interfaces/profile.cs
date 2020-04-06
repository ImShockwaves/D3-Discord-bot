namespace d3bot.interfaces
{
    public class Kills {
        public int elites {get;set;}
    }

    public class Heroes {
        public long id {get;set;}
        public string name {get;set;}
        public string classSlug {get;set;}
        public int gender {get;set;}
        public int level {get;set;}
        public Kills kills {get;set;}
        public int paragonLevel {get;set;}
        public bool hardcore {get;set;}
        public bool seasonal {get;set;}
        public bool dead {get;set;}
        public long last_updated {get;set;}
    }

    public class ProfileInt {
        public int paragonLevel {get;set;}
        public int paragonLevelHardcore {get;set;}
        public int paragonLevelSeason {get;set;}
        public int paragonLevelSeasonHardcore {get;set;}
        public string guildName {get;set;}
        public Heroes[] heroes {get;set;}
    }
}