using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextObfuscation
{
    class TextManagerHelper
    {
        public IEnumerable<TextPart> Convert(string text)
        {
            var contents = "";
            var type = TextPartType.WORD;
            for (var i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (type == TextPartType.WORD)
                    {
                        contents += text[i];
                    }
                    else
                    {
                        if (contents != "") yield return new TextPart(contents, type);
                        contents = text[i].ToString();
                        type = TextPartType.WORD;
                    }
                }
                else
                {
                    if (type == TextPartType.NONWORD)
                    {
                        contents += text[i];
                    }
                    else
                    {
                        if (contents != "") yield return new TextPart(contents, type);
                        contents = text[i].ToString();
                        type = TextPartType.NONWORD;
                    }
                }
            }
            yield return new TextPart(contents, type);
        }
    }
}