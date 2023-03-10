using System;
using Uaine.Objects.Random;

namespace Uaine.Random
{
    public class URandom : SeededRandom
    {
        protected bool usingrandomseed = false;
        public bool UsingRandomSeed => usingrandomseed;
        public URandom() : base(randomseed())
        {
            usingrandomseed = true;
        }
        public URandom(string seed) : base(seed)
        {
        }
        public URandom(int seed) : base(seed)
        {
        }

        private static int randomseed()
        {
            System.Random rnd = new System.Random();
            return rnd.Next();
        }

        public byte[] MakeBuffer(int length)
        {
            byte[] buffer = new byte[length];
            NextBytes(buffer);
            return buffer;
        }
        public long RandomLong()
        {
            return BitConverter.ToInt64(MakeBuffer(8), 0);
        }
        public ulong RandomULong()
        { 
            return BitConverter.ToUInt64(MakeBuffer(8), 0);
        }
        public long RandomLongPosOnly()
        {
            long value = BitConverter.ToInt64(MakeBuffer(8), 0);
            return Math.Abs(value);
        }
        public short RandomShort()
        {
            return BitConverter.ToInt16(MakeBuffer(2), 0);
        }
        public ushort RandomUShort()
        {
            return BitConverter.ToUInt16(MakeBuffer(2), 0);
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