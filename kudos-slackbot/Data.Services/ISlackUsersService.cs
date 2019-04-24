namespace KudosSlackbot.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KudosSlackbot.Application.Dto.Slack.User;
    public interface ISlackUsersService
    {
        Task<UserDto> GetUserInfo(string userId, bool includeLocal = false);

        Task<IEnumerable<UserDto>> GetUsersList();
    }
}
