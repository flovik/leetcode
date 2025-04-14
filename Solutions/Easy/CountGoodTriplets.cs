namespace Sandbox.Solutions.Easy;

public class CountGoodTriplets
{
    public int CountGoodTripletsSol(int[] arr, int a, int b, int c)
    {
        var answer = 0;

        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = i + 1; j < arr.Length; j++)
            {
                for (var k = j + 1; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[i] - arr[k]) <= c)
                        answer++;
                }
            }
        }

        return answer;
    }
}