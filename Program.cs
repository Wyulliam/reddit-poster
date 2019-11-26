using System.Threading.Tasks;

namespace RedditPoster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                var token = await LoginMannager.Login();
                await PostSubmitter.Submit(token);
                await Timer.Start();
            }
        }
    }
}
