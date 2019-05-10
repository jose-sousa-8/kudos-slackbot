namespace KudosSlackbot.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Data.Dbo;

    public interface IKudoRepository
    {
        int Create(Kudo kudo);

        int Create(Kudo kudo, CancellationToken cancelationToken);

        Task<int> CreateAsync(Kudo kudo);

        Task<int> CreateAsync(Kudo kudo, CancellationToken cancelationToken);

        int Update(Kudo kudo);

        int Update(Kudo kudo, CancellationToken cancelationToken);

        Kudo Get(int Id);

        Task<Kudo> GetAsync(int Id);

        IEnumerable<Kudo> GetNByUserId(string userId, int n);

        IEnumerable<Kudo> GetAllByUserId(string userId);

        void Delete(int kudoId);

        void UpdateText(Kudo kudo);


        // TODO Shit solution with the nullable int but will work for now
        IEnumerable<string> GetTopUsers(int? n = null);
    }
}
