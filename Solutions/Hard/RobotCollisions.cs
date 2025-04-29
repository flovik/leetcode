namespace Sandbox.Solutions.Hard;

public class RobotCollisions
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var robots = new (int, int, char)[positions.Length];

        for (var i = 0; i < positions.Length; i++)
        {
            robots[i] = (positions[i], healths[i], directions[i]);
        }

        Array.Sort(robots, (a, b) => a.Item1.CompareTo(b.Item1));

        var st = new Stack<(int, int, char)>(robots.Length);

        foreach (var rb in robots)
        {
            var robot = rb;

            if (robot.Item3 == 'R')
                st.Push(robot);
            else
            {
                while (st.Count > 0 && st.Peek().Item3 == 'R')
                {
                    var robot2 = st.Pop();

                    if (robot2.Item2 == robot.Item2)
                    {
                        robot.Item2 = 0;
                        break;
                    }

                    if (robot2.Item2 > robot.Item2)
                    {
                        robot2.Item2--;
                        st.Push(robot2);
                        robot.Item2 = 0;
                        break;
                    }

                    if (robot.Item2 > robot2.Item2)
                        robot.Item2--;
                }

                if (robot.Item2 > 0)
                    st.Push(robot);
            }
        }

        var dict = st.ToDictionary(e => e.Item1, e => e);
        var arr = new List<int>(dict.Count);

        foreach (var t in positions)
        {
            if (dict.TryGetValue(t, out var val))
                arr.Add(val.Item2);
        }

        return arr;
    }
}