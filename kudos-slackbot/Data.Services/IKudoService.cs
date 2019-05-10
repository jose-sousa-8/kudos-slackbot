namespace KudosSlackbot.Data.Services
{

    using KudosSlackbot.Domain.Model;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public interface IKudoService
    {
        ISlashCommandResponse CreateKudo(Kudo kudo);

        ISlashCommandResponse BuildHelpResponse();

        ISlashCommandResponse GetNKudosByUserId(Kudo kudo);

        ISlashCommandResponse GetAllUserKudos(string userId);

        ISlashCommandResponse ReplaceKudo(Kudo kudo);

        ISlashCommandResponse DeleteKudo(int kudoId);

        ISlashCommandResponse GetTopUsers(string numberOfUsers);
    }
}
