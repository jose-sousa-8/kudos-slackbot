namespace KudosSlackbot.Application.Dto.Slack.Channel
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Common;

    public class AttachmentDto
    {
        public string fallback { get; set; }

        public string color { get; set; }

        public string pretext { get; set; }

        public string author_name { get; set; }

        public string author_link { get; set; }

        public string author_icon { get; set; }

        public string title { get; set; }

        public string title_link { get; set; }

        public string text { get; set; }

        public List<Field> fields { get; set; }

        public string image_url { get; set; }

        public string thumb_url { get; set; }

        public string footer { get; set; }

        public string footer_icon { get; set; }

        public int ts { get; set; }
    }
}
