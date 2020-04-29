namespace d3bot.constructors
{
    public class Embd {
        public Footer footer {get;set;}
        public Header header {get;set;}
        public Embeds[] embeds {get;set;}
        public Embeds[] errors {get;set;}
    }

    public class Embeds {
        public string name {get;set;}
        public string title {get;set;}
        public string description {get;set;}
        public Fields[] fields {get;set;}
    }

    public class Fields {
        public string name {get;set;}
        public string value {get;set;}
    }
    public class Footer {
        public string text {get;set;}
    }

    public class Header {
        public uint color {get;set;}
        public string name {get;set;}
        public string icon_url {get;set;}
    }
}