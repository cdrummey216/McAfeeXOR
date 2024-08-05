using System;

public class Program
{
    // 2nd and 4th iterations see value swapped between A <--> C
    // 01110100 01110010 01110101 01110100 01101000 00100000 01101001 01110011 00100000 01101001 01101101 01101101 01110101 01110100 01100001 01100010 01101100 01100101
    static string xoring(string a, string b, int n){
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
     

    static public void Main()
    {
        string a = "10101010";
        string b = "11011101";
        string c = "11111111";
        int n = a.Length;
        
    	Console.WriteLine("## Initial Value ##");
        Console.WriteLine("A = " + a);
        Console.WriteLine("B = " + b);
        Console.WriteLine("C = " + c);
        
	//Iteration 0
	Console.WriteLine("");
	Console.WriteLine("## 1st Iteration ##");
	string x = xoring(a, b, n);
	Console.WriteLine("A ^ B = " + x);	
	string y = xoring(x, c, n);
	Console.WriteLine("X ^ C = " + y);	
	string z = xoring(y, a, n);
	Console.WriteLine("Y ^ A = " + z);

	Console.WriteLine("## 1st Iteration Results ##");
	Console.WriteLine("A = " + x);
	Console.WriteLine("B = " + y);
	Console.WriteLine("C = " + z);

	//Iteration 1
	Console.WriteLine("");
	Console.WriteLine("## 2nd Iteration (values shifted) ##");
	string d = xoring(x, y, n);//C moved to A
	Console.WriteLine("X ^ Y = " + d + "(C --> A)");
	string e = xoring(d, z, n);// B moved to B
	Console.WriteLine("D ^ Z = " + e + "(B --> B)");	
	string f = xoring(e, x, n); //A moved to C
	Console.WriteLine("E ^ X = " + f + "(A --> C)");

	Console.WriteLine("## 2nd Iteration Results ##");
	Console.WriteLine("A = " + d);
	Console.WriteLine("B = " + e);
	Console.WriteLine("C = " + f);

	//Iteration 2
	Console.WriteLine("");
	Console.WriteLine("## 3rd Iteration ##");
	string u = xoring(d, e, n);
	Console.WriteLine("D ^ E = " + u);	
	string v = xoring(u, f, n);
	Console.WriteLine("U ^ F = " + v);	
	string w = xoring(v, d, n);
	Console.WriteLine("V ^ D = " + w);

	Console.WriteLine("## 3rd Iteration Results ##");
	Console.WriteLine("A = " + u);
	Console.WriteLine("B = " + v);
	Console.WriteLine("C = " + w);

	//Iteration 3
	Console.WriteLine("");
	Console.WriteLine("## 4th Iteration (values returned) ##");
	string g = xoring(u, v, n); //A returned to A
	Console.WriteLine("U ^ V = " + g + "(C <-- A)");	
	string h = xoring(g, w, n);//B returned to B
	Console.WriteLine("G ^ W = " + h + "(B <-- B)");	
	string i = xoring(h, u, n);//C returned to C
	Console.WriteLine("H ^ U = " + i + "(A <-- C)");

	Console.WriteLine("## 4th Iteration Results ##");
	Console.WriteLine("A = " + g);
	Console.WriteLine("B = " + h);
	Console.WriteLine("C = " + i);
		
    }
}
