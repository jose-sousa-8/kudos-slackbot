namespace KudosSlackbot.Application.Services.Extensions
{
    using KudosSlackbot.Application.Queries;

    // TODO consolidate this in a strategy
    public static class ListUserKudosQueryExtensions
    {
        public static string GetUserId(this ListUserKudosQuery listUserKudosQuery)
        {
            return listUserKudosQuery.GetUserInfo().TrimUserInfo().Split('|')[0];
        }

        private static string GetUserInfo(this ListUserKudosQuery listUserKudosQuery)
        {
            return listUserKudosQuery.Text.Split(' ')[1];
        }

        private static string TrimUserInfo(this string userInfo)
        {
            return userInfo.Trim(new char[] { '<', '>' });
        }
    }
}