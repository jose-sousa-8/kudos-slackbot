namespace Slack.Common
{
    using System.Collections.Generic;

    using Slack.Common.Attachments;

    public sealed class AttachmentsPayload : ISlackResponseMessage
    {
        /// <summary>
        /// The usage of this field changes depending on whether you're using blocks or not. 
        /// If you are, this is used as a fallback string to display in notifications. 
        /// If you aren't, this is the main body text of the message. It can be formatted as plain text, or with mrkdwn. 
        /// This field is not enforced as required when using blocks, however it is highly recommended that you include it as the aforementioned fallback.
        /// </summary>
        public string Text { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }

        /// <summary>
        /// Determines whether the text field is rendered according to mrkdwn formatting or not. Defaults to true.
        /// </summary>
        public bool Mrkdwn { get; set; } = true;
    }
}
