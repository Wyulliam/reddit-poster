namespace RedditPoster
{
    public class ImgurImageRequest
    {
        public string image { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
    }

    public class ImgurImageResponse
    {
        public ImgurImageResponseData Data { get; set; }
    }

    public class ImgurImageResponseData
    {
        public string Link { get; set; }
    }
}