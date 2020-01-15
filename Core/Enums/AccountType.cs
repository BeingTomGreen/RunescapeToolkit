using Core.Attributes;

namespace Core.Enums
{
    public enum AccountType
    {
        [AccountTypeMetaData("Normal", "normal")]
        Normal,

        [AccountTypeMetaData("Ironman", "ironman")]
        Ironman,

        [AccountTypeMetaData("Ultimate Ironman", "ultimate")]
        UltimateIronman,

        [AccountTypeMetaData("Hardcore Ironman", "hardcore")]
        HardcoreIronman,

        [AccountTypeMetaData("Deadman", "deadman")]
        DeadmanMode,

        [AccountTypeMetaData("Seasonal Deadman", "seasonal")]
        SeasonalDeadmanMode
    }


}

