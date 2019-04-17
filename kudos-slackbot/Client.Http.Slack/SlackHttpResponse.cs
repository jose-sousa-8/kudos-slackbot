namespace KudosSlackbot.Client.Http.Slack
{
    public class BaseSlackHttpResponse
    {
        public bool Ok { get; set; }

        public bool Warning { get; set; }

        public string Error { get; set; }
    }
}
