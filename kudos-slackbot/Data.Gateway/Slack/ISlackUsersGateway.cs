namespace KudosSlackbot.Data.Gateway.Slack
{
    using KudosSlackbot.Application.Dto.Slack.User;

    public interface ISlackUsersGateway
    {
        UserDto GetUserInfo(string userId, bool includeLocal = false);
    }
}
