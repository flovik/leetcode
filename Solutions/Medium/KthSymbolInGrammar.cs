namespace Sandbox.Solutions.Medium;

public class KthSymbolInGrammar
{
    public int KthGrammar(int n, int k)
    {
        if (n == 1)
            return 0;

        var prevK = (int) Math.Ceiling(k / 2.0);
        var prevNumber = KthGrammar(n - 1, prevK);

        if (prevNumber == 0)
            return k % 2 == 0 ? 1 : 0;
        
        return k % 2 == 0 ? 0 : 1;
    }
}