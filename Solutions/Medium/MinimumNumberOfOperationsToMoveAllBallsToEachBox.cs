using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class MinimumNumberOfOperationsToMoveAllBallsToEachBox
{
    public int[] MinOperations(string boxes)
    {
        var answer = new int[boxes.Length];

        // prefix sum forward and backward
        var ballCount = boxes[0] == '1' ? 1 : 0;
        int prevMoves = 0;

        for (int i = 1; i < boxes.Length; i++)
        {
            int curMoves = ballCount + prevMoves;
            answer[i] += curMoves;
            prevMoves = curMoves;

            if (boxes[i] == '1')
                ballCount++;
        }

        ballCount = boxes[^1] == '1' ? 1 : 0;
        prevMoves = 0;
        for (int i = boxes.Length - 2; i >= 0; i--)
        {
            int curMoves = ballCount + prevMoves;
            answer[i] += curMoves;
            prevMoves = curMoves;

            if (boxes[i] == '1')
                ballCount++;
        }

        return answer;
    }
}