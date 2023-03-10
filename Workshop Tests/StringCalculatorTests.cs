using System;
using Workshop;
using Xunit;

namespace Workshop_Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("1", 1)]
        [InlineData("225", 225)]
        public void SingleNumberReturnsValue(String str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12,23", 35)]
        [InlineData("1,2", 3)]
        [InlineData("256, 256", 512)]
        public void TwoNumberWithComma(String str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n23", 35)]
        [InlineData("1\n2", 3)]
        [InlineData("256\n 256", 512)]
        public void TwoNumberWithNewline(String str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        //[InlineData("12\n\n23", 35)]
        //[InlineData("1\n,2", 3)]
        //[InlineData("\n \n", 0)]
        [InlineData("4,0,6", 10)]
        public void ManyNumberWithCommaOrNewline(String str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        //[InlineData("-12\n\n23")]
        //[InlineData("1\n,-2")]
        //[InlineData("\n \n -5")]
        [InlineData("-4,0,6")]
        public void NegativeNumbersThrowErrors(String str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.SumString(str));
        }

        [Theory]
        //[InlineData("12\n\n23", 35)]
        //[InlineData("1\n,1001", 1)]
        [InlineData("1001", 0)]
        //[InlineData("\n \n 1000", 1000)]
        [InlineData("4,0,999", 1003)]
        public void NumbersBiggerThan1000AreIgnored(String str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }
    }
}
