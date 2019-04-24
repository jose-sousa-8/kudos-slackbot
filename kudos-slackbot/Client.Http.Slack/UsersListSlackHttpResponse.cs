namespace KudosSlackbot.Client.Http.Slack
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.User;

    public class UsersListSlackHttpResponse : BaseSlackHttpResponse
    {
        public IEnumerable<UserDto> Members { get; set; }
    }
}
