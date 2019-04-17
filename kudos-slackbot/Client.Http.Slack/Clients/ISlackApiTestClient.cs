namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System.Threading.Tasks;

    public interface ISlackApiTestClient
    {
        // Remove this later. This removes the necessity of importing this project to all dependencies.
        Task<object> TestApi();
    }
}
