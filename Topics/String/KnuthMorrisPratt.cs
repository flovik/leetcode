namespace Sandbox.Topics.String;

// O(m + n)
// searches for a substring in a string
public class KnuthMorrisPratt
{
    public void StringMatching(string input)
    {
        // string: abcdefgh
        // pattern: def

        // prefix - from left to right
        // a, ab, abc, abcd

        // suffix - from right to left
        // c, bc, abc, dabc

        // is there any prefix same as suffix?
        // we have abc

        // is is beginning part of the pattern anywhere in other part of the string?

        // keep a table of the pattern and indexes where were found
        // ababd
        // 00120
        // move indexes while iterating the string

        // it pre-computes a lookup table
        // it helps in avoiding check for characters matches at each index of string
        // if not match, then shift the pattern where is a possibility of match
    }
}