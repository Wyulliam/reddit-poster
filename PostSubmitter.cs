using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace RedditPoster
{
    static class PostSubmitter
    {
        private static int count = 1;
        public async static Task Submit(string token)
        {
            var title = $"Testing how many posts before login ends Part {count}";
            var image = "https://reddit-uploaded-media.s3-accelerate.amazonaws.com/rte_images/k653i4tos1141";

            var client =
                new RestClient(
                    "https://oauth.reddit.com/api/submit?resubmit=true&redditWebClient=desktop2x&app=desktop2x-client-production&rtj=only&raw_json=1&gilding_detail=1");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Length", "905");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Content-Type",
                "multipart/form-data; boundary=--------------------------551582990259895213657303");
            request.AddHeader("Host", "oauth.reddit.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type",
                "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"api_type\"\r\n\r\njson\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"sr\"\r\n\r\nafricatotomemes\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"submit_type\"\r\n\r\nsubreddit\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"title\"\r\n\r\n"+title+"\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"kind\"\r\n\r\nimage\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"richtext_json\"\r\n\r\n{\"document\":[{\"e\":\"par\",\"c\":[{\"e\":\"text\",\"t\":\"A\"}]}]}\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"validate_on_submit\"\r\n\r\ntrue\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"url\"\r\n\r\n"+image+"\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic responseText = JsonConvert.DeserializeObject(response.Content);

            Console.WriteLine($"Resultado post {count}. Hora: {DateTime.Now.ToLongTimeString()}. Erro: {responseText}");
        }
    }
}
