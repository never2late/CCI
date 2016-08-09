using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterTwelveTester : Util
	{
		public void test(int q, int o)
		{
			if (q == 0)
			{
				int n = 256;
				var bitField = compressToBitField(n);
				printBitFieldToInt(bitField);
			}
		}

		private byte[] compressToBitField(int n)
		{
			byte[] bitField = new byte[n / 8 + 1];

			for (int i = 0; i < n; i++)
			{
				bitField[i / 8] |= (byte) (0x1 << (i % 8));
			}

			return bitField;
		}

		private void printBitFieldToInt(byte[] bitField)
		{
			for (int i = 0; i < bitField.Length; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((bitField[i] & (0x1 << j)) > 0)
					{
						int val = 8 * i + j;
						PrintLn(val);
					}
				}
			}
		}
	}
}
