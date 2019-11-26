using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RedditPoster
{
    static class LoginMannager
    {
        public async static Task<string> Login()
        {
            var refresh_token_string = "refresh_token";
            var refresh_token = "399457976821-F0-lSUsM_rUw163rmrGTBoSQPGY";

            var client = new RestClient("https://www.reddit.com/api/v1/access_token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "loid=000000000053ivrogu.2.1574767310721.Z0FBQUFBQmQzUXJPLW1Gc1dmdzd4OGxYSHdlMHFpNk56eXRWbENfS1JTSnN3X3oteXcwNnlZT3RReGV3MVZtUkdTUWJqLWhzT0pCZ3FmSXZKZ0YyYkdkbmp6a09IdUYwbWhUZzJTTExYVkhaZlFLdHZVcGYtZDBDTmJqdmlpN0tTREVMM1RzVUdBSVU; edgebucket=cIFUejpwHE384WWdCQ; token=; initref=github.com; session=85788d068a62d8bc402a770e294e51137b3e5a1cgASVSQAAAAAAAABKpC7dXUdB13dJ986I5H2UjAdfY3NyZnRflIwoZWM1NTNhNmY1NWI5NzRjZmY1Njc5NjQxMTUwOGE2MjUwY2UwNTFjYpRzh5Qu; session_tracker=zM3BcnM3SGMoBw88Ml.0.1574777232287.Z0FBQUFBQmQzVEdRaHRxOUY3Rk41Y3RjeERUWmVxYi1wRUFWUjBsRjJHbnRDUXZJYUVPM1NUS0dDWUM4dmp1aXJLSDNNbTNtZmF0ZUllaWlCVm52ekxOdkdJaGRDaFFkeHllWEpIRTB4NDg3V25TdnlpWmdCbTVRWDB6UUVVMzFIa2JwOG11bFBQSnQ");
            request.AddHeader("Content-Length", "79");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "www.reddit.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "Others");
            request.AddHeader("Authorization", "Basic TGZGeFp5eGlGQ0ZSZVE6UGxZMzFpZDRSbWZrYlNVdzJ2a2RsUGUyYjVR");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type={refresh_token_string}&refresh_token={refresh_token}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var token = JsonConvert.DeserializeObject<Token>(response.Content);

            Console.WriteLine("Logged in Reddit");

            return token.Access_Token;

        }
    }
}
