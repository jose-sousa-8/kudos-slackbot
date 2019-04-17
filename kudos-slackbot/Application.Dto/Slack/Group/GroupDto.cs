namespace KudosSlackbot.Application.Dto.Slack.Group
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Common;

    public class GroupDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public string is_group { get; set; }

        public int created { get; set; }

        public string creator { get; set; }

        public bool is_archived { get; set; }

        public bool is_mpim { get; set; }

        public List<string> members { get; set; }

        public Topic topic { get; set; }

        public Purpose purpose { get; set; }

        public string last_read { get; set; }

        public string latest { get; set; }

        public int unread_count { get; set; }

        public int unread_count_display { get; set; }
    }
}
