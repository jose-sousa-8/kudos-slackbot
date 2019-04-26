namespace KudosSlackbot.Data.Services
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Domain.Model;

    public interface IKudoService
    {
        SlashCommandResponseDto CreateKudo(Kudo kudo);
    }
}
