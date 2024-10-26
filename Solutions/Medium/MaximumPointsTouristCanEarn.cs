namespace Sandbox.Solutions.Medium;

public class MaximumPointsTouristCanEarn
{
    public int MaxScore(int n, int k, int[][] stayScore, int[][] travelScore)
    {
        // choices - DP!
        var dp = new int[k + 1][];

        for (var i = 0; i < k + 1; i++)
        {
            dp[i] = new int[n];
        }

        // for each day, for each city, for each it's destination, calculate their max values
        for (var day = 1; day <= k; day++)
        {
            var today = dp[day];
            var yesterday = dp[day - 1];
            for (var city = 0; city < n; city++)
            {
                var stayIndex = day - 1;
                var stay = stayScore[stayIndex][city];

                // stay in the same city
                today[city] = Math.Max(today[city], yesterday[city] + stay);

                for (var destination = 0; destination < n; destination++)
                {
                    if (destination == city)
                        continue;

                    // travel to another city
                    var travel = travelScore[city][destination];

                    // we update the destination city!
                    today[destination] = Math.Max(today[destination], yesterday[city] + travel);
                }
            }
        }

        var max = 0;
        for (var i = 0; i < n; i++)
        {
            max = Math.Max(max, dp[k][i]);
        }

        return max;
    }
}