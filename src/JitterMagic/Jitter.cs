using System;

namespace JitterMagic
{
    /// <summary>
    /// The Jitter class has methods to add entropy to any number; The degree of entropy is set by property DefaultPercentage or by the percentage in the overloaded methods.
    /// </summary>
    public static class Jitter
    {
        /// <summary>
        /// Gets or sets the settings for usage of this class.
        /// </summary>
        /// <value>The default setting.</value>
        public static JitterSettings Settings { get; private set; }    

        /// <summary>
        /// Used for applying randomness
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Initialize the DefaultPercentage; it can be overriden by the consumer of this class at application startup.
        /// </summary>
        static Jitter()
        {
            Settings = new JitterSettings();
        }

        /// <summary>
        /// Updates the settings.
        /// </summary>
        /// <param name="settings">Settings.</param>
        public static void UpdateSettings(JitterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            Settings = settings;
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the default settings.
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to.</param>
        /// <returns>A random number between <see cref="input" /> +/- DefaultPercentage.</returns>
        public static int Apply(int input)
        {
            return Apply(input, Settings);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the passed in settings.
        /// </summary>
        /// <param name="input">An integer you want to apply jitter to.</param>
        /// <param name="settings">Object that contains settings.</param>
        /// <returns>A random number between <see cref="input" /> +/- percentage.</returns>
        public static int Apply(int input, JitterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            int lowerBoundary = input * (100 - settings.Percentage) / 100;
            int upperBoundary = input * (100 + settings.Percentage) / 100;

            return Random.Next(lowerBoundary, upperBoundary);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the default settings.
        /// </summary>
        /// <param name="input">A double you want to apply jitter to.</param>
        /// <returns>A random number between <see cref="input" /> +/- DefaultPercentage.</returns>
        public static double Apply(double input)
        {
            return Apply(input, Settings);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the passed in settings.
        /// </summary>
        /// <param name="input">A double you want to apply jitter to.</param>
        /// <param name="percentage">An integer that has the percentage of the <see cref="input" /> to go below and above the <see cref="input" /> as outer bounds.</param>
        /// <returns>A random number between <see cref="input" /> +/- percentage.</returns>
        public static double Apply(double input, JitterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            double lowerBoundary = input * (100 - settings.Percentage) / 100;
            double upperBoundary = input * (100 + settings.Percentage) / 100;

            return lowerBoundary + (upperBoundary - lowerBoundary) * Random.NextDouble();
        }
    }
}
