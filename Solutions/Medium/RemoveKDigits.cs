using System.Text;

namespace Sandbox.Solutions.Medium;

public class RemoveKDigits
{


    public string RemoveKdigits(string num, int k)
    {
        int total = num.Length - k;
        StringBuilder sb = new StringBuilder();
        //go from left until you find the highest local value, if next value is lower than current max ->
        //remove current max
        //if got to end, remove last which is highest

        //in case we have zeros in our way, just remove them

        //in order to not raise the complexity of the solution to O(k * n) to not iterate many times the string
        //save in stack the values and if find local highest, drop it (sb is stack)
        
        foreach (var value in num)
        {
            while (sb.Length > 0 && sb[^1] > value && k > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                k--;
            }
            
            sb.Append(value);
        }

        sb.Remove(total, sb.Length - total);

        //remove any remaining leading zeros
        while (sb.Length > 1 && sb[0].Equals('0'))
        {
            sb.Remove(0, 1);
        }

        //if no values were added, return 0
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}