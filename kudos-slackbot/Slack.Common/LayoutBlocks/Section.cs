namespace Slack.Common.LayoutBlocks
{

    using Slack.Common.LayoutBlocks.CompositionObjects;

    public class Section : LayoutBlock
    {
        /// <summary>
        /// The type of block. For a section block, type will always be "section".
        /// </summary>
        public override string Type => "section";

        /// <summary>
        /// The text for the block, in the form of a text object. Maximum length for the text in this field is 3000 characters.
        /// </summary>
        public TextObject Text { get; set; }

        /// <summary>
        /// A string acting as a unique identifier for a block. 
        /// You can use this BlockId when you receive an interaction payload to identify the source of the action. 
        /// If not specified, one will be generated. 
        /// Maximum length for this field is 255 characters. 
        /// BlockId should be unique for each message and each iteration of a message. If a message is updated, use a new block_id.
        /// </summary>
        //public string Block_Id { get; set; }

        /// <summary>
        /// An array of text objects. 
        /// Any text objects included with fields will be rendered in a compact format that allows for 2 columns of side-by-side text. 
        /// Maximum number of items is 10. Maximum length for the text in each item is 2000 characters.
        /// </summary>
        //public IEnumerable<TextObject> Fields { get; set; }

        /// <summary>
        /// The text for the block, in the form of a text object. Maximum length for the text in this field is 3000 characters.
        /// </summary>
       // public ElementObject Acessory { get; set; }
    }
}
