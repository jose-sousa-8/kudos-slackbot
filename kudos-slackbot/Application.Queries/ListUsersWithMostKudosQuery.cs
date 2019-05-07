namespace KudosSlackbot.Application.Queries
{
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class ListTopUsersQuery : IKudoRequest
    {
        public string Text { get; set; }
    }
}
