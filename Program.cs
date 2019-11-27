using System;
using System.Threading.Tasks;
using RestSharp;

namespace RedditPoster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("What is the subreddit?");
            Parameters.Subredit = Console.ReadLine();

            Console.WriteLine("What is the next count? (Last post number)");
            Parameters.PostCount = int.Parse(Console.ReadLine());

            Console.WriteLine("(Your folder path need a folder called 'not posted' and a folder called 'posted'");
            Console.WriteLine("What is the folder path?");
            Parameters.FolderPath = Console.ReadLine();

            while (true)
            {
                var nextImage = await ImageSelector.FirstImage(Parameters.FolderPath);

                if (nextImage == null)
                {
                    Console.WriteLine("There was no next image");
                    Console.ReadLine();
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
