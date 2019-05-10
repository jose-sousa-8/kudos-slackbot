using System;

namespace KudosSlackbot.Data.Dbo
{
    public class Kudo
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ByUserId { get; set; }

        public string ByUsername { get; set; }

        public string ChannelId { get; set; }

        public string ChannelName { get; set; }

        public string Text { get; set; }

        public string CommandText { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
