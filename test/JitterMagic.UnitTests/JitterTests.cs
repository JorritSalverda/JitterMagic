using System;
using Xunit;

namespace JitterMagic.UnitTests
{
    public class JitterTests
    {
        public class UpdateSettings
        {
            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => Jitter.UpdateSettings(null));
            }

            [Fact]
            public void Updates_Settings_Property()
            {
                // act
                Jitter.UpdateSettings(new JitterSettings(percentage: 35));

                Assert.Equal(35, Jitter.Settings.Percentage);
            }
        }

        public class ApplyForIntWithSettings
        {
            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = Jitter.Apply(100, new JitterSettings(percentage: 25));

                Assert.InRange(result, 75, 125);
            }

            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => Jitter.Apply(100, null));
            }
        }

        public class ApplyForDoubleWithSettings
        {
            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = Jitter.Apply(100d, new JitterSettings(percentage: 25));

                Assert.InRange(result, 75d, 125d);
            }

            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => Jitter.Apply(100d, null));
            }
        }
    }
}