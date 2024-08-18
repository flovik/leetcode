using System.Text;

namespace Sandbox.Solutions.Hard;

public class TextJustification
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        // each line has exactly maxWidth characters and is fully (left and right) justified
        // greedy approach, pack as many words as you can
        // extra spaces should be distributed as evenly as possible, if not evenly, assign on the left more spaces than right
        // last line should be left-justified, no extra space is inserted between words
        var result = new List<string>(words.Length);
        var currentLine = new List<string>(words.Length);
        var currentLen = 0;
        var emptySpaces = 0;
        var sb = new StringBuilder(words.Length);

        foreach (var word in words)
        {
            // + 1 because we might should add at least one space between words
            if (currentLen + emptySpaces + word.Length + 1 <= maxWidth)
            {
                currentLine.Add(word);

                // add empty spaces between words
                if (currentLen != 0)
                    emptySpaces++;

                currentLen += word.Length;
            }
            else if (currentLine.Count == 0 && word.Length == maxWidth)
            {
                currentLine.Add(word);
                currentLen += word.Length;
            }
            else
            {
                var emptySpacesLen = maxWidth - currentLen;

                sb.Append(currentLine[0]);

                var len = currentLine.Count - 1;

                for (int i = 1; i < currentLine.Count; i++)
                {
                    // append empty spaces
                    var addedEmptySpaces = (int) Math.Ceiling((double) emptySpacesLen / len);
                    len--;
                    emptySpacesLen -= addedEmptySpaces;

                    sb.Append(new string(' ', addedEmptySpaces));

                    // append word
                    sb.Append(currentLine[i]);
                }

                if (len == 0)
                    sb.Append(new string(' ', emptySpacesLen));

                result.Add(sb.ToString());

                emptySpaces = 0;
                currentLine.Clear();
                sb.Clear();

                currentLen = word.Length;
                currentLine.Add(word);
            }
        }

        // last line should be left justified
        sb.Append(string.Join(" ", currentLine));
        sb.Append(new string(' ', maxWidth - sb.Length));
        result.Add(sb.ToString());

        return result;
    }
}