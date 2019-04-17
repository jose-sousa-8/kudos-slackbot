namespace KudosSlackbot.Application.Dto.Slack.Common
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Channel;

    public class Latest
    {
        public string text { get; set; }

        public string username { get; set; }

        public string bot_id { get; set; }

        public List<Attachment> attachments { get; set; }

        public string type { get; set; }

        public string subtype { get; set; }

        public string ts { get; set; }
    }
}
