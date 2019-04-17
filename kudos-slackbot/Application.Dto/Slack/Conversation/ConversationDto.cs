namespace KudosSlackbot.Application.Dto.Slack.Conversation
{
    using System.Collections.Generic;

    using KudosSlackbot.Application.Dto.Slack.Common;

    public class ConversationDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public bool is_channel { get; set; }

        public bool is_group { get; set; }

        public bool is_im { get; set; }

        public int created { get; set; }

        public string creator { get; set; }

        public bool is_archived { get; set; }

        public bool is_general { get; set; }

        public int unlinked { get; set; }

        public string name_normalized { get; set; }

        public bool is_read_only { get; set; }

        public bool is_shared { get; set; }

        public bool is_ext_shared { get; set; }

        public bool is_org_shared { get; set; }

        public List<object> pending_shared { get; set; }

        public bool is_pending_ext_shared { get; set; }

        public bool is_member { get; set; }

        public bool is_private { get; set; }

        public bool is_mpim { get; set; }

        public string last_read { get; set; }

        public Topic topic { get; set; }

        public Purpose purpose { get; set; }

        public List<string> previous_names { get; set; }

        public int num_members { get; set; }

        public string locale { get; set; }
    }
}
