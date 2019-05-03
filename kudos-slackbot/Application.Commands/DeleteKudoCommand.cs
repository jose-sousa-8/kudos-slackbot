namespace KudosSlackbot.Application.Commands
{

    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class DeleteKudoCommand : IKudoRequest
    {
        public string CommandText { get; set; }
    }
}
