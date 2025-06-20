﻿namespace Sandbox.Solutions.Medium;

public class IntegerToRoman
{
    public string IntToRoman(int num)
    {
        var result = string.Empty;
        var roman = new Dictionary<int, string>
        {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"}
        };

        var list = roman.Keys.Reverse().ToList();
        foreach (var number in list)
        {
            while (number <= num)
            {
                result += roman[number];
                num -= number;
            }
        }

        return result;
    }
}