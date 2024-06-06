namespace Sandbox.Solutions.Medium;

public class NextGreaterElement3
{
    public int NextGreaterElement(int n)
    {
        var target = n;
        // next permutation - two pointers
        var size = (int) Math.Log10(n) + 1;

        var permutationArray = new int[size];

        int index = permutationArray.Length - 1;
        while (n > 0)
        {
            permutationArray[index--] = n % 10;
            n /= 10;
        }

        var i = permutationArray.Length - 2;

        // find first decreasing element
        while (i >= 0 && permutationArray[i + 1] <= permutationArray[i])
            i--;

        // find element just larger than found element and swap
        if (i >= 0)
        {
            var j = permutationArray.Length - 1;
            while (permutationArray[j] <= permutationArray[i])
                j--;

            (permutationArray[i], permutationArray[j]) = (permutationArray[j], permutationArray[i]);
        }

        // reverse elements from found element until end
        Array.Reverse(permutationArray, i + 1, permutationArray.Length - i - 1);

        long result = 0;

        for (int j = 0, k = (int) Math.Pow(10, permutationArray.Length - 1); j < permutationArray.Length; j++, k /= 10)
        {
            result += permutationArray[j] * k;
        }

        if (result > int.MaxValue)
            return -1;

        if (result <= target)
            return -1;

        return (int) result;
    }
}