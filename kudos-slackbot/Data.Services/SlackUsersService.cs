
namespace KudosSlackbot.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Dto.Slack.User;
    using KudosSlackbot.Data.Gateway.Slack;

    public class SlackUsersService : ISlackUsersService
    {
        private readonly ISlackUsersGateway slackUsersGateway;

        public SlackUsersService(ISlackUsersGateway slackUsersGateway)
        {
            this.slackUsersGateway = slackUsersGateway;
        }

        public async Task<UserDto> GetUserInfo(string userId, bool includeLocal = false)
        {
            return await this.slackUsersGateway.GetUserInfo(userId, includeLocal);
        }

        public async Task<IEnumerable<UserDto>> GetUsersList()
        {
            return await this.slackUsersGateway.GetUsersList();
        }
    }
}
