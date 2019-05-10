namespace KudosSlackbot.Application.Services
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public interface IKudoRequestFactory
    {
        IKudoRequest CreateKudoCommand(SlashCommandDto slashCommandDto);
    }
}
