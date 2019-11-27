using System.Threading.Tasks;
using Rest;

namespace RedditPoster
{
    public static class ImageFolderUpdater
    {
        public static async Task MoveImage(string imagePath)
        {
            var newPath = imagePath.Replace("not posted", "posted");
            System.IO.File.Move(imagePath, newPath);
        }
    }
}