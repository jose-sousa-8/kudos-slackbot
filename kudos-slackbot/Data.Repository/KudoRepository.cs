namespace KudosSlackbot.Data.Repository
{
    using System;
    using System.Threading;

    using KudosSlackbot.Data.Dbo;

    public class KudoRepository : IKudoRepository
    {
        private readonly KudoContext context;

        public KudoRepository(KudoContext context)
        {
            this.context = context;
        }

        public Guid CreateKudo(Kudo kudo)
        {
            return this.CreateKudo(kudo, default(CancellationToken));
        }

        public Guid CreateKudo(Kudo kudo, CancellationToken cancelationToken = default(CancellationToken))
        {
            kudo.CreateAt = DateTime.Now;

            var id = this.context.Kudos.Add(kudo).Entity.Id;

            this.context.SaveChanges();

            return id;
        }

        public Guid UpdateKudo(Kudo kudo)
        {
            return this.UpdateKudo(kudo, default(CancellationToken));
        }

        public Guid UpdateKudo(Kudo kudo, CancellationToken cancelationToken = default(CancellationToken))
        {
            kudo.UpdatedAt = DateTime.Now;
            var id = this.context.Kudos.Update(kudo).Entity.Id;

            this.context.SaveChanges();

            return id;
        }
    }
}
