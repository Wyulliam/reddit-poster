using System.Threading;
using System.Threading.Tasks;

namespace RedditPoster
{
    static class Timer
    {
        public async static Task Start()
        {
            Thread.Sleep((1000 * 60) * 11);
        }
    }
}
