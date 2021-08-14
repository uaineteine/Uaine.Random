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
    }
}