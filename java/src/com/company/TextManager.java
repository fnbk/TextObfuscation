package com.company;

import org.w3c.dom.Text;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class TextManager {

    private TextManagerHelper hlp = new TextManagerHelper();
    private Random rnd = new Random();

    public String convert(String text) {
        String result = "";
        List<TextPart> pts = hlp.convert(text);

        for (int i = 0; i < pts.size(); i++) {
            if (pts.get(i).getType().equals(TextPartType.WORD)
                    && rnd.nextDouble() < 0.2) {
                if (i + 2 < pts.size()) {
                    TextPart t = pts.get(i);
                    pts.set(i, pts.get(i + 2));
                    pts.set(i + 2, t);
                }
            }
        }

        for (int i1 = 0; i1 < pts.size(); i1++) {
            if (rnd.nextDouble() < 0.2) {
                pts.add(i1, new TextPart(" ",
                        TextPartType.NONWORD));
                i1++;
                String[] wds = new String[] { "and", "so",
                        "however", "maybe" };
                int ind = rnd.nextInt(wds.length);
                pts.add(i1, new TextPart(wds[ind],
                        TextPartType.WORD));
                i1++;
                pts.add(i1, new TextPart(" ",
                        TextPartType.NONWORD));
            }
        }

        String result2 = "";

        for (TextPart prt : pts) {
            result2 += prt.getContents();
        }

        result = result2;
        result = result.replaceAll("[\\?!-\\.,:;'\\(\\)]", "");

        String result1 = "";

        for (int i2 = 0; i2 < result.split(" ").length - 1; i2++) {
            if (rnd.nextDouble() < 0.5) {
                char[] chrs = new char[] { '.', ',', '!' };
                int j = rnd.nextInt(chrs.length);
                result1 += result.split(" ")[i2] + chrs[j];
            } else {
                result1 += result.split(" ")[i2] + " ";
            }
        }
        result1 += result.split(" ")[result.split(" ").length - 1];
        result = result1;

        String result3 = "";
        char[] textArray = result.toCharArray();

        for (char ch : textArray) {
            if (rnd.nextDouble() < 0.3) {
                char nch;
                if (Character.isLowerCase(ch)) {
                    nch = Character.toUpperCase(ch);
                } else {
                    nch = Character.toLowerCase(ch);
                }

                result3 += nch;
            } else {
                result3 += ch;
            }
        }

        result = result3.replaceAll(" ", "");

        return result;
    }

}