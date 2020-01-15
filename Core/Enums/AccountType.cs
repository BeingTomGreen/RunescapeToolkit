using Core.Attributes;

namespace Core.Enums
{
    public enum AccountType
    {
        [DisplayValue("Normal")]
        [UrlValue("normal")]
        Normal,

        [DisplayValue("Ironman")]
        [UrlValue("ironman")]
        Ironman,

        [DisplayValue("Ultimate Ironman")]
        [UrlValue("ultimate")]
        UltimateIronman,

        [DisplayValue("Hardcore Ironman")]
        [UrlValue("hardcore")]
        HardcoreIronman,

        [DisplayValue("Deadman")]
        [UrlValue("deadman")]
        DeadmanMode,

        [DisplayValue("Seasonal Deadman")]
        [UrlValue("seasonal")]
        SeasonalDeadmanMode
    }


}

