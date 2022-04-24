using System;

namespace Application
{
	public class Encrypter
	{
		public static string  ApplyXOR(string message, int key)
		{
			string result = "";
			for(int i = 0; i < message.Length;i++)
			{
				int c = (int)message[i];
				int n = c^key;
				result += (char)n;
			}


			return result;
		}
	}
}

