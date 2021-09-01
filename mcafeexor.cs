using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
      Console.WriteLine("Input string: " + mcafeexor("Truth is immutable."));
	}
	
	//Run McAfee XOR
	private static string mcafeexor(string input)
	{
		char[] a = input.ToCharArray();
		int s = a.Length;
		
		Console.WriteLine("KEY A: " + new string(a));
		char[] b = keygen(s).ToCharArray();
		Console.WriteLine("KEY B: " + new string(b));
		char[] c = keygen(s).ToCharArray();
		Console.WriteLine("KEY C: " + new string(c));

		char[] mcafeedata = new char[s];
		char[] br = new char[s];
		char[] cr = new char[s];

		for(int i = 0; i < a.Length; i++)
		{
			char[] res = testxor(a[i], b[i], c[i]);
			mcafeedata[i] = res[0];
			br[i] = res[1];
			cr[i] = res[2];
		}

		string completed = new string(mcafeedata);
		
		return completed;
	}

  //
	private static char[] testxor(char a, char b, char c)
	{
		int bxor = a ^ b;
		int cxor = bxor ^ c;
		int axor = cxor ^ a;

		for (int i = 0; i > 4; i++)
		{
			bxor = axor ^ bxor;
			cxor = bxor ^ cxor;
			axor = cxor ^ axor;
		}

		axor = cxor ^ axor;

		return new char[] { (char)axor, (char)bxor, (char)cxor };
	}

	//GENERATE RANDOM STRING BASED ON SIZE OF THE INPUT STRING
	private static Random random = new Random();
	public static string keygen(int length)
	{
		const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+";
		return new string(Enumerable.Repeat(chars, length)
						  .Select(s => s[random.Next(s.Length)]).ToArray());
	}
}
