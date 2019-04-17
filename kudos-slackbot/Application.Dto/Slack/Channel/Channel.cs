namespace KudosSlackbot.Application.Dto.Slack.Channel
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Common;

    public class Channel
    {
        public string id { get; set; }

        public string name { get; set; }

        public bool is_channel { get; set; }

        public int created { get; set; }

        public string creator { get; set; }

        public bool is_archived { get; set; }

        public bool is_general { get; set; }

        public string name_normalized { get; set; }

        public bool is_shared { get; set; }

        public bool is_org_shared { get; set; }

        public bool is_member { get; set; }

        public bool is_private { get; set; }

        public bool is_mpim { get; set; }

        public string last_read { get; set; }

        public Latest latest { get; set; }

        public int unread_count { get; set; }

        public int unread_count_display { get; set; }

        public List<string> members { get; set; }

        public Topic topic { get; set; }

        public Purpose purpose { get; set; }

        public List<string> previous_names { get; set; }
    }
}
