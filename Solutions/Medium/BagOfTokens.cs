namespace Sandbox.Solutions.Medium;

public class BagOfTokens
{
    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);
        int left = 0, right = tokens.Length - 1, score = 0, result = 0;

        // if you can afford to play token-left, play it, if not play token right
        while (left <= right)
        {
            if (power >= tokens[left])
            {
                power -= tokens[left];
                score++;
                left++;
            }
            else if (score > 0)
            {
                power += tokens[right];
                score--;
                right--;
            }
            else
                break;

            result = Math.Max(result, score);
        }

        return result;
    }
}