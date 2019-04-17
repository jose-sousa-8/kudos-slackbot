using System.Net.Http;

namespace KudosSlackbot.Client.Http
{
    public abstract class HttpBaseClient
    {
        protected abstract string Endpoint { get; set; }

        protected abstract HttpClient HttpClient { get; set; }
    }
}
