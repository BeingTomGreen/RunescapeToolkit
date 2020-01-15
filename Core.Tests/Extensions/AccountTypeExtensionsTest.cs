using Core.Enums;
using Core.Extensions;
using Xunit;

namespace Core.UnitTests.Extensions
{
    public class AccountTypeExtensionsTest
    {
        /**
         * 
         * Really, these are stupid, they're just testing that I've correctly set AccountTypeMetaDataAttribute for the AccountTypes
         * 
         * However I figured out writing these that AccountTypeExtensions.UrlValue was returning DisplayValue, not UrlValue - so they served a purpose
         *
         */
        [Fact]
        public void GetsDisplayValue()
        {
            Assert.Equal("Normal", AccountType.Normal.DisplayValue());
            Assert.Equal("Ironman", AccountType.Ironman.DisplayValue());
            Assert.Equal("Ultimate Ironman", AccountType.UltimateIronman.DisplayValue());
            Assert.Equal("Deadman", AccountType.DeadmanMode.DisplayValue());
            Assert.Equal("Seasonal Deadman", AccountType.SeasonalDeadmanMode.DisplayValue());
        }

        [Fact]
        public void GetsUrlValue()
        {
            Assert.Equal("normal", AccountType.Normal.UrlValue());
            Assert.Equal("ironman", AccountType.Ironman.UrlValue());
            Assert.Equal("ultimate", AccountType.UltimateIronman.UrlValue());
            Assert.Equal("deadman", AccountType.DeadmanMode.UrlValue());
            Assert.Equal("seasonal", AccountType.SeasonalDeadmanMode.UrlValue());
        }

    }
}
