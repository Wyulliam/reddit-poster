using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace RedditPoster
{
    static class PostSubmitter
    {
        private static int count = 1;
        public async static Task Submit(string token, string imageUrl)
        {
            var title = Parameters.PostTitle;
            var image = imageUrl;
            var subreddit = Parameters.Subredit;
            var client =
                new RestClient(
                    "https://oauth.reddit.com/api/submit?resubmit=true&redditWebClient=desktop2x&app=desktop2x-client-production&rtj=only&raw_json=1&gilding_detail=1");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Content-Type",
                "multipart/form-data; boundary=--------------------------551582990259895213657303");
            request.AddHeader("Host", "oauth.reddit.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("content-type",
                "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", 
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"api_type\"\r\n" +
                "\r\n" +
                "json\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"sr\"\r\n" +
                "\r\n" +
                subreddit+"\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"submit_type\"\r\n" +
                "\r\n" +
                "subreddit\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"title\"\r\n" +
                "\r\n"+
                title+"\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"kind\"\r\n" +
                "\r\n" +
                "image\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"richtext_json\"\r\n" +
                "\r\n" +
                "{\"document\":[{\"e\":\"par\",\"c\":[{\"e\":\"text\",\"t\":\""+Parameters.PostTitle+"\"}]}]}" +
                "\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"validate_on_submit\"\r\n" +
                "\r\n" +
                "true\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"url\"\r\n" +
                "\r\n"+
                image+"\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic responseText = JsonConvert.DeserializeObject(response.Content);

            Console.WriteLine($"Resultado post {count}. Hora: {DateTime.Now.ToLongTimeString()}. Erro: {responseText}");
            count++;
        }
    }
}
