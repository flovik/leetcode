namespace Sandbox.Solutions.Medium;

public class FruitIntoBaskets
{
    public int TotalFruit(int[] fruits)
    {
        //1, 0, 1, 0, 0, 0, 4, 0, 4, 0, 2, 3

        int leftTree = -1, rightTree = -1;
        int counter1 = 0, counter2 = 0;
        int current1 = 0, current2 = 0;
        int max = 0;

        for (int i = 0; i < fruits.Length; i++)
        {
            if (counter1 == 0)
            {
                leftTree = fruits[i];
                counter1 = 1;
                current1++;
            }
            else if (fruits[i] == leftTree)
            {
                counter1++;
                current1++;
                current2 = 0;
            }
            else if (counter2 == 0)
            {
                rightTree = fruits[i];
                counter2 = 1;
                current1 = 0;
                current2++;
            }
            else if (fruits[i] == rightTree)
            {
                counter2++;
                current2++;
                current1 = 0;
            }
            else
            {
                if (leftTree != fruits[i - 1])
                {
                    leftTree = rightTree;
                    counter1 = current2;
                }
                else
                {
                    counter1 = current1;
                }


                rightTree = fruits[i];
                counter2 = 1;
                current2 = 1;
                current1 = 0;
            }

            if (counter1 + counter2 > max)
            {
                max = counter1 + counter2;
            }
        }

        return max;
    }
}