using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RedditPoster
{
    public static class ImgurLogin
    {
        public static string ClientId = "67ec2aaf43a9114";

        public static async Task<string> RefreshToken()
        {
            var refreshToken = "efc31e97ccba81ac5f217ba0fe588d91b2e82ffa";
            var clientSecret = "b8619c8d75042d174509911757217e7e640dc115";

            var client = new RestClient("https://api.imgur.com/oauth2/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Length", "160");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "api.imgur.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=refresh_token&refresh_token={refreshToken}&client_id={ClientId}&client_secret={clientSecret}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var token = JsonConvert.DeserializeObject<Token>(response.Content);

            Console.WriteLine("Refreshed Imgur Token");

            return token.Access_Token;
        }
    }
}