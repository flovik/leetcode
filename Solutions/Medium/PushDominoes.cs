namespace Sandbox.Solutions.Medium;

public class PushDominoes
{
    public string PushDominoesSol(string dominoes)
    {
        var arr = dominoes.ToCharArray();
        var count = new int[2][];

        for (int i = 0; i < 2; i++)
        {
            count[i] = new int[dominoes.Length];
            Array.Fill(count[i], int.MaxValue);
        }

        // count lefts
        for (int i = 0; i < dominoes.Length; i++)
        {
            if (arr[i] != 'L')
                continue;

            var num = 1;
            var left = i - 1;
            while (left >= 0 && arr[left] == '.')
            {
                count[0][left] = num;
                num++;
                left--;
            }
        }

        // count rights
        for (int i = 0; i < dominoes.Length; i++)
        {
            if (arr[i] != 'R')
                continue;

            var num = 1;
            var right = i + 1;
            while (right < dominoes.Length && arr[right] == '.')
            {
                count[1][right] = num;
                num++;
                right++;
            }
        }

        for (int i = 0; i < dominoes.Length; i++)
        {
            if (count[0][i] != int.MaxValue || count[1][i] != int.MaxValue)
            {
                if (count[0][i] < count[1][i])
                    arr[i] = 'L';
                else if (count[0][i] > count[1][i])
                    arr[i] = 'R';
            }
        }

        return new string(arr);
    }
}