namespace KudosSlackbot.Application.Queries
{
    public class GetUserInfoQuery : IGetUserInfoQuery
    {
        public string UserId { get; set; }

        public bool IncludeLocal { get; set; }
    }
}
