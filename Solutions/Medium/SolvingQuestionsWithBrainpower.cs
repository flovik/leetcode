namespace Sandbox.Solutions.Medium;

public class SolvingQuestionsWithBrainpower
{
    public long MostPoints(int[][] questions)
    {
        var dp = new long[questions.Length];
        dp[^1] = questions[^1][0];

        for (var i = questions.Length - 2; i >= 0; i--)
        {
            var points = questions[i][0];
            var brainpower = questions[i][1];

            dp[i] += points;

            if (i + brainpower + 1 < questions.Length)
                dp[i] += dp[i + brainpower + 1];

            dp[i] = Math.Max(dp[i], dp[i + 1]);
        }

        return dp.Max();
    }
}