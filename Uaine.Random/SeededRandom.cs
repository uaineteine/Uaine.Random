namespace Uaine.Random
{
    public class SeededRandom : System.Random
    {
        protected string seedString;
        public string getSeed => seedString;
        protected int seedInt;
        public int getSeedAsInt => seedInt;

        public SeededRandom(string seed) : base(seed.GetHashCode())
        {
            seedString = seed;
            seedInt = seed.GetHashCode();
        }
        public SeededRandom(int seed) : base(seed)
        {
            seedString = seed.ToString();
            seedInt = seed;
        }
    }
}

