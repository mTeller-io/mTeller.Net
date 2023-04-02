using Business;
using Xunit;

namespace Service.Test.CodeLibrary.Business.Validators
{
    public class CashInValidatorTest
    {
        [Fact]
        public void BeLenghtOfTen_ShouldReturnBoolWhenStringInputGivenIsBeLenghtOfTen()
        {
            // Assert

            Assert.True(CashInValidator.BeLenghtOfTen("1234567890"));
            Assert.False(CashInValidator.BeLenghtOfTen("123456789"));
        }

        [Fact]
        public void LocalCurrency_ShouldReturnBoolWhenStringInputGivenIsLocalCurrency()
        {
            // Assert

            Assert.True(CashInValidator.BeOnline("someText"));
            Assert.False(CashInValidator.BeOnline(string.Empty));
        }

        [Fact]
        public void GreaterThanZero_ShouldReturnBoolWhenStringInputGivenIsGreaterThanZero()
        {
            // Assert

            Assert.True(CashInValidator.GreaterThanZero(50M));
            Assert.False(CashInValidator.GreaterThanZero(-10M));
        }
    }
}