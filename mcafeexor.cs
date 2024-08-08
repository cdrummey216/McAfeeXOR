using System;

public class Program
{
    // 2nd and 4th iterations see value swapped between A <--> C
	// 01110100 01110010 01110101 01110100 01101000 00100000 01101001 01110011 00100000 01101001 01101101 01101101 01110101 01110100 01100001 01100010 01101100 01100101
    public static string xoring(string a, string b, int n){
	string ans = "";

        for (int i = 0; i < n; i++)
        {
            if (a[i] == b[i]) {
                ans += "0";
            }
            else {
                ans += "1";
            }
        }
        return ans;
    }
    
    public static void XORize(ref string a, ref string b, ref string c, int n)
    {

	string x = xoring(a, b, n);
	Console.WriteLine("A ^ B (x) = " + x);	
	string y = xoring(x, c, n);
	Console.WriteLine("X ^ C (y) = " + y);	
	string z = xoring(y, a, n);
	Console.WriteLine("Y ^ A (z) = " + z);

	a = x;
	b = y;
	c = z;
    }

    public static void Main()
    {
        string a = "100010111";
        string b = "110111011";
        string c = "111111110";
        int n = a.Length;
        
    	Console.WriteLine("## Initial Value ##");
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);
        
	for (int ii = 1; ii < 6; ii++)
        {
		if (ii % 2 == 0) { 
			Console.WriteLine("");
			Console.WriteLine("## The following is Swap Iteration " + ii + " ##");
			Console.WriteLine("## Despite the previous iteration's randomized segments," + 
					  "the original contents of the binary strings (swapped or unswapped A <--> C) " +
					  "can be resolved based on randomized segments after re-XORizing. Curious. ##");
		}
		Console.WriteLine("");
		Console.WriteLine("## Start Iteration " + ii +" ##");
		XORize(ref a, ref b, ref c, n);
		Console.WriteLine("## End Iteration " + ii +" ##");
		Console.WriteLine("");
		if (ii % 2 == 0) { 
			Console.WriteLine("## A <--> C ##");
		}
        }
	
	Console.WriteLine("## Final Value ##");	
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);
		
    }
}
