using System;
using Xunit;

namespace JitterMagic.UnitTests
{
    public class JitterInstanceTests
    {
        public class Constructor
        {
            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => new JitterInstance(null));
            }
        }

        public class UpdateSettings
        {
            private readonly IJitterInstance instance;

            public UpdateSettings()
            {
                instance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => instance.UpdateSettings(null));
            }

            [Fact]
            public void Updates_Settings_Property()
            {
                // act
                Jitter.UpdateSettings(new JitterSettings(percentage: 35));

                Assert.Equal(35, Jitter.Settings.Percentage);
            }
        }

        public class ApplyForInt
        {
            private readonly IJitterInstance instance;

            public ApplyForInt()
            {
                instance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = instance.Apply(100);

                Assert.InRange(result, 75, 125);
            }
        }

        public class ApplyForDouble
        {
            private readonly IJitterInstance instance;

            public ApplyForDouble()
            {
                instance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = instance.Apply(100d);

                Assert.InRange(result, 75d, 125d);
            }
        }
    }
}