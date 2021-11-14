using System;
using Uaine.Objects.Random;

namespace Uaine.Random
{
    public class URandom : SeededRandom
    {
        protected bool usingrandomseed;
        public bool UsingRandomSeed => usingrandomseed;
        public URandom() : base(randomseed())
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

        private static int randomseed()
        {
            System.Random rnd = new System.Random();
            return rnd.Next();
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
        public short RandomShort()
        {
            byte[] buffer = new byte[2];
            NextBytes(buffer);
            return BitConverter.ToInt16(buffer, 0);
        }
        public ushort RandomUShort()
        {
            byte[] buffer = new byte[2];
            NextBytes(buffer);
            return BitConverter.ToUInt16(buffer, 0);
        }
        public bool RandomBool()
        {
            return (Next() % 2 == 0);
        }
        public bool RandomBool(float chanceToBeTrue)
        {
            return (NextDouble() >= chanceToBeTrue);
        }

        //SEQUENCES 
        public int[] randomSequence(int length, int maxInt)
        {
            int[] values = new int[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = Next(maxInt);
            }
            return values;
        }
        public int[] randomSequence(int length)
        {
            int[] values = new int[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = Next();
            }
            return values;
        }
        public float[] randomFloatSequence(int length)
        {
            float[] values = new float[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = (float)NextDouble();
            }
            return values;
        }
        public bool[] randomBoolSequence(int length)
        {
            bool[] values = new bool[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = RandomBool();
            }
            return values;
        }
        public bool[] randomBoolSequence(int length, float chanceToBeTrue)
        {
            bool[] values = new bool[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = RandomBool(chanceToBeTrue);
            }
            return values;
        }
    }
}