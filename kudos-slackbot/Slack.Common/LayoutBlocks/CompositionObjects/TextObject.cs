namespace Slack.Common.LayoutBlocks.CompositionObjects
{
    using System.ComponentModel;

    public class TextObject
    {
        /// <summary>
        /// The formatting to use for this text object. Can be one of plain_textor mrkdwn.
        /// </summary>
        public TextObjectType TypeEnum { get; set; }

        /// <summary>
        /// The formatting to use for this text object. Can be one of plain_textor mrkdwn.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The text for the block. This field accepts any of the standard text formatting markup when type is mrkdwn.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Indicates whether emojis in a text field should be escaped into the colon emoji format. This field is only usable when type is plain_text.
        /// </summary>
        public bool Emoji { get; set; }

        /// <summary>
        /// When set to false (as is default) URLs will be auto-converted into links, conversation names will be link-ified, 
        /// and certain mentions will be automatically parsed. 
        /// Using a value of true will skip any preprocessing of this nature, although you can still include manual parsing strings. 
        /// This field is only usable when type is mrkdwn.
        /// </summary>
        public bool Verbatim { get; set; }
    }

    public enum TextObjectType
    {
        [Description("plain_text")]
        PlainText,
        [Description("mrkdwn")]
        Markdown
    }
}
