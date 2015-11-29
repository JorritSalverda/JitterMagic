using System;
using Xunit;

namespace JitterMagic.UnitTests
{
    public class JitterSettingsTests
    {
        public class Constructor
        {
            [Fact]
            public void Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_Zero_Or_Less()
            {
                // act + assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new JitterSettings(percentage: -1));
            }

            [Fact]
            public void Throws_An_ArgumentOutOfRangeException_If_Percentage_Is_One_Hundred_Or_More()
            {
                // act + assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new JitterSettings(percentage: 100));
            }            
        }
    }
}

