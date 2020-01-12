using System;
using Xunit;
using Core.Helpers;
using Core.Exceptions;

namespace Core.Tests.Helpers
{
    public class PlayerHelpersTest
    {
        public PlayerHelpersTest() { }

        [Fact]
        public void GetAccountTypeDisplayStringTest()
        {
            Assert.Equal("Normal", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.Normal));
            Assert.Equal("Ironman", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.Ironman));
            Assert.Equal("Ultimate Ironman", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.UltimateIronman));
            Assert.Equal("Hardcore Ironman", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.HardcoreIronman));
            Assert.Equal("Deadman", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.DeadmanMode));
            Assert.Equal("Seasonal Deadman", PlayerHelpers.GetAccountTypeDisplayString(Enums.AccountType.SeasonalDeadmanMode));
        }

        [Fact]
        public void CleanUsernameTest()
        {
            Assert.Equal("ferrous_hugs", PlayerHelpers.CleanUsername("ferrous hugs"));
            Assert.Equal("ferrous_hugs", PlayerHelpers.CleanUsername("ferrous_hugs"));
            Assert.Equal("ferrous_hugs", PlayerHelpers.CleanUsername("ferrous!£$%^&*() hugs"));
        }

        [Fact]
        public void ValidateUsernameTest()
        { 
            Assert.True(PlayerHelpers.ValidateUsername("ferrous_hugs"));
            Assert.True(PlayerHelpers.ValidateUsername(" ferrous_hugs"));
            Assert.True(PlayerHelpers.ValidateUsername("fer__hugs"));
            Assert.True(PlayerHelpers.ValidateUsername("ferrous hugs"));
            Assert.True(PlayerHelpers.ValidateUsername("fer  hugs"));
            Assert.True(PlayerHelpers.ValidateUsername("69_hugs"));

            Assert.False(PlayerHelpers.ValidateUsername("ThisUserNameIsToooooLong"));
            Assert.False(PlayerHelpers.ValidateUsername("$%$£!()*&^'"));
        }
    }
}
