using System;
using Uaine.Objects.Random;

namespace Uaine.Random
{
    public class URandom : SeededRandom
    {
        protected bool usingrandomseed;
        public bool UsingRandomSeed => usingrandomseed;
        public URandom() : base(Environment.TickCount)
        {
            usingrandomseed = true;
        }
        public URandom(string seed) : base(seed)
        {
            usingrandomseed = false;
        }
        public URandom(int seed) : base(seed)
        {
            usingrandomseed = false;
        }

        public long RandomLong()
        {
            byte[] buffer = new byte[8];
            NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
        public ulong RandomULong()
        {
            byte[] buffer = new byte[8];
            NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }
        public long RandomLongPosOnly()
        {
            byte[] buffer = new byte[8];
            NextBytes(buffer);
            long value = BitConverter.ToInt64(buffer, 0);
            return Math.Abs(value);
        }
    }
}