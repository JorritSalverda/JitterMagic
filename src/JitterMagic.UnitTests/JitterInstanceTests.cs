using System;
using Xunit;

namespace JitterMagic.UnitTests
{
	public class JitterInstanceTests
	{
		[Fact]
		public void Apply_For_Int_Returns_A_Number_Within_Percentage_Below_And_Above_Number()
		{
			IJitterInstance jitterInstance = new JitterInstance(25);

			// act
			var result = jitterInstance.Apply(100);

			Assert.InRange(result, 75, 125);
		}

		[Fact]
		public void Apply_For_Double_Returns_A_Number_Within_Percentage_Below_And_Above_Number()
		{
			IJitterInstance jitterInstance = new JitterInstance(25);

			// act
			var result = jitterInstance.Apply(100d);

			Assert.InRange(result, 75d, 125d);
		}

		[Fact]
		public void Constructor_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_Zero_Or_Less()
		{
			// act + assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new JitterInstance(0));
		}

		[Fact]
		public void Constructor_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_One_Hundred_Or_More()
		{
			// act + assert
			Assert.Throws<ArgumentOutOfRangeException>(() => new JitterInstance(100));
		}
	}
}