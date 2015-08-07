using System;

namespace JitterMagic
{
    /// <summary>
    /// The JitterMagic class adds entropy to any number; The degree of entropy is set by property DefaultPercentage or by the percentage in the overloaded methods
    /// </summary>
    public static class JitterMagic
    {
        /// <summary>
        /// Determines the degree of entropy added to inputs by the simplest overloads
        /// </summary>
        public static int DefaultPercentage { get; set; }

        /// <summary>
        /// Used for applying randomness
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Initialize the DefaultPercentage; it can be overriden by the consumer of this class at application startup
        /// </summary>
        static JitterMagic()
        {
            DefaultPercentage = 25;
        }

        /// <summary>
        /// Applies jitter to the <param name="input">input</param> using the DefaultPercentage property
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to</param>
        /// <returns>A random number between <param name="input">input</param> +/- DefaultPercentage %</returns>
        public static int ApplyJitter(int input)
        {
            return ApplyJitter(input, DefaultPercentage);
        }

        /// <summary>
        /// Applies jitter to the <param name="input">input</param> using the <param name="input">percentage</param> parameter
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to</param>
        /// <param name="percentage">An integer that has the percentage of the <param name="input">input</param> to go below and above the <param name="input">input</param> as outer bounds</param>
        /// <returns>A random number between <param name="input">input</param> +/- percentage%</returns>
        public static int ApplyJitter(int input, int percentage)
        {
            if (percentage <= 0 || percentage >= 100)
            {
                throw new ArgumentOutOfRangeException("percentage", "The percentage should be larger than 0 and smaller than 100");
            }

            int lowerBoundary = input * (100 - percentage) / 100;
            int upperBoundary = input * (100 + percentage) / 100;

            return Random.Next(lowerBoundary, upperBoundary);
        }

        /// <summary>
        /// Applies jitter to the <param name="input">input</param> using the DefaultPercentage property
        /// </summary>
        /// <param name="input">A double you want to apply jitter to</param>
        /// <returns>A random number between <param name="input">input</param> +/- DefaultPercentage %</returns>
        public static double ApplyJitter(double input)
        {
            return ApplyJitter(input, DefaultPercentage);
        }

        /// <summary>
        /// Applies jitter to the <param name="input">input</param> using the <param name="input">percentage</param> parameter
        /// </summary>
        /// <param name="input">A double you want to apply jitter to</param>
        /// <param name="percentage">An integer that has the percentage of the <param name="input">input</param> to go below and above the <param name="input">input</param> as outer bounds</param>
        /// <returns>A random number between <param name="input">input</param> +/- DefaultPercentage %</returns>
        public static double ApplyJitter(double input, int percentage)
        {
            if (percentage <= 0 || percentage >= 100)
            {
                throw new ArgumentOutOfRangeException("percentage", "The percentage should be larger than 0 and smaller than 100");
            }

            double lowerBoundary = input * (100 - percentage) / 100;
            double upperBoundary = input * (100 + percentage) / 100;

            return lowerBoundary + (upperBoundary - lowerBoundary)*Random.NextDouble();
        }
    }
}
