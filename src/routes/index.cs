using RestSharp;
using RestSharp.Authenticators;
using System;
using d3bot.constructors;
using System.Threading.Tasks;

namespace d3bot.src.routes
{
    public class Index
    {
        public static async Task<IRestResponse> request(string url, string method) {
            var Client = new RestClient(url);
            RestRequest Request = null;
            if (method == "get")
                Request = new RestRequest(Method.GET);
            else if (method == "post")
                Request = new RestRequest(Method.POST);
            if (Request != null) {
                Client.Timeout = -1;
                return await Client.ExecuteAsync(Request);
            }
            else
                Console.WriteLine("Error: Request object not define");
            return null;
        }

        public static async Task<IRestResponse> request(string url, string method, ReqParam[] Params, ReqHeader[] Headers) {
            var Client = new RestClient(url);
            RestRequest Request = null;
            if (method == "get")
                Request = new RestRequest(Method.GET);
            else if (method == "post")
                Request = new RestRequest(Method.POST);
            if (Request != null) {
                foreach (ReqParam Param in Params) {
                    if (Param.paramType != ParameterType.RequestBody || Param.paramType != ParameterType.UrlSegment)
                        Request.AddParameter(Param.key, Param.value, Param.paramType);
                    else 
                        Request.AddParameter(Param.key, Param.value);
                }
                foreach (ReqHeader Header in Headers)
                    Request.AddHeader(Header.key, Header.value);
                Client.Timeout = -1;
                return await Client.ExecuteAsync(Request);
            }
            else
                Console.WriteLine("Error: Request object not define");
            return null;
        }
    }
}