package com.company;

import java.util.ArrayList;
import java.util.List;

class TextManagerHelper {

    public List<TextPart> convert(String text) {
        List<TextPart> parts = new ArrayList<TextPart>();
        String contents = "";
        TextPartType type = TextPartType.WORD;
        for (var i = 0; (i < text.length()); i++) {
            if (Character.isLetter(text.charAt(i))) {
                if ((type == TextPartType.WORD)) {
                    contents += text.charAt(i);
                }
                else {
                    if ((contents != "")) {
                        parts.add(new TextPart(contents, type));
                    }
                    contents = Character.toString(text.charAt(i));
                    type = TextPartType.WORD;
                }

            }
            else if ((type == TextPartType.NONWORD)) {
                contents += Character.toString(text.charAt(i));
            }
            else {
                if ((contents != "")) {
                    parts.add(new TextPart(contents, type));
                }
                contents = Character.toString(text.charAt(i));
                type = TextPartType.NONWORD;
            }

        }
        return parts;
    }
}