namespace KudosSlackbot.Application.Queries
{
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class ListUserKudosQuery : IKudoRequest
    {
        public string UserId { get; set; }
    }
}
