using d3bot.constructors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using d3bot.src.routes;
using System.Threading.Tasks;

namespace d3bot.src.routes
{
    public class Credentials
    {
        public static async Task<Token>    createAccessToken(string apiKey, string apiSecret) {
            string url = "http://eu.battle.net/oauth/token";
            string method = "post";
            ReqParam[] Params = { 
                new ReqParam{ 
                    key = "application/x-www-form-urlencoded",
                    value = $"grant_type=client_credentials&client_id={apiKey}&client_secret={apiSecret}",
                    paramType = ParameterType.RequestBody
                }
            };
            ReqHeader[] Headers = { 
                new ReqHeader{ 
                    key = "cache-control",
                    value = "no-cache",
                }, new ReqHeader{ 
                    key = "content-type",
                    value = "application/x-www-form-urlencoded",
                }
            };
            IRestResponse Res = await Index.request(url, method, Params, Headers);
            return JsonConvert.DeserializeObject<Token>(Res.Content);
        }
    }
}