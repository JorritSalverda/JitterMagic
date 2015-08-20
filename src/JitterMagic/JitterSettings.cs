using System;

namespace JitterMagic
{
    public class JitterSettings
    {
        /// <summary>
        /// Determines the degree of entropy.
        /// </summary>
        public int Percentage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JitterMagic.JitterSettings"/> class with provided values.
        /// </summary>
        /// <param name="percentage">Percentage.</param>
        public JitterSettings(int percentage = 25)
        {
            Percentage = percentage;
            Validate();
        }

        /// <summary>
        /// Validate this instance.
        /// </summary>
        internal void Validate()
        {
            if (Percentage <= 0 || Percentage >= 100)
            {
                throw new ArgumentOutOfRangeException("percentage", "The percentage should be larger than 0 and smaller than 100");
            }
        }
    }
}