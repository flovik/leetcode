namespace Sandbox.Solutions.Hard;

public class NumberOfMusicPlaylists
{
    private const int mod = 1_000_000_007;
    private long[][] _cache;

    public int NumMusicPlaylists(int n, int goal, int k)
    {
        // not all songs will be played
        if (n > goal)
            return 0;

        // number of ways to play goal songs out of n
        // k is a cooldown before choosing the same song again
        // gap of songs that needs to be satisfied to pick an old song, old_songs > k
        // old_songs cannot be > n

        _cache = new long[goal + 1][];

        for (var i = 0; i < goal + 1; i++)
        {
            _cache[i] = new long[n + 1];
            Array.Fill(_cache[i], -1);
        }

        var value = Backtrack(goal, 0);
        return (int)value % mod;

        long Backtrack(int goal, int uniqueSongs)
        {
            // base cases
            // 1. branch of length goals
            // 2. unique songs used = n
            // how many old songs we can choose from? unique - k

            if (_cache[goal][uniqueSongs] != -1)
                return _cache[goal][uniqueSongs];

            if (goal == 0)
            {
                if (uniqueSongs == n)
                    return 1;

                return 0;
            }

            var songsAvailableToReuse = Math.Clamp(uniqueSongs - k, 0, n);
            long value = 0;

            // reuse songs
            while (songsAvailableToReuse > 0)
            {
                long reused = Backtrack(goal - 1, uniqueSongs);
                value = (value + reused) % mod;
                songsAvailableToReuse--;
            }

            // new songs
            for (var i = 1; i <= n - uniqueSongs; i++)
            {
                if (uniqueSongs < n)
                {
                    long newSong = Backtrack(goal - 1, uniqueSongs + 1);
                    value = (value + newSong) % mod;
                }
            }

            return _cache[goal][uniqueSongs] = value;
        }
    }
}