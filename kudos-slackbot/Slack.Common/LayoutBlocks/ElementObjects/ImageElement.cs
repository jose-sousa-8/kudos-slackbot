namespace Slack.Common.LayoutBlocks.ElementObjects
{
    public class ImageElement : ElementObject
    {
        public override string Type => "image";

        public string Image_Url { get; set; }

        public string Alt_Text { get; set; }
    }
}
