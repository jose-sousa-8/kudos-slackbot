namespace KudosSlackbot.Application.Dto.Slack.SlashCommands
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Channel;

    public class SlashCommandResponseDto
    {
        public List<AttachmentDto> Attachments { get; set; }
    }
}
