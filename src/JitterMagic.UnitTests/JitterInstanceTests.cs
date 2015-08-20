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
            private readonly IJitterInstance jitterInstance;

            public UpdateSettings()
            {
                jitterInstance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Throws_An_ArgumentNullException_If_Settings_Is_Null()
            {
                // act + assert
                Assert.Throws<ArgumentNullException>(() => jitterInstance.UpdateSettings(null));
            }
        }

        public class ApplyForInt
        {
            private readonly IJitterInstance jitterInstance;

            public ApplyForInt()
            {
                jitterInstance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = jitterInstance.Apply(100);

                Assert.InRange(result, 75, 125);
            }
        }

        public class ApplyForDouble
        {
            private readonly IJitterInstance jitterInstance;

            public ApplyForDouble()
            {
                jitterInstance = new JitterInstance(new JitterSettings(percentage: 25));
            }

            [Fact]
            public void Returns_A_Number_Within_Percentage_Below_And_Above_Number()
            {
                // act
                var result = jitterInstance.Apply(100d);

                Assert.InRange(result, 75d, 125d);
            }
        }
    }
}