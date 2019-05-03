namespace KudosSlackbot.Application.Queries
{
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class ListKudosQuery : IKudoRequest
    {
        public string UserId { get; set; }

        public string Text { get; set; }
    }
}
