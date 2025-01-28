namespace Sandbox.Solutions.Medium;

public class MinimumPenaltyForShop
{
    public int BestClosingTime(string customers)
    {
        // YYNY, customer comes at hour 0 1 and 3
        // for every hour shop is open and no customers, penalty++
        // for every hour shop is closed and customers come, penalty++
        // earliest hour to close for min penalty

        // prefix sum + some counting
        var n = customers.Length;
        var prefixY = new int[n + 1];
        var prefixN = new int[n + 1];

        for (int i = customers.Length - 1; i >= 0; i--)
        {
            prefixY[i] += prefixY[i + 1];
            prefixN[i] += prefixN[i + 1];

            if (customers[i] == 'Y')
                prefixY[i]++;
            else
                prefixN[i]++;
        }

        var result = int.MaxValue;
        var index = 0;

        for (int i = 0; i <= n; i++)
        {
            var y = prefixY[i];
            var nPenalty = prefixN[0] - prefixN[i];
            var penalty = y + nPenalty;

            if (penalty < result)
            {
                result = penalty;
                index = i;
            }
        }

        return index;
    }
}