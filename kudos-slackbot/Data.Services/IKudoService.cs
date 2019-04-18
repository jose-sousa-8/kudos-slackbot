namespace KudosSlackbot.Data.Services
{
    using System;

    using KudosSlackbot.Domain.Model;

    public interface IKudoService
    {
        Guid CreateKudo(Kudo kudo);
    }
}
