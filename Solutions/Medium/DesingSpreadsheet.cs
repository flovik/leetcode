using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Solutions.Medium;

public class Spreadsheet
{
    private Dictionary<string, int> _map;
    private const int A = 65;

    public Spreadsheet(int rows)
    {
        _map = new Dictionary<string, int>(rows);
    }

    public void SetCell(string cell, int value)
    {
        _map.TryAdd(cell, 0);
        _map[cell] = value;
    }

    public void ResetCell(string cell)
    {
        _map[cell] = 0;
    }

    public int GetValue(string formula)
    {
        var split = formula[1..].Split('+');

        var val = 0;
        if (split[0][0] >= A)
        {
            val += _map.GetValueOrDefault(split[0], 0);
        }
        else
        {
            int.TryParse(split[0], out int res);
            val += res;
        }

        if (split[1][0] >= A)
        {
            val += _map.GetValueOrDefault(split[1], 0); ;
        }
        else
        {
            int.TryParse(split[1], out int res);
            val += res;
        }

        return val;
    }
}