namespace KudosSlackbot.Data.Gateway.Slack
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Dto.Slack.User;
    using KudosSlackbot.Client.Http.Slack.Clients;

    public class SlackUsersGateway : ISlackUsersGateway
    {
        private readonly ISlackUsersClient slackUsersClient;

        public SlackUsersGateway(ISlackUsersClient slackUsersClient)
        {
            this.slackUsersClient = slackUsersClient;
        }

        public async Task<UserDto> GetUserInfo(string userId, bool includeLocal = false)
        {
            var userInfo = await slackUsersClient.GetUserInfo(userId, includeLocal);

            return userInfo.User;
        }

        public async Task<IEnumerable<UserDto>> GetUsersList()
        {
            var userList = await slackUsersClient.GetUserList();

            return userList.Members;
        }
    }
}
