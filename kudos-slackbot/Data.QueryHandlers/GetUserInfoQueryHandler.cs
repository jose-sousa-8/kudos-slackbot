namespace KudosSlackbot.Data.QueryHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Application.Queries;

    using KudosSlackbot.Application.Dto.Slack.User;
    using KudosSlackbot.Data.Services;

    using MediatR;

    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserDto>
    {
        private readonly ISlackUsersService slackUsersService;

        public GetUserInfoQueryHandler(ISlackUsersService slackUsersService)
        {
            this.slackUsersService = slackUsersService;
        }

        public async Task<UserDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await slackUsersService.GetUserInfo(request.UserId, request.IncludeLocal);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
