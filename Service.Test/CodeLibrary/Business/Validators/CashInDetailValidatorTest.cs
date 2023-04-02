using Business.Validators;
using Xunit;

namespace Service.Test.CodeLibrary.Business.Validators
{
    public class CashInDetailValidatorTest
    {
        [Fact]
        public void BeLenghtOfTen_ShouldReturnBoolWhenStringInputGivenIsBeLenghtOfTen()
        {
            // Assert

            Assert.True(CashInDetailValidator.BeLenghtOfTen("1234567890"));
            Assert.False(CashInDetailValidator.BeLenghtOfTen("123456789"));
        }

        [Fact]
        public void LocalCurrency_ShouldReturnBoolWhenStringInputGivenIsLocalCurrency()
        {
            // Assert

            Assert.True(CashInDetailValidator.LocalCurrency("EUR"));
            Assert.False(CashInDetailValidator.LocalCurrency("GHS"));
        }

        [Fact]
        public void GreaterThanZero_ShouldReturnBoolWhenStringInputGivenIsGreaterThanZero()
        {
            // Assert

            Assert.True(CashInDetailValidator.GreaterThanZero(5));
            Assert.False(CashInDetailValidator.GreaterThanZero(0));
        }
    }
}