using System;

namespace JitterMagic
{
	/// <summary>
	/// Used when needing separate instances of Jitter class with different percentages; otherwise use the static class and methods
	/// </summary>
	public interface IJitterInstance
	{
		/// <summary>
		/// Applies jitter to the <see cref="input" /> using the percentage set in the constructor
		/// </summary>
		/// <param name="input">A double you want to apply jitter to</param>
		/// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
		int Apply(int input);

		/// <summary>
		/// Applies jitter to the <see cref="input" /> using the percentage set in the constructor
		/// </summary>
		/// <param name="input">A double you want to apply jitter to</param>
		/// <returns>A random number between <see cref="input" /> +/- DefaultPercentage %</returns>
		double Apply(double input);
	}
}