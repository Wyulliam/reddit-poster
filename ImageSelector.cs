using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RedditPoster
{
    public static class ImageSelector
    {
        public static async Task<string> FirstImage()
        {
            var notPostedDirectoryPath = Parameters.NotPostedFolderPath;

            var notPostedDirectory = new DirectoryInfo(notPostedDirectoryPath);
            var files = notPostedDirectory.GetFiles().OrderBy(o => o.Name);

            return files.FirstOrDefault()?.FullName;
        }
    }
}
