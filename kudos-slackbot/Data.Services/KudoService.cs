namespace KudosSlackbot.Data.Services
{
    using System;
    using System.Linq;

    using KudosSlackbot.Data.Repository;
    using KudosSlackbot.Data.Services.Extensions;

    using Slack.Common;

    using Kudo = Domain.Model.Kudo;

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;

        public KudoService(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public ISlackResponseMessage CreateKudo(Kudo kudo)
        {
            kudo.Text = kudo.GetKudoMessage(2);

            kudoRepository.Create(kudo.Map<Dbo.Kudo>());


            return SlackResponseHelper.BuildKudoCreatedResponse(kudo);
        }

        public ISlackResponseMessage GetNKudosByUserId(Kudo kudo)
        {
            var numberOfKudos = kudo.CommandText.Split(' ')[1];

            if (numberOfKudos == "*")
            {
                return this.GetAllUserKudos(kudo.UserId);
            }

            var kudos = this.kudoRepository.GetNByUserId(kudo.UserId, Convert.ToInt32(numberOfKudos)).Select(x => x.Map<Kudo>());

            return SlackResponseHelper.BuildSlashResponseFromKudoList(kudos);
        }

        public ISlackResponseMessage GetAllUserKudos(string userId)
        {
            var kudos = this.kudoRepository.GetAllByUserId(userId).Select(x => x.Map<Kudo>());

            return SlackResponseHelper.BuildSlashResponseFromKudoList(kudos);
        }

        public ISlackResponseMessage DeleteKudo(int kudoId)
        {
            this.kudoRepository.Delete(kudoId);

            return SlackResponseHelper.BuildKudoDeletedResponse();
        }

        public ISlackResponseMessage ReplaceKudo(Kudo kudo)
        {
            kudo.Text = kudo.GetKudoMessage(2);

            this.kudoRepository.UpdateText(kudo.Map<Dbo.Kudo>());

            return SlackResponseHelper.BuildKudoReplacedResponse(kudo);
        }

        public ISlackResponseMessage BuildHelpResponse() => SlackResponseHelper.BuildHelpResponse();

        public ISlackResponseMessage GetTopUsers(string numberOfUsers)
        {
            return SlackResponseHelper.BuildDummyResponse();
        }
    }
}