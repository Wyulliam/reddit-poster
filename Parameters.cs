﻿namespace RedditPoster
{
    public static class Parameters
    {
        public static string Subredit { get; set; }
        public static int PostCount { get; set; }
        public static string FolderPath { get; set; }
        public static string PostTitle => $"The entire Shrek movie but with a 3 seconds timespan - PART {PostCount}";
    }
}