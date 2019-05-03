namespace KudosSlackbot.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using KudosSlackbot.Data.Dbo;

    using Microsoft.EntityFrameworkCore;

    public class KudoRepository : IKudoRepository
    {
        private readonly KudoContext context;

        public KudoRepository(KudoContext context)
        {
            this.context = context;
        }

        public Guid Create(Kudo kudo)
        {
            return this.Create(kudo, default(CancellationToken));
        }

        public Guid Create(Kudo kudo, CancellationToken cancelationToken = default(CancellationToken))
        {
            kudo.CreateAt = DateTime.Now;

            var id = this.context.Kudos.Add(kudo).Entity.Id;

            this.context.SaveChanges();

            return id;
        }

        public async Task<Guid> CreateAsync(Kudo kudo)
        {
            return await this.CreateAsync(kudo, default(CancellationToken)).ConfigureAwait(false);
        }

        public async Task<Guid> CreateAsync(Kudo kudo, CancellationToken cancelationToken)
        {
            kudo.CreateAt = DateTime.Now;

            var entry = await this.context.Kudos.AddAsync(kudo).ConfigureAwait(false);

            this.context.SaveChanges();

            return entry.Entity.Id;
        }

        public Guid Update(Kudo kudo)
        {
            return this.Update(kudo, default(CancellationToken));
        }

        public Guid Update(Kudo kudo, CancellationToken cancelationToken = default(CancellationToken))
        {
            kudo.UpdatedAt = DateTime.Now;
            var id = this.context.Kudos.Update(kudo).Entity.Id;

            this.context.SaveChanges();

            return id;
        }

        public Kudo Get(Guid Id)
        {
            return this.context.Kudos.AsNoTracking().FirstOrDefault(k => k.Id == Id);
        }

        public async Task<Kudo> GetAsync(Guid Id)
        {
            return await this.context.Kudos.AsNoTracking().FirstOrDefaultAsync(k => k.Id == Id);
        }

        public IEnumerable<Kudo> GetAllByUserId(string userId)
        {
            return this.context.Kudos.AsNoTracking().Where(k => k.UserId == userId);
        }

        IEnumerable<Kudo> IKudoRepository.GetNByUserId(string userId, int n)
        {
            return this.context.Kudos.AsNoTracking().Where(k => k.UserId == userId).OrderByDescending(x => x.CreateAt).Take(n);
        }

        IEnumerable<Kudo> IKudoRepository.GetAllByUserId(string userId)
        {
            return this.context.Kudos.AsNoTracking().Where(k => k.UserId == userId).OrderByDescending(x => x.CreateAt);
        }
    }
}
