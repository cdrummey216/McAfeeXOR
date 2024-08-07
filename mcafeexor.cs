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
    
    public static void XORize(ref string a, ref string b, ref string c, int n){
		Console.WriteLine("");
		Console.WriteLine("## Start Iteration ##");
		string x = xoring(a, b, n);
		Console.WriteLine("A ^ B = " + x);	
		string y = xoring(x, c, n);
		Console.WriteLine("X ^ C = " + y);	
		string z = xoring(y, a, n);
		Console.WriteLine("Y ^ A = " + z);
		Console.WriteLine("## End Iteration ##");
		Console.WriteLine("");
		
		a = x;
		b = y;
		c = z;
	}

    public static void Main()
    {
        string a = "10101010";
        string b = "11011101";
        string c = "11111111";
        int n = a.Length;
        
    	Console.WriteLine("## Initial Value ##");
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);
        
	for (int ii = 0; ii < 4; ii++)
        {
		XORize(ref a, ref b, ref c, n);
        }
	Console.WriteLine("## Final Value ##");	
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);
		
    }
}
