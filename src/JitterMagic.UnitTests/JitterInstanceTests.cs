using System;
using Xunit;

namespace JitterMagic.UnitTests
{
    public class JitterInstanceTests
    {
        public class Constructor
        {
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

        public class ApplyForInt
        {
            private readonly IJitterInstance jitterInstance;

            public ApplyForInt()
            {
                jitterInstance = new JitterInstance(25);
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
                jitterInstance = new JitterInstance(25);
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