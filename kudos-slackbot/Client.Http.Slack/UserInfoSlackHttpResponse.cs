namespace KudosSlackbot.Client.Http.Slack
{
    using KudosSlackbot.Application.Dto.Slack.User;

    public class UserInfoSlackHttpResponse : BaseSlackHttpResponse
    {
        public UserDto User { get; set; }
    }
}
