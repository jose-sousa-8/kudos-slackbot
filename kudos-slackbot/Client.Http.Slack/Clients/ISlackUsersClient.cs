namespace KudosSlackbot.Client.Http.Slack.Clients
{
    using System.Threading.Tasks;

    public interface ISlackUsersClient
    {
        Task<UserInfoSlackHttpResponse> GetUserInfo(string userId, bool includeLocal = false);
    }
}