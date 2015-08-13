using System;

namespace JitterMagic
{
    /// <summary>
    /// Used when needing separate instances of Jitter class with different settings; otherwise use the static class and methods.
    /// </summary> 
    public class JitterInstance:IJitterInstance
    {
        /// <summary>
        /// Determines the degree of entropy added to inputs
        /// </summary>
        private readonly int percentage;

        /// <summary>
        /// Initializes a new instance of the <see cref="JitterInstance"/> class with passed in settings.
        /// </summary>
        /// <param name="percentage">Percentage of jitter to apply.</param>
        public JitterInstance(int percentage)
        {
            Jitter.ValidateParameters(percentage);

            this.percentage = percentage;
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the settings set in the constructor.
        /// </summary>
        /// <param name="input">A double you want to apply jitter to.</param>
        /// <returns>A random number between <see cref="input" /> +/- percentage.</returns>
        public int Apply(int input)
        {
            return Jitter.Apply(input, percentage);
        }

        /// <summary>
        /// Applies jitter to the <see cref="input" /> using the settings set in the constructor.
        /// </summary>
        /// <param name="input">A double you want to apply jitter to.</param>
        /// <returns>A random number between <see cref="input" /> +/- percentage.</returns>
        public double Apply(double input)
        {
            return Jitter.Apply(input, percentage);
        }
    }
}

