using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Hard;

public class MountainArray
{
    public int Get(int index)
    { return index; }

    public int Length()
    { return 0; }
}

public class FindInMountainArray
{
    public int FindInMountainArraySol(int target, MountainArray mountainArr)
    {
        // find peak of the array, binary search left part to find target
        // if absent, bunary search right part to find target
        // if absent also, return -1

        var len = mountainArr.Length();
        int left = 0, right = len - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            int midVal = mountainArr.Get(mid), nextToMid = mountainArr.Get(mid + 1);

            if (midVal < nextToMid)
                left = mid + 1;
            else
                right = mid;
        }

        var peak = left;
        left = 0; right = peak;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            int midVal = mountainArr.Get(mid);

            if (midVal == target)
                return mid;

            if (midVal < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        left = peak; right = len - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            int midVal = mountainArr.Get(mid);

            if (midVal == target)
                return mid;

            if (midVal > target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}