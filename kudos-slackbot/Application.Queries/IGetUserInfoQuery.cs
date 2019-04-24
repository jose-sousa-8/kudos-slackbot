namespace KudosSlackbot.Application.Queries
{
    using KudosSlackbot.Application.Dto.Slack.User;

    using MediatR;

    public interface IGetUserInfoQuery : IRequest<UserDto>
    {
    }
}
