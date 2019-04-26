namespace KudosSlackbot.Data.Services
{
    using KudosSlackbot.Application.Dto.Slack.SlashCommands;
    using KudosSlackbot.Data.Repository;
    using KudosSlackbot.Domain.Model;

    public class KudoService : IKudoService
    {
        private readonly IKudoRepository kudoRepository;

        public KudoService(IKudoRepository kudoRepository)
        {
            this.kudoRepository = kudoRepository;
        }

        public SlashCommandResponseDto CreateKudo(Kudo kudo)
        {
            kudoRepository.CreateKudo(kudo.Map<Dbo.Kudo>());

            return new SlashCommandResponseDto
            {
                Attachments = new System.Collections.Generic.List<Application.Dto.Slack.Channel.AttachmentDto>
                {
                    new Application.Dto.Slack.Channel.AttachmentDto{
                        text = $"Kudaste um amigo! És um guerreiro de Deus! :jesus:"
                    }
                }
            };
        }
    }
}
