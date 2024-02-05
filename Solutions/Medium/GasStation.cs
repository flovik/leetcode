namespace Sandbox.Solutions.Medium;

public class GasStation
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var sumGas = gas.Sum();
        var sumCost = cost.Sum();

        if (sumCost > sumGas)
            return -1;

        // if start at station a and stuck at b, then you can't get to b from any station between a and b
        for (var i = 0; i < gas.Length; i++)
            cost[i] = gas[i] - cost[i];

        var index = 0;
        var currentGas = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            currentGas += cost[i];

            if (currentGas >= 0)
                continue;

            currentGas = 0;
            index = (i + 1) % gas.Length;
        }

        return index;
    }
}