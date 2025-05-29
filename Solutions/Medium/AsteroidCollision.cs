namespace Sandbox.Solutions.Medium;

public class AsteroidCollision
{
    public int[] AsteroidCollisionSol(int[] asteroids)
    {
        var st = new Stack<int>(asteroids.Length);

        foreach (var asteroid in asteroids)
        {
            if (st.Count == 0 || asteroid > 0) st.Push(asteroid);
            else
            {
                var add = true;

                while (st.TryPeek(out var ast) && ast > 0)
                {
                    if (ast == -asteroid)
                        st.Pop();

                    if (ast >= -asteroid)
                    {
                        add = false;
                        break;
                    }

                    st.Pop();
                }

                if (add)
                    st.Push(asteroid);
            }
        }

        return st.Reverse().ToArray();
    }
}