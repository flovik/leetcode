using System.Text;

namespace Sandbox.Solutions.Hard;

public class StickersToSpellWord
{
    private readonly Dictionary<string, int> _cache = new();

    public int MinStickers(string[] stickers, string target)
    {
        var stickCount = new Dictionary<string, int[]>(stickers.Length);
        var defaultArr = new int[26];

        // count char occurrences for each stickers
        foreach (var sticker in stickers)
        {
            var arr = new int[26];
            PopulateArray(arr, sticker);
            stickCount.TryAdd(sticker, arr);
        }

        var result = Backtrack(target, "");
        return result == int.MaxValue ? -1 : result;

        int Backtrack(string word, string sticker)
        {
            // caching mechanism for faster values
            if (_cache.TryGetValue(word, out var val))
                return val;

            var words = sticker != string.Empty ? 1 : 0;

            var array = new int[26];
            var stickerCount = stickCount.GetValueOrDefault(sticker, defaultArr);
            Array.Copy(stickerCount, array, 26);

            var remainStr = new StringBuilder();

            // exhaust current sticker as much as possible
            foreach (var ch in word)
            {
                var index = ch - 'a';
                if (sticker.Contains(ch) && array[index] > 0)
                    array[index]--;
                else
                    remainStr.Append(ch);
            }

            // base case - empty string
            if (remainStr.Length <= 0)
                return words;

            var used = int.MaxValue;
            var st = remainStr.ToString();

            // look into all stickers
            foreach (var (s, count) in stickCount)
            {
                // if no letters present - skip it
                if (count[remainStr[0] - 'a'] <= 0)
                    continue;

                used = Math.Min(used, Backtrack(st, s));
            }

            // cache that branch
            _cache.TryAdd(st, used);
            words = used == int.MaxValue ? int.MaxValue : words + used;
            return words;
        }

        void PopulateArray(int[] arr, string str)
        {
            foreach (var ch in str)
            {
                arr[ch - 'a']++;
            }
        }
    }
}