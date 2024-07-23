using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
	public static void Main()
	{
		//Console.WriteLine("Input string: " + xor("Truth is immutable."));
		var list = xor("Truth is immutable.");
		for (int i = 0; i < list.Count; i++)
		{
			//Console.Write("Part " + i + " of " + list.Count + ": " + list[i] + " \n");
		}
		
		var dict = Decode(list);
		PrintDict(dict);
	}
	
	public static void PrintDict(Dictionary<string, byte[]> dict)
    {
        for (int i = 0; i < dict.Count; i++)
        {
            KeyValuePair<string, byte[]> entry = dict.ElementAt(i);
			string bytes = PrintByteArray(entry.Value);
			Console.WriteLine("KEY " + i + ": " + entry.Key + "/n ");
			Console.WriteLine("VALUE: " + bytes + "/n ");
        }
    }
	
	public static string PrintByteArray(byte[] bytes)
	{
		var sb = new StringBuilder("new byte[] { ");
		foreach (var b in bytes)
		{
			sb.Append(b + ", ");
		}
		sb.Append("}");
		return sb.ToString();
	}
	
 public static string xoring(string a, string b, int n){
    string ans = "";
         
        // Loop to iterate over the
        // Binary Strings
        for (int i = 0; i < n; i++)
        {
            // If the Character matches
            if (a[i] == b[i])
                ans += "0";
            else
                ans += "1";
        }
        return ans;
 }
	public static Dictionary<string, byte[]> Decode(List<string> input)
	{
		string response = "";
		List<string> strings = input;
		Encoding asciiEncoding = Encoding.ASCII;
		// Array to hold encoded bytes.
		Dictionary<string, byte[]> encodedList = new Dictionary<string, byte[]>();
		byte[] bytes;
		// Array to hold decoded characters.
		char[] chars = new char[50];
		// Create index for current position of character array.
		int index = 0;

		foreach (var stringValue in strings)
		{
			//Console.WriteLine("String to Encode: {0}", stringValue);
			// Encode the string to a byte array.
			bytes = asciiEncoding.GetBytes(stringValue);
			encodedList.Add(stringValue, bytes);
			// Display the encoded bytes.
			//Console.Write("Encoded bytes: ");
			//for (int ctr = 0; ctr < bytes.Length; ctr++)
				//Console.Write(" {0}{1:X2}",
				//			  ctr % 20 == 0 ? Environment.NewLine : "",
				//			  bytes[ctr]);
			//Console.WriteLine();

			// Decode the bytes to a single character array.
			int count = asciiEncoding.GetCharCount(bytes);
			if (count + index >= chars.Length)
				Array.Resize(ref chars, chars.Length + 50);

			int written = asciiEncoding.GetChars(bytes, 0,
												 bytes.Length,
												 chars, index);
			index = index + written;
		}

		// Instantiate a single string containing the characters.
		response = new string(chars, 0, index - 1);

		return encodedList;
	}

	public static List<string> xor(string input)
	{
		char[] a = input.ToCharArray();
		int s = a.Length;
		//Console.WriteLine("KEY A: " + new string(a));
		char[] b = keygen(s).ToCharArray();
		//Console.WriteLine("KEY B: " + new string(b));
		char[] c = keygen(s).ToCharArray();
		//Console.WriteLine("KEY C: " + new string(c));
		
		char[] data = new char[s];
		char[] br = new char[s];
		char[] cr = new char[s];
		List<string> list = new List<string>();
		
		for (int i = 0; i < a.Length; i++)
		{
			char[] res = testxor(a[i], b[i], c[i]);
			data[i] = res[0];
			br[i] = res[1];
			cr[i] = res[2];
		}
		
		for (int i = 0; i < a.Length; i++)
		{
			char[] res = secondxor(data[i], br[i], cr[i]);
			br[i] = res[0];
			cr[i] = res[1];
		}
		

		string completed1 = new string(data);
		string completed2 = new string(br);
		string completed3 = new string(cr);
		list.Add(completed1);
		list.Add(completed2);
		list.Add(completed3);
		return list;
	}
	

	public static char[] testxor(char a, char b, char c)
	{
		int bxor = a ^ b;
		int cxor = bxor ^ c;
		int axor = cxor ^ a;
		for (int i = 0; i > 3; i++)
		{
			bxor = axor ^ bxor;
			cxor = bxor ^ cxor;
			axor = cxor ^ axor;
		}
		//axor = cxor ^ axor;
		
		return new char[]{Convert.ToChar(axor), Convert.ToChar(bxor), Convert.ToChar(cxor)};
	}
	
	public static char[] secondxor(char a, char b, char c)
	{
		int bxor = a ^ b;
		int cxor = bxor ^ c;
		//for (int i = 0; i > 4; i++)
		//{
		//	bxor = axor ^ bxor;
		//	cxor = bxor ^ cxor;
		//	axor = cxor ^ axor;
		//}
		//axor = cxor ^ axor;
		
		return new char[]{Convert.ToChar(bxor), Convert.ToChar(cxor)};
	}

	public static Random random = new Random();
	public static string keygen(int length)
	{
		const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
	}
}
