namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfFlipsToMakeTheBinaryStringAlternating
{
    public int MinFlips(string s)
    {
        // store count of zeroes and ones at odd and even places
        // strings which start with 0 means 0 are at even position and 1 are at odd position ->
        // need to flip 0 to odd, and 1 to even
        // if 3 zeroes at even of total of 5 even positions, then 2 flips

        // if len of string is even, on every operation the oddcount is changed to even, and even is changed to odd
        // if len is off, on every operation the odd count and even count swaps, and the even count at starting position decreases
        // and odd count increases

        int oddZero = 0, evenZero = 0, oddOne = 0, evenOne = 0;

        for (var j = 0; j < s.Length; j++)
        {
            if (s[j] == '0')
            {
                if (j % 2 == 0) evenZero++;
                else oddZero++;
            }
            else
            {
                if (j % 2 == 0) evenOne++;
                else oddOne++;
            }
        }

        var evenCount = (s.Length + 1) / 2; // total even positions in s
        var oddCount = s.Length / 2; // total odd positions in s

        var min = Math.Min(evenCount - evenZero + oddCount - oddOne, evenCount - evenOne + oddCount - oddZero);

        if (s.Length % 2 == 0)
            return min;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                evenZero--;
                oddZero++;
            }
            else
            {
                evenOne--;
                oddOne++;
            }

            // switch odds and evens
            (oddZero, evenZero) = (evenZero, oddZero);
            (oddOne, evenOne) = (evenOne, oddOne);

            var even = evenCount - evenZero + oddCount - oddOne;
            var odd = evenCount - evenOne + oddCount - oddZero;

            var temp = Math.Min(even, odd);
            min = Math.Min(min, temp);
        }

        return min;
    }
}