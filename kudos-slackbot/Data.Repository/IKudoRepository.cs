namespace KudosSlackbot.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Data.Dbo;

    public interface IKudoRepository
    {
        Guid Create(Kudo kudo);

        Guid Create(Kudo kudo, CancellationToken cancelationToken);

        Task<Guid> CreateAsync(Kudo kudo);

        Task<Guid> CreateAsync(Kudo kudo, CancellationToken cancelationToken);

        Guid Update(Kudo kudo);

        Guid Update(Kudo kudo, CancellationToken cancelationToken);

        Kudo Get(Guid Id);

        Task<Kudo> GetAsync(Guid Id);

        IEnumerable<Kudo> GetNByUserId(string userId, int n);

        IEnumerable<Kudo> GetAllByUserId(string userId);

        void Delete(Guid kudoId);

        void UpdateText(Kudo kudo);
    }
}
