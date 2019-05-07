namespace KudosSlackbot.Application.Commands
{
    using System;

    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class ReplaceKudoCommand : IKudoRequest
    {
        public Guid KudoId { get; set; }

        public string CommandText { get; set; }
    }
}
