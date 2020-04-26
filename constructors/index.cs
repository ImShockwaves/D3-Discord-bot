using System;

namespace d3bot.constructors
{
    public class Globals {
        public static Token Token;
    }

    public class Token {
        public string access_token {get;set;}
        public string token_type {get;set;}
        public int expires_in {get;set;}
    }

    public class ReqParam {
        public string key {get; set;}
        public string value {get;set;}
        public RestSharp.ParameterType paramType {get; set;}
    }

    public class ReqHeader {
        public string key {get; set;}
        public string value {get;set;}
    }

    public class Env {
        public static string   getVar(string envVar) {
            return Environment.GetEnvironmentVariable(envVar);
        }
    }
}