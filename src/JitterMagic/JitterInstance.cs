using System;

namespace JitterMagic
{
	/// <summary>
	/// Used when needing separate instances of Jitter class with different percentages; otherwise use the static class and methods
	/// </summary>	
	public class JitterInstance:IJitterInstance
	{
		/// <summary>
		/// Determines the degree of entropy added to inputs
		/// </summary>
		private int percentage;

		/// <summary>
		/// Initializes a new instance of the <see cref="JitterInstance"/> class, setting percentage to static Jitter.DefaultPercentage
		/// </summary>
		public JitterInstance()
		{
			percentage = Jitter.DefaultPercentage;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JitterInstance"/> class, setting percentage using <see cref="percentage"/>
		/// </summary>
		/// <param name="percentage">Percentage.</param>
		public JitterInstance(int percentage)
		{
			Jitter.ValidatePercentage(percentage);

			this.percentage = percentage;
		}

		/// <summary>
		/// Applies jitter to the <see cref="input" /> using the percentage set in the constructor
		/// </summary>
		/// <param name="input">A double you want to apply jitter to</param>
		/// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
		public int Apply(int input)
		{
			return Jitter.Apply(input, percentage);
		}

		/// <summary>
		/// Applies jitter to the <see cref="input" /> using the percentage set in the constructor
		/// </summary>
		/// <param name="input">A double you want to apply jitter to</param>
		/// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
		public double Apply(double input)
		{
			return Jitter.Apply(input, percentage);
		}
	}
}

