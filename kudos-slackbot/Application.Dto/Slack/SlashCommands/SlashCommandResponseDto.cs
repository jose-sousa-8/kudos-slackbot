namespace KudosSlackbot.Application.Dto.Slack.SlashCommands
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Channel;
    using KudosSlackbot.Infrastructure.CrossCutting.CQS;

    public class SlashCommandResponseDto : ISlashCommandResponse
    {
        public IEnumerable<AttachmentDto> Attachments { get; set; }
    }
}
