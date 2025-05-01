using System;
using System.Text;

namespace Sandbox.Solutions.Hard;

public class NumberOfAtoms
{
    private SortedDictionary<string, int> _dict;

    public string CountOfAtoms(string formula)
    {
        // frequency of elements
        _dict = new SortedDictionary<string, int>();

        ParseFormula(formula, 1);

        var sb = new StringBuilder();

        foreach (var (element, count) in _dict)
        {
            sb.Append(element);

            if (count > 1)
                sb.Append(count);
        }

        return sb.ToString();
    }

    private void ParseFormula(string formula, int multiplier)
    {
        for (int i = 0; i < formula.Length; i++)
        {
            // start of formula
            if (char.IsUpper(formula[i]))
            {
                // end of string
                // next is another letter, then cur is finalized formula with one
                if (i == formula.Length - 1 || char.IsUpper(formula[i + 1]) || formula[i + 1] == '(')
                {
                    _dict.TryAdd(formula[i].ToString(), 0);
                    _dict[formula[i].ToString()] += 1 * multiplier;
                }

                // is lower
                else if (char.IsLower(formula[i + 1]))
                {
                    var j = i + 1;

                    while (j < formula.Length - 1 && char.IsLower(formula[j + 1]))
                        j++;

                    if (j == formula.Length - 1 || !char.IsDigit(formula[j + 1]))
                    {
                        _dict.TryAdd(formula[i..(j + 1)], 0);
                        _dict[formula[i..(j + 1)]] += 1 * multiplier;
                    }
                    else
                    {
                        var digit = ParseNumber(formula, j + 1);

                        _dict.TryAdd(formula[i..(j + 1)], 0);
                        _dict[formula[i..(j + 1)]] += digit * multiplier;
                    }
                }

                // next is digit, finalized formula with digit
                else if (char.IsDigit(formula[i + 1]))
                {
                    var digit = ParseNumber(formula, i + 1);

                    _dict.TryAdd(formula[i..(i + 1)], 0);
                    _dict[formula[i..(i + 1)]] += digit * multiplier;
                }
            }

            if (formula[i] == '(')
            {
                var index = FindEnclosingOfFormula(formula[i..]);
                var digit = ParseNumber(formula, i + index + 1);

                ParseFormula(formula[(i + 1)..(i + index)], multiplier * digit);
                i += index;
            }
        }
    }

    private int FindEnclosingOfFormula(string formula)
    {
        var st = new Stack<char>();

        for (var i = 0; i < formula.Length; i++)
        {
            if (formula[i] == '(')
                st.Push('(');

            if (formula[i] == ')')
                st.Pop();

            if (st.Count == 0)
                return i;
        }

        return -1;
    }

    private int ParseNumber(string formula, int start)
    {
        var digit = 1;
        var j = start;

        if (start - 1 == formula.Length - 1 || !char.IsDigit(formula[j])) return digit;

        while (j < formula.Length && char.IsDigit(formula[j]))
            j++;

        digit = int.Parse(formula[start..j]);
        return digit;
    }
}