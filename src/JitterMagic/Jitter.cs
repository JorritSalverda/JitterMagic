using System;

namespace JitterMagic
{
    /// <summary>
    /// The Jitter class has methods to add entropy to any number; The degree of entropy is set by property DefaultPercentage or by the percentage in the overloaded methods
    /// </summary>
	public static class Jitter
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
        static Jitter()
        {
            DefaultPercentage = 25;
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the DefaultPercentage property
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to</param>
        /// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
        public static int Apply(int input)
        {
            return Apply(input, DefaultPercentage);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the <see cref="percentage" /> parameter
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to</param>
        /// <param name="percentage">An integer that has the percentage of the <see cref="input" /> to go below and above the <see cref="input" /> as outer bounds</param>
        /// <returns>A random number between <see cref="input" /> +/- percentage%</returns>
        public static int Apply(int input, int percentage)
        {
			ValidatePercentage(percentage);

            int lowerBoundary = input * (100 - percentage) / 100;
            int upperBoundary = input * (100 + percentage) / 100;

            return Random.Next(lowerBoundary, upperBoundary);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the DefaultPercentage property
        /// </summary>
        /// <param name="input">A double you want to apply jitter to</param>
        /// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
        public static double Apply(double input)
        {
            return Apply(input, DefaultPercentage);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the <see cref="percentage" /> parameter
        /// </summary>
        /// <param name="input">A double you want to apply jitter to</param>
        /// <param name="percentage">An integer that has the percentage of the <see cref="input" /> to go below and above the <see cref="input" /> as outer bounds</param>
        /// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
        public static double Apply(double input, int percentage)
        {
			ValidatePercentage(percentage);

            double lowerBoundary = input * (100 - percentage) / 100;
            double upperBoundary = input * (100 + percentage) / 100;

            return lowerBoundary + (upperBoundary - lowerBoundary)*Random.NextDouble();
        }

		/// <summary>
		/// Validate if percentage is within the allowed range
		/// </summary>
		/// <param name="percentage">Percentage.</param>
		internal static void ValidatePercentage(int percentage)
		{
			if (percentage <= 0 || percentage >= 100)
			{
				throw new ArgumentOutOfRangeException("percentage", "The percentage should be larger than 0 and smaller than 100");
			}
		}
    }
}
