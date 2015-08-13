using System;
using Xunit;

namespace JitterMagic.UnitTests
{
    public class JitterTests
    {
        [Fact]
        public void Apply_For_Int_Returns_A_Number_Within_Percentage_Below_And_Above_Number()
        {
            // act
            var result = Jitter.Apply(100, 25);

            Assert.InRange(result, 75, 125);
        }

        [Fact]
		public void Apply_For_Int_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_Zero_Or_Less()
        {
            // act + assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Jitter.Apply(100, 0));
        }

        [Fact]
		public void Apply_For_Int_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_One_Hundred_Or_More()
        {
            // act + assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Jitter.Apply(100, 100));
        }

        [Fact]
		public void Apply_For_Double_Returns_A_Number_Within_Percentage_Below_And_Above_Number()
        {
            // act
            var result = Jitter.Apply(100d, 25);

            Assert.InRange(result, 75d, 125d);
        }

        [Fact]
		public void Apply_For_Double_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_Zero_Or_Less()
        {
            // act + assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Jitter.Apply(100d, 0));
        }

        [Fact]
		public void Apply_For_Double_Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_One_Hundred_Or_More()
        {
            // act + assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Jitter.Apply(100d, 100));
        }
    }
}