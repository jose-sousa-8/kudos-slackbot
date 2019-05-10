namespace KudosSlackbot.Data.Services
{

    using KudosSlackbot.Domain.Model;

    using Slack.Common;

    public interface IKudoService
    {
        ISlackResponseMessage CreateKudo(Kudo kudo);

        ISlackResponseMessage BuildHelpResponse();

        ISlackResponseMessage GetNKudosByUserId(Kudo kudo);

        ISlackResponseMessage GetAllUserKudos(string userId);

        ISlackResponseMessage ReplaceKudo(Kudo kudo);

        ISlackResponseMessage DeleteKudo(int kudoId);

        ISlackResponseMessage GetTopUsers(string numberOfUsers);
    }
}
