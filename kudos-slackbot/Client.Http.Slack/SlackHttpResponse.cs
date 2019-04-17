namespace KudosSlackbot.Client.Http.Slack
{
    public class SlackHttpResponse<T> where T : class, new()
    {
        public bool Ok { get; set; }

        public bool Warning { get; set; }

        public bool Error { get; set; }

        public T Response { get; set; }
    }
}
