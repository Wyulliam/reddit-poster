using System.Threading.Tasks;

namespace RedditPoster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //while (true)
            //{
                var filePath = @"C:\Users\william.da.silva\Documents\test\x.png";

                var redditToken = await RedditLoggin.Login();

                var imgurToken = await ImgurLogin.RefreshToken();

                var image = await ImageUploader.Upload(imgurToken, filePath);

                //await PostSubmitter.Submit(token);
                //await Timer.Start();
            //}
        }
    }
}
