namespace KudosSlackbot.Application.Services
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    using MediatR;

    public interface IKudoRequestFactory
    {
        IRequest<ISlackResponseMessage> CreateKudoCommand(SlashCommandDto slashCommandDto);
    }
}
