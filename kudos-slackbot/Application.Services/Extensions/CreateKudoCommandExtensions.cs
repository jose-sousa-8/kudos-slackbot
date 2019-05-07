namespace KudosSlackbot.Application.Services.Extensions
{
    using KudosSlackbot.Application.Commands;

    public static class CreateKudoCommandExtensions
    {
        public static string GetUserId(this CreateKudoCommand createKudoCommand)
        {
            return createKudoCommand.GetUserInfo().TrimUserInfo().Split('|')[0];
        }

        public static string GetUsername(this CreateKudoCommand createKudoCommand)
        {
            return createKudoCommand.GetUserInfo().TrimUserInfo().Split('|')[1];
        }

        private static string GetUserInfo(this CreateKudoCommand createKudoCommand)
        {
            return createKudoCommand.Text.Split(' ')[1];
        }

        private static string TrimUserInfo(this string userInfo)
        {
            return userInfo.Trim(new char[] { '<', '>' });
        }
    }
}