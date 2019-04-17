namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System.Threading.Tasks;

    public interface ISlackTestClient
    {
        Task<bool> TestApi();
    }
}
