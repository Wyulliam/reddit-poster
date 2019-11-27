using System;
using System.Threading.Tasks;

namespace RedditPoster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                var folderPath = @"C:\Users\william.da.silva\Documents\test";

                var nextImage = await ImageSelector.FirstImage(folderPath);

                if (nextImage == null)
                {
                    Console.WriteLine("There was no next image");
                    return;
                }

                var redditToken = await RedditLoggin.Login();

                var imgurToken = await ImgurLogin.RefreshToken();

                var image = await ImageUploader.Upload(imgurToken, nextImage);

                await PostSubmitter.Submit(redditToken, image.Data.Link);

                await ImageFolderUpdater.MoveImage(nextImage);

                await Timer.Start();
            }
        }
    }
}
