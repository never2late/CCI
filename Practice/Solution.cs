using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        public uint reverseBits(uint n)
        {
            uint result = 0x0;
            for (int i = 0; i < 16; i++) result = swapBits(result, n, i);
            return result;
        }

        private uint swapBits(uint result, uint n, int i)
        {
            uint maski = ((uint)0x1) << i;
            uint maske = ((uint)0x800000) >> i;
            uint valuei = (n & maski) << (31 - i * 2);
            uint valuee = (n & maske) >> (31 - i * 2);
            result |= valuei;
            result |= valuee;
            return result;
        }
    }
}


