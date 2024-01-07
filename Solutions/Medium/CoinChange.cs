namespace Sandbox.Solutions.Medium;

public class CoinChange
{
    public int CoinChangee(int[] coins, int amount)
    {
        //base array, first value is 0
        //if has a MaxValue, cannot compute the amount with existing coins
        int[] dp = new int[amount + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;
        Array.Sort(coins);
        for (int i = 1; i <= amount; i++) //calculate the minimal amount for all the possible amounts
        {
            foreach (int coin in coins)
            {
                if (i - coin < 0) break; //if the current amount is bigger than current coin, skip from here because array is sorted
                if (dp[i - coin] != int.MaxValue)
                {
                    //consider every coin of coins
                    //you at i = 6
                    //iterating every coin, you start with 1
                    //take last biggest combination found with the current coin dp[5] + 1 (1 is for the coin we add now) = 2
                    //next coin is 2, to make a 6 from a current 2 coin, we need amount 4 that is already computed 
                    //dp[4] + 1 (remember, 1 is just the current coin we add right now) = 3, not the minimum
                    //dp[1] + 1 (coin 1 and current coin 5) = 2, already minimum
                    //it is working cause you are sure every position you take is already the minimum possible amount that could be computed
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
        }

        return dp[amount] == int.MaxValue ? -1 : dp[amount];
        return 0;
    }
}