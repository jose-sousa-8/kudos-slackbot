namespace KudosSlackbot.Data.Repository
{
    using System;
    using System.Threading;

    using KudosSlackbot.Data.Dbo;

    public interface IKudoRepository
    {
        Guid CreateKudo(Kudo kudo);

        Guid CreateKudo(Kudo kudo, CancellationToken cancelationToken);
    }
}
