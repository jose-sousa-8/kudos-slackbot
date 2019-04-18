namespace KudosSlackbot.Data.Services
{
    using System;

    using KudosSlackbot.Data.Repository;
    using KudosSlackbot.Domain.Model;

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;

        public KudoService(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public Guid CreateKudo(Kudo kudo)
        {
            return kudoRepository.CreateKudo(kudo.Map<Dbo.Kudo>());
        }
    }
}
