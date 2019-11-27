namespace RedditPoster
{
    public static class Parameters
    {
        public static string Subredit { get; set; }
        public static int PostCount { get; set; }
        public static string FolderPath { get; set; }
        public static string PostTitle => $"The entire Bee Movie but with a 3 seconds timespan - PART {PostCount}";
        public static string NotPostedFolderPath => $"{FolderPath}\\not posted";
    }
}