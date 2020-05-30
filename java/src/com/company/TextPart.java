package com.company;

enum TextPartType { WORD, NONWORD };

public class TextPart {
    private String Contents;
    private TextPartType Type;

    public TextPart(String content, TextPartType type)
    {
        Contents = content;
        Type = type;
    }

    public String getContents() { return this.Contents; }
    public TextPartType getType() { return this.Type; }
}