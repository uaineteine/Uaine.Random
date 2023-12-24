using System;
using System.Linq;

namespace Uaine.Random
{
    public class Die
    {
        private readonly URandom random;
        private readonly int sides;
        private int modifier = 0;

        public int Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        public Die(int sides, int modifier = 0)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("Number of sides must be greater than zero.");
            }

            this.sides = sides;
            random = new URandom();
            this.modifier = modifier;
        }

        public Die(int sides, string seed, int modifier = 0)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("Number of sides must be greater than zero.");
            }

            this.sides = sides;
            random = new URandom(seed);
            this.modifier = modifier;
        }

        public Die(int sides, int seed, int modifier = 0)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("Number of sides must be greater than zero.");
            }

            this.sides = sides;
            random = new URandom(seed);
            this.modifier = modifier;
        }

        public int Roll()
        {
            return random.Next(1, sides + 1) + modifier;
        }

        public int Max(int numberOfRolls)
        {
            int maxResult = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                int rollResult = Roll();
                if (rollResult > maxResult)
                {
                    maxResult = rollResult;
                }
            }
            return maxResult;
        }

        public int Sum(int numberOfRolls)
        {
            int sum = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                sum += Roll();
            }
            return sum;
        }
    }

    public class Dice
    {
        private readonly Die[] dice;

        public Dice(params Die[] dice)
        {
            if (dice == null || dice.Length == 0)
            {
                throw new ArgumentException("At least one die should be provided.");
            }

            this.dice = dice;
        }

        public int Roll()
        {
            return dice.Sum(d => d.Roll());
        }

        public int Max(int numberOfRolls)
        {
            return dice.Sum(d => d.Max(numberOfRolls));
        }

        public int Sum(int numberOfRolls)
        {
            return dice.Sum(d => d.Sum(numberOfRolls));
        }
    }
}