namespace TextObfuscation
{
    enum TextPartType { WORD, NONWORD }

    class TextPart
    {
        public TextPart(string content, TextPartType type)
        {
            Contents = content;
            Type = type;
        }

        public string Contents { get; }
        public TextPartType Type { get; }
    }
}