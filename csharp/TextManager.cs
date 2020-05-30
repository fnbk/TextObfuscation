using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextObfuscation
{
    public class TextManager
    {
        private TextManagerHelper hlp = new TextManagerHelper();
        private Random rnd = new Random();

        public String Convert(String text)
        {
            string result = "";
            var pts = hlp.Convert(text).ToList();

            for (int i = 0; i < pts.Count; i++)
            {
                if (pts[i].Type == TextPartType.WORD
                    && rnd.NextDouble() < 0.2)
                {
                    if (i + 2 < pts.Count)
                    {
                        var t = pts[i];
                        pts[i] = pts[i + 2];
                        pts[i + 2] = t;
                    }
                }
            }

            for (int i1 = 0; i1 < pts.Count; i1++)
            {
                if (rnd.NextDouble() < 0.2)
                {
                    pts.Insert(i1, new TextPart(" ", TextPartType.NONWORD));
                    i1++;
                    String[] wds = { "and", "so", "however", "maybe" };
                    int ind = rnd.Next(wds.Length);
                    pts.Insert(i1, new TextPart(wds[ind], TextPartType.WORD));
                    i1++;
                    pts.Insert(i1, new TextPart(" ", TextPartType.NONWORD));
                }
            }

            String result2 = "";

            foreach (var prt in pts)
            {
                result2 += prt.Contents;
            }

            result = result2;
            result = Regex.Replace(result, "[\\?!-\\.,:;'\\(\\)]", "");

            var result1 = "";

            for (int i2 = 0; i2 < result.Split(' ').Length - 1; i2++)
            {
                if (rnd.NextDouble() < 0.5)
                {
                    char[] chrs = { '.', ',', '!' };
                    var j = rnd.Next(chrs.Length);
                    result1 += result.Split(' ')[i2] + chrs[j];
                }
                else
                {
                    result1 += result.Split(' ')[i2] + " ";
                }
            }
            result1 += result.Split(' ')[result.Split(' ').Length - 1];
            result = result1;

            String result3 = "";
            char[] textArray = result.ToCharArray();

            foreach (var ch in textArray)
            {
                if (rnd.NextDouble() < 0.3)
                {
                    char nch;
                    if (char.IsLower(ch))
                    {
                        nch = char.ToUpper(ch);
                    }
                    else
                    {
                        nch = char.ToLower(ch);
                    }

                    result3 += nch;
                }
                else
                {
                    result3 += ch;
                }
            }

            result = result3.Replace(" ", "");

            return result;
        }
    }
}

